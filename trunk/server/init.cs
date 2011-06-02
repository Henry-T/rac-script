//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil��tang-hy@live.com
//-----------------------------------------------------------------------------
// ����λ�ã�ClimbGame����ʼ��
// ��Ҫ���ܣ������ʼ���������ͳ�ʼ��רְ����������

//-----------------------------------------------------------------------------

// ���������ű��ʹ���ʹ�õı�����
// �����(c)���ܹ���������ʡ�
// ����Pref::ǰ׺���Ƿ���������ֵ��
// ��ÿ�λػ�����ǰ���Զ�������ServerPrefs.cs�ļ��С�
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
   echo("\n--------- ��ʼ�� MOD: Climb Game: Server ---------");

   // Server::Status ��Game Info Query�б����أ������˵�ǰ��������״̬��
   // ����ַ���Ӧ�ñȽ϶̡�
   $Server::Status = "Unknown";

   // ��������/Debug�ű�����
   $Server::TestCheats = false;

   // �ؿ��ļ���λ
   $Server::MissionFileSpec = "*/missions/*.mis";

   // ��ʼ��Commonģ���ṩ�Ļ�������������
   initBaseServer();

   // ���������֧�ֽű�
   exec("./scripts/commands.cs");
   exec("./scripts/centerPrint.cs");
   exec("./scripts/game.cs");
}


//-----------------------------------------------------------------------------

function initDedicated()
{
   enableWinConsole(true);
   echo("\n--------- ����רְ������ ---------");

   // ȷ�����������ӳ����ȷ��״̬
   $Server::Dedicated = true;

   // ����ָ����һ���ؿ����������������������
   if ($missionArg !$= "") {
      createServer("MultiPlayer", $missionArg);
   }
   else
      echo("No mission specified (use -mission filename)");
}

