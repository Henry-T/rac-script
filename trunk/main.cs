//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil：tang-hy@live.com
//-----------------------------------------------------------------------------
// 载入位置：主main
// 主要功能：激活Creator包（初始化场景编辑、粒子编辑器、脚本文档、编辑器UI相关部分）// TODO ?

// 载入公共基础脚本
loadDir("common");

//-----------------------------------------------------------------------------
// 载入默认控制台变量

// 默认控制台变量
exec("./client/defaults.cs");
exec("./server/defaults.cs");

// 优先值（重载默认设置）
exec("./client/prefs.cs");
exec("./server/prefs.cs");

//-----------------------------------------------------------------------------
// 通过包重载来初始化mod
package FpsStarterKit {

function displayHelp() {
   Parent::displayHelp();
   error(
      "ClimbGame Mod options:\n"@
      "  -dedicated             Start as dedicated server\n"@
      "  -connect <address>     For non-dedicated: Connect to a game at <address>\n" @
      "  -mission <filename>    For dedicated: Load the mission\n"
   );
}

function parseArgs()
{
   Parent::parseArgs();

   // 参数重载，和其他地方一样
   for (%i = 1; %i < $Game::argc ; %i++)
   {
      %arg = $Game::argv[%i];
      %nextArg = $Game::argv[%i+1];
      %hasNextArg = $Game::argc - %i > 1;
   
      switch$ (%arg)
      {
         //--------------------
         case "-dedicated":
            $Server::Dedicated = true;
            enableWinConsole(true);
            $argUsed[%i]++;

         //--------------------
         case "-mission":
            $argUsed[%i]++;
            if (%hasNextArg) {
               $missionArg = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: 找不到命令行参数. Usage: -mission <filename>");

         //--------------------
         case "-connect":
            $argUsed[%i]++;
            if (%hasNextArg) {
               $JoinGameAddress = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: 找不到命令行参数. Usage: -connect <ip_address>");
      }
   }
}

function onStart()
{
   Parent::onStart();
   echo("\n--------- 初始化 MOD: Climb Game ---------");

   // Load the scripts that start it all...
   // 载入各部分初始化脚本
   exec("./client/init.cs");
   exec("./server/init.cs");
   exec("./data/init.cs");

   // 服务器在所有会话中被载入，因为客户端自己可以包含服务器功能
   initServer();

   // 以客户端启动，或者启动全职服务器模式
   if ($Server::Dedicated)
      initDedicated();
   else
      initClient();
}

function onExit()
{
   echo("导出客户端优先值");
   export("$pref::*", "./client/prefs.cs", False);

   echo("导出客户端配置");
   if (isObject(moveMap))
      moveMap.save("./client/config.cs", false);

   echo("导出服务器优先值");
   export("$Pref::Server::*", "./server/prefs.cs", False);
   BanList::Export("./server/banlist.cs");

   Parent::onExit();
}

}; // Client package
activatePackage(FpsStarterKit);
