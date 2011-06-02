datablock TriggerData( GameOverTrigger )
{
   tickPeriodMS = 1000;
   
   // 设置各属性默认值
   PEName = "未命名";
   Terrain = "默认";
   Var = "默认";
   VarLeftType = "默认";
   
   ViewTime = 0;
};

function GameOverTrigger::onEnterTrigger( %this, %trigger, %obj )
{
   // 激活当前生态信息
   echo("角色进入新的生态区域：" @ PEName);
   %obj.client.SetPE(PEName, Terrain, Var, VarLeftType, ViewTime);
   Parent::onEnterTrigger( %this, %trigger, %obj );
}

function GameOverTrigger::onTickTrigger( %this, %trigger )
{
	// 每秒将服务器更新值保存进Trigger
   ViewTime = this.GetObject(n).client.PEViewTime;
   
   Parent::onTickTrigger( %this, %trigger);
}