//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil：tang-hy@live.com
//-----------------------------------------------------------------------------
// 载入位置：ClimbGame包初始化
// 主要功能：定义初始化服务器和初始化专职服务器函数

//-----------------------------------------------------------------------------

// 供服务器脚本和代码使用的变量。
// 标记有(c)的能够被代码访问。
// 带有Pref::前缀的是服务器优先值，
// 在每次回话结束前被自动保存在ServerPrefs.cs文件中。
//
//    (c) Server::ServerType              {SinglePlayer, MultiPlayer}
//    (c) Server::GameType                Unique game name
//    (c) Server::Dedicated               Bool
//    ( ) Server::MissionFile             Mission .mis file name
//    (c) Server::MissionName             DisplayName from .mis file
//    (c) Server::MissionType             Not used
//    (c) Server::PlayerCount             Current player count
//    (c) Server::GuidList                Player GUID (record list?)
//    (c) Server::Status                  Current server status
//
//    (c) Pref::Server::Name              Server Name
//    (c) Pref::Server::Password          Password for client connections
//    ( ) Pref::Server::AdminPassword     Password for client admins
//    (c) Pref::Server::Info              Server description
//    (c) Pref::Server::MaxPlayers        Max allowed players
//    (c) Pref::Server::RegionMask        Registers this mask with master server
//    ( ) Pref::Server::BanTime           Duration of a player ban
//    ( ) Pref::Server::KickBanTime       Duration of a player kick & ban
//    ( ) Pref::Server::MaxChatLen        Max chat message len
//    ( ) Pref::Server::FloodProtectionEnabled Bool

//-----------------------------------------------------------------------------


//-----------------------------------------------------------------------------

function initServer()
{
   echo("\n--------- 初始化 MOD: Climb Game: Server ---------");

   // Server::Status 在Game Info Query中被返回，代表了当前服务器的状态。
   // 这个字符串应该比较短。
   $Server::Status = "Unknown";

   // 开启测试/Debug脚本函数
   $Server::TestCheats = false;

   // 关卡文件定位
   $Server::MissionFileSpec = "*/missions/*.mis";

   // 初始化Common模块提供的基本服务器功能
   initBaseServer();

   // 载入服务器支持脚本
   exec("./scripts/commands.cs");
   exec("./scripts/centerPrint.cs");
   exec("./scripts/game.cs");
}


//-----------------------------------------------------------------------------

function initDedicated()
{
   enableWinConsole(true);
   echo("\n--------- 启动专职服务器 ---------");

   // 确保这个变量反映了正确的状态
   $Server::Dedicated = true;

   // 除非指定了一个关卡，否则服务器不会启动。
   if ($missionArg !$= "") {
      createServer("MultiPlayer", $missionArg);
   }
   else
      echo("No mission specified (use -mission filename)");
}

