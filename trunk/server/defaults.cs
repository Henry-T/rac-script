//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil：tang-hy@live.com
//-----------------------------------------------------------------------------

// 可以请求的服务器主机，按顺序尝试连接每一个条目，直到收到第一条响应
$Pref::Server::RegionMask = 2;
$pref::Master[0] = "2:master.garagegames.com:28002";

// 服务器信息
$Pref::Server::Name = "Climb Game";
$Pref::Server::Info = "这是登山游戏的测试服务器";

// 一旦发生连接错误，例如网络错配、丢失文件等，这条信息就会被发送给客户端并显示出来。
// 应当将错误消息的内容替换为对客户端友好的信息，例如能够获取游戏更新的网址或者ftp地址
$Pref::Server::ConnectionError =
   "你的登山游戏版本不正确，或者游戏资源文件缺失。"@
   "请联系作者LoloFinil：tang-hy@live.com"@
   "以获取更多信息";

// 网络端口在客户端中也定义了一次，这里重载了pref::net::port优先值
$Pref::Server::Port = 28000;

// 如果服务器设置了密码，客户端必须知道正确的密码才能连接。
$Pref::Server::Password = "";

// 管理员客户端密码
$Pref::Server::AdminPassword = "";

// 服务器设置杂项
$Pref::Server::MaxPlayers = 64;
$Pref::Server::TimeLimit = 20;               // In minutes
$Pref::Server::KickBanTime = 300;            // specified in seconds
$Pref::Server::BanTime = 1800;               // specified in seconds
$Pref::Server::FloodProtectionEnabled = 1;
$Pref::Server::MaxChatLen = 120;

// 当前Torque引擎版本不支持语音压缩
// .v12 (1.2 kbits/sec), .v24 (2.4 kbits/sec), .v29 (2.9kbits/sec)
$Audio::voiceCodec = ".v12";
