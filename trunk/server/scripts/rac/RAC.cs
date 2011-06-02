// ��ʱ -- �뷨
$RACDataState = 0;	// 0-NotReady      1-InGame      2-InMenu

// RAC���ĸ���
function GameConnection::RACStartUpdate(%this)
{
	Schedule(1000, 0,  RACUpdate, %this);
}

function RACUpdate(%conn)
{
	// TODO ȷ������Ƿ����
	
	// TODO ȷ����Ϸ�Ļ����
	
	// TODO ȷ�������Ϊ
	// switch(%client.RoleState)
	// {
		// case "Walk":
			// Walk(%client);
			// break;
		// case "Rest":
			// Rest(%client);
			// break;
		// case "Sleep":
			// Sleep(%client);
			// break;
	// }
	%conn.Walk();
	
	// �����Ը���
	%conn.EnvDetailUpdate();
	%conn.RoleUpdate();
	%conn.RoleDetailUpdate();
	
	echo("RAC Server: Sending Client Command");
	echo("RAC Server: Send new RoleStrength-"@%this.RoleStrength@"U");
	echo("RAC Server: Send new RoleComfort-"@%this.RoleComfort@"U");
	echo("RAC Server: Send new RoleInterest-"@%this.RoleInterest@"U");
	echo("RAC Server: Send new RoleHappiness-"@%this.RoleHappiness@"U");
	commandToClient(%conn, 'SetRoleData',  %this.RoleStrength, %this.RoleComfort, %this.RoleInterest, %this.RoleHappiness);
	commandToClient(%conn, 'SetEnvData', %this.GETempN, %this.GEDampN, %this.GEnvRainN, %this.GELightN);
	
	echo("RAC: Main Logic Loop Called!");
	
	// �ٴ�����ѭ��
	//%conn.RACStartUpdate();
}

function GameConnection::Walk(%client)
{
	// if(roleState == Walking)
	%client.RoleStrength -= %client.RealStrengthConsume;
	%client.RoleHappiness += %client.RealInterestRate;
	
	%client.RACTime++;
	%client.RACWalkTime ++;
	%client.RACRoadCovered += %client.RealMovement;
	%client.RACScore  += %client.RoleHappiness;
	
	%client.UpdateMotionSpeed();
	player::UpdateRealStrengthConsume();
	
}

function GameConnection::UpdateMotionSpeed()
{
	// TODO �޸�Player���ݿ���ƶ��ٶ� ...
}

// ��ʼ��
function GameConnection::LoadRAC(%this)
{
	echo("RAC Loading...");
	
	// �����������ģ��
   exec("./Balance.cs");							// ƽ������
   
   exec("./GloEnv.cs");								// ȫ�ֻ���
   exec ("./PartEnv.cs");							// �ֲ�����
   exec("./EnvDetail.cs");							// ����ϸ��
   
   exec("./Role.cs");								// ��ɫ����
   exec("./RoleDetail.cs");						// ��ɫϸ��
}

function GameConnection::RACReset(%this)
{
	// �������
	%this.RACRoadCovered = 0;
	%this.RACTime = 0;
	%this.RACWalkTime = 0;
	%this.RACRestTime = 0;
	%this.RACSleepTime = 0;
	%this.RACScore = 0;

	// ��������
	%this.GloEnvReset();
	%this.PartEnvReset();
	%this.EnvDetailReset();
	%this.RoleReset();
	%this.RoleDetailReset();
}