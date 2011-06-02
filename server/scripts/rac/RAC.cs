// 临时 -- 想法
$RACDataState = 0;	// 0-NotReady      1-InGame      2-InMenu

// RAC核心更新
function GameConnection::RACStartUpdate(%this)
{
	Schedule(1000, 0,  RACUpdate, %this);
}

function RACUpdate(%conn)
{
	// TODO 确定玩家是否存在
	
	// TODO 确定游戏的活动界面
	
	// TODO 确定玩家行为
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
	
	// 常规性更新
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
	
	// 再次启动循环
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
	// TODO 修改Player数据块的移动速度 ...
}

// 初始化
function GameConnection::LoadRAC(%this)
{
	echo("RAC Loading...");
	
	// 载入各种数据模块
   exec("./Balance.cs");							// 平衡数据
   
   exec("./GloEnv.cs");								// 全局环境
   exec ("./PartEnv.cs");							// 局部环境
   exec("./EnvDetail.cs");							// 环境细节
   
   exec("./Role.cs");								// 角色基本
   exec("./RoleDetail.cs");						// 角色细节
}

function GameConnection::RACReset(%this)
{
	// 表层数据
	%this.RACRoadCovered = 0;
	%this.RACTime = 0;
	%this.RACWalkTime = 0;
	%this.RACRestTime = 0;
	%this.RACSleepTime = 0;
	%this.RACScore = 0;

	// 分类数据
	%this.GloEnvReset();
	%this.PartEnvReset();
	%this.EnvDetailReset();
	%this.RoleReset();
	%this.RoleDetailReset();
}