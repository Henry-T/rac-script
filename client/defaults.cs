//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil：tang-hy@live.com
//-----------------------------------------------------------------------------

// 主服务器在默认的情况的配置模式是集成了客户端和专职服务器两部分。
// 如果服务器mod没有被加载到一个客户端中，那么必须定义一个主机。
// $pref::Master[0] = "2:master.garagegames.com:28002";

$pref::Player::Name = "XiaoZhi";
$pref::Player::defaultFov = 90;
$pref::Player::zoomSpeed = 0;

$pref::Net::LagThreshold = 400;
$pref::Net::Port = 28000;

$pref::shadows = "2";
$pref::HudMessageLogSize = 40;
$pref::ChatHudLength = 1;


$pref::Input::LinkMouseSensitivity = 1;
$pref::Input::MouseEnabled = 0;
$pref::Input::JoystickEnabled = 0;
$pref::Input::KeyboardTurnSpeed = 0.1;

$pref::sceneLighting::cacheSize = 20000;
$pref::sceneLighting::purgeMethod = "lastCreated";
$pref::sceneLighting::cacheLighting = 1;
$pref::sceneLighting::terrainGenerateLevel = 1;

$pref::ts::detailAdjust = 0.45;

$pref::Terrain::DynamicLights = 1;
$pref::Interior::TexturedFog = 0;

$pref::Video::displayDevice = "OpenGL";
$pref::Video::allowOpenGL = 1;
$pref::Video::allowD3D = 1;
$pref::Video::preferOpenGL = 1;
$pref::Video::appliedPref = 0;
$pref::Video::disableVerticalSync = 1;
$pref::Video::monitorNum = 0;
$pref::Video::windowedRes = "800 600";
$pref::Video::screenShotFormat = "PNG";

$pref::OpenGL::force16BitTexture = "0";
$pref::OpenGL::forcePalettedTexture = "0";
$pref::OpenGL::maxHardwareLights = 3;
$pref::VisibleDistanceMod = 1.0;

$pref::Audio::driver = "OpenAL";
$pref::Audio::forceMaxDistanceUpdate = 0;
$pref::Audio::environmentEnabled = 0;
$pref::Audio::masterVolume   = 0.8;
$pref::Audio::channelVolume1 = 0.8;
$pref::Audio::channelVolume2 = 0.8;
$pref::Audio::channelVolume3 = 0.8;
$pref::Audio::channelVolume4 = 0.8;
$pref::Audio::channelVolume5 = 0.8;
$pref::Audio::channelVolume6 = 0.8;
$pref::Audio::channelVolume7 = 0.8;
$pref::Audio::channelVolume8 = 0.8;

