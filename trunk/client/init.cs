//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil：tang-hy@live.com
//-----------------------------------------------------------------------------
// 载入位置：ClimbGame包初始化
// 主要功能：初始化客户端（载入优先值、载入Common模块中的客户端公用部分、载入Gui、载入脚本、载入按键映射、启动主菜单、连接服务器）

//-----------------------------------------------------------------------------

// 供客户端脚本和代码使用的变量。标记为(c)的能够从代码中访问。
// 带有Pref::前缀的是客户端优先值，在一次回话结束前被自动保存在~/client/prefs.cs
//    (c) Client::MissionFile             Mission file name
//    ( ) Client::Password                Password for server join

//    (?) Pref::Player::CurrentFOV
//    (?) Pref::Player::DefaultFov
//    ( ) Pref::Input::KeyboardTurnSpeed

//    (c) pref::Master[n]                 List of master servers
//    (c) pref::Net::RegionMask     
//    (c) pref::Client::ServerFavoriteCount
//    (c) pref::Client::ServerFavorite[FavoriteCount]
//    .. Many more prefs... need to finish this off

// Moves, not finished with this either...
//    (c) firstPerson
//    $mv*Action...

//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function initClient()
{
   echo("\n--------- 初始化 MOD: Climb Game: Client ---------");

   // 确保变量能表明正确的状态
   $Server::Dedicated = false;

   // Game information used to query the master server
   // 
   $Client::GameTypeQuery = "Climb Game";
   $Client::MissionTypeQuery = "Any";

   //
   exec("./ui/customProfiles.cs"); // 根据需要重载默认的配置

   // 初始化Common模块提供的基本客户端功能
   initBaseClient();

   // InitCanvas 启动图形系统
   // Canvas需要在gui脚本执行之前被创建
   // 因为很多控件在加载的时候认为Canvas是存在的
   initCanvas("Climb Game", true);
   if (!isObject(Canvas))
	  // 初始化失败了，避免更糟糕的情况，直接结束程序
      return;

   /// 载入客户端声音配置以及描述
   exec("./scripts/audioProfiles.cs");

   // 载入登山游戏过程Gui
   exec("./ui/defaultGameProfiles.cs");
   exec("./ui/InGame/InGameGui.gui");
   exec("./ui/ChatHud.gui");
   exec("./ui/playerList.gui");

   // 载入登山游戏Gui
   exec("./ui/MainMenu/MainMenuGui.gui");
   exec("./ui/SceneSelect/SceneSelectGui.gui");
   exec("./ui/RolePanel/RolePanelGui.gui");
   exec("./ui/ButtonPanel/ButtonPanelGui.gui");
   exec("./ui/Map/MapGui.gui");
   exec("./ui/Note/NoteGui.gui");
   exec("./ui/Backpack/BackpackGui.gui");
   exec("./ui/Environment/EnvironmentGui.gui");
   
   // 载入shell Gui
   exec("./ui/mainMenuGui.gui");
   exec("./ui/aboutDlg.gui");
   exec("./ui/startMissionGui.gui");
   exec("./ui/joinServerGui.gui");
   exec("./ui/loadingGui.gui");
   exec("./ui/endGameGui.gui");
   exec("./ui/optionsDlg.gui");
   exec("./ui/remapDlg.gui");
   exec("./ui/StartupGui.gui");

   // 客户端脚本
   exec("./scripts/client.cs");
   exec("./scripts/game.cs");
   exec("./scripts/missionDownload.cs");
   exec("./scripts/serverConnection.cs");
   exec("./scripts/playerList.cs");
   exec("./scripts/loadingGui.cs");
   exec("./scripts/optionsDlg.cs");
   exec("./scripts/chatHud.cs");
   exec("./scripts/messageHud.cs");
   exec("./scripts/playGui.cs");
   exec("./scripts/centerPrint.cs");

   // 默认玩家按键映射
   exec("./scripts/default.bind.cs");
   exec("./config.cs");

   // 除非我们要连接远程服务器，或者作为一个多玩家服务器,
   // 否则不要启动网络连接。
   setNetPort(0);

   // 将保存的脚本优先值复制到C++代码中。
   setShadowDetailLevel( $pref::shadows );
   setDefaultFov( $pref::Player::defaultFov );
   setZoomSpeed( $pref::Player::zoomSpeed );

   // 启动主菜单... 这个功能被分离到一个单独的方法中方便以后重载

   if ($JoinGameAddress !$= "") {
	  // 如果我们需要连接到服务器，那么在主菜单载入完成后马上尝试连接。
      loadMainMenu();
      connect($JoinGameAddress, "", $Pref::Player::Name);
   }
   else {
	  // 否则进入闪屏
      Canvas.setCursor("DefaultCursor");
      loadStartup();
   }
}


//-----------------------------------------------------------------------------


function loadMainMenu()
{
   // 客户端的启动从主菜单载入开始
   Canvas.setContent( SceneSelectGui );


   // 确保音频系统初始化过了
   if($Audio::initFailed) {
      MessageBoxOK("Audio Initialization Failed", 
         "The OpenAL audio system failed to initialize.  " @
         "You can get the most recent OpenAL drivers <a:www.garagegames.com/docs/torque/gstarted/openal.html>here</a>.");
   }

   Canvas.setCursor("DefaultCursor");
}


