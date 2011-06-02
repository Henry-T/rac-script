//-----------------------------------------------------------------------------
// RunAfterCloud
// by LoloFinil��tang-hy@live.com
//-----------------------------------------------------------------------------
// ����λ�ã�ClimbGame����ʼ��
// ��Ҫ���ܣ���ʼ���ͻ��ˣ���������ֵ������Commonģ���еĿͻ��˹��ò��֡�����Gui������ű������밴��ӳ�䡢�������˵������ӷ�������

//-----------------------------------------------------------------------------

// ���ͻ��˽ű��ʹ���ʹ�õı��������Ϊ(c)���ܹ��Ӵ����з��ʡ�
// ����Pref::ǰ׺���ǿͻ�������ֵ����һ�λػ�����ǰ���Զ�������~/client/prefs.cs
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
   echo("\n--------- ��ʼ�� MOD: Climb Game: Client ---------");

   // ȷ�������ܱ�����ȷ��״̬
   $Server::Dedicated = false;

   // Game information used to query the master server
   // 
   $Client::GameTypeQuery = "Climb Game";
   $Client::MissionTypeQuery = "Any";

   //
   exec("./ui/customProfiles.cs"); // ������Ҫ����Ĭ�ϵ�����

   // ��ʼ��Commonģ���ṩ�Ļ����ͻ��˹���
   initBaseClient();

   // InitCanvas ����ͼ��ϵͳ
   // Canvas��Ҫ��gui�ű�ִ��֮ǰ������
   // ��Ϊ�ܶ�ؼ��ڼ��ص�ʱ����ΪCanvas�Ǵ��ڵ�
   initCanvas("Climb Game", true);
   if (!isObject(Canvas))
	  // ��ʼ��ʧ���ˣ���������������ֱ�ӽ�������
      return;

   /// ����ͻ������������Լ�����
   exec("./scripts/audioProfiles.cs");

   // �����ɽ��Ϸ����Gui
   exec("./ui/defaultGameProfiles.cs");
   exec("./ui/InGame/InGameGui.gui");
   exec("./ui/ChatHud.gui");
   exec("./ui/playerList.gui");

   // �����ɽ��ϷGui
   exec("./ui/MainMenu/MainMenuGui.gui");
   exec("./ui/SceneSelect/SceneSelectGui.gui");
   exec("./ui/RolePanel/RolePanelGui.gui");
   exec("./ui/ButtonPanel/ButtonPanelGui.gui");
   exec("./ui/Map/MapGui.gui");
   exec("./ui/Note/NoteGui.gui");
   exec("./ui/Backpack/BackpackGui.gui");
   exec("./ui/Environment/EnvironmentGui.gui");
   
   // ����shell Gui
   exec("./ui/mainMenuGui.gui");
   exec("./ui/aboutDlg.gui");
   exec("./ui/startMissionGui.gui");
   exec("./ui/joinServerGui.gui");
   exec("./ui/loadingGui.gui");
   exec("./ui/endGameGui.gui");
   exec("./ui/optionsDlg.gui");
   exec("./ui/remapDlg.gui");
   exec("./ui/StartupGui.gui");

   // �ͻ��˽ű�
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

   // Ĭ����Ұ���ӳ��
   exec("./scripts/default.bind.cs");
   exec("./config.cs");

   // ��������Ҫ����Զ�̷�������������Ϊһ������ҷ�����,
   // ����Ҫ�����������ӡ�
   setNetPort(0);

   // ������Ľű�����ֵ���Ƶ�C++�����С�
   setShadowDetailLevel( $pref::shadows );
   setDefaultFov( $pref::Player::defaultFov );
   setZoomSpeed( $pref::Player::zoomSpeed );

   // �������˵�... ������ܱ����뵽һ�������ķ����з����Ժ�����

   if ($JoinGameAddress !$= "") {
	  // ���������Ҫ���ӵ�����������ô�����˵�������ɺ����ϳ������ӡ�
      loadMainMenu();
      connect($JoinGameAddress, "", $Pref::Player::Name);
   }
   else {
	  // �����������
      Canvas.setCursor("DefaultCursor");
      loadStartup();
   }
}


//-----------------------------------------------------------------------------


function loadMainMenu()
{
   // �ͻ��˵����������˵����뿪ʼ
   Canvas.setContent( SceneSelectGui );


   // ȷ����Ƶϵͳ��ʼ������
   if($Audio::initFailed) {
      MessageBoxOK("Audio Initialization Failed", 
         "The OpenAL audio system failed to initialize.  " @
         "You can get the most recent OpenAL drivers <a:www.garagegames.com/docs/torque/gstarted/openal.html>here</a>.");
   }

   Canvas.setCursor("DefaultCursor");
}


