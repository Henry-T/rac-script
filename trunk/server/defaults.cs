//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil��tang-hy@live.com
//-----------------------------------------------------------------------------

// ��������ķ�������������˳��������ÿһ����Ŀ��ֱ���յ���һ����Ӧ
$Pref::Server::RegionMask = 2;
$pref::Master[0] = "2:master.garagegames.com:28002";

// ��������Ϣ
$Pref::Server::Name = "Climb Game";
$Pref::Server::Info = "���ǵ�ɽ��Ϸ�Ĳ��Է�����";

// һ���������Ӵ�������������䡢��ʧ�ļ��ȣ�������Ϣ�ͻᱻ���͸��ͻ��˲���ʾ������
// Ӧ����������Ϣ�������滻Ϊ�Կͻ����Ѻõ���Ϣ�������ܹ���ȡ��Ϸ���µ���ַ����ftp��ַ
$Pref::Server::ConnectionError =
   "��ĵ�ɽ��Ϸ�汾����ȷ��������Ϸ��Դ�ļ�ȱʧ��"@
   "����ϵ����LoloFinil��tang-hy@live.com"@
   "�Ի�ȡ������Ϣ";

// ����˿��ڿͻ�����Ҳ������һ�Σ�����������pref::net::port����ֵ
$Pref::Server::Port = 28000;

// ������������������룬�ͻ��˱���֪����ȷ������������ӡ�
$Pref::Server::Password = "";

// ����Ա�ͻ�������
$Pref::Server::AdminPassword = "";

// ��������������
$Pref::Server::MaxPlayers = 64;
$Pref::Server::TimeLimit = 20;               // In minutes
$Pref::Server::KickBanTime = 300;            // specified in seconds
$Pref::Server::BanTime = 1800;               // specified in seconds
$Pref::Server::FloodProtectionEnabled = 1;
$Pref::Server::MaxChatLen = 120;

// ��ǰTorque����汾��֧������ѹ��
// .v12 (1.2 kbits/sec), .v24 (2.4 kbits/sec), .v29 (2.9kbits/sec)
$Audio::voiceCodec = ".v12";
