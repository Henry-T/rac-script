//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil��tang-hy@live.com
//-----------------------------------------------------------------------------
// ����λ�ã���main
// ��Ҫ���ܣ�����Creator������ʼ�������༭�����ӱ༭�����ű��ĵ����༭��UI��ز��֣�// TODO ?

// ���빫�������ű�
loadDir("common");

//-----------------------------------------------------------------------------
// ����Ĭ�Ͽ���̨����

// Ĭ�Ͽ���̨����
exec("./client/defaults.cs");
exec("./server/defaults.cs");

// ����ֵ������Ĭ�����ã�
exec("./client/prefs.cs");
exec("./server/prefs.cs");

//-----------------------------------------------------------------------------
// ͨ������������ʼ��mod
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

   // �������أ��������ط�һ��
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
               error("Error: �Ҳ��������в���. Usage: -mission <filename>");

         //--------------------
         case "-connect":
            $argUsed[%i]++;
            if (%hasNextArg) {
               $JoinGameAddress = %nextArg;
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: �Ҳ��������в���. Usage: -connect <ip_address>");
      }
   }
}

function onStart()
{
   Parent::onStart();
   echo("\n--------- ��ʼ�� MOD: Climb Game ---------");

   // Load the scripts that start it all...
   // ��������ֳ�ʼ���ű�
   exec("./client/init.cs");
   exec("./server/init.cs");
   exec("./data/init.cs");

   // �����������лỰ�б����룬��Ϊ�ͻ����Լ����԰�������������
   initServer();

   // �Կͻ�����������������ȫְ������ģʽ
   if ($Server::Dedicated)
      initDedicated();
   else
      initClient();
}

function onExit()
{
   echo("�����ͻ�������ֵ");
   export("$pref::*", "./client/prefs.cs", False);

   echo("�����ͻ�������");
   if (isObject(moveMap))
      moveMap.save("./client/config.cs", false);

   echo("��������������ֵ");
   export("$Pref::Server::*", "./server/prefs.cs", False);
   BanList::Export("./server/banlist.cs");

   Parent::onExit();
}

}; // Client package
activatePackage(FpsStarterKit);
