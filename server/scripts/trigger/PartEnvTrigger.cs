datablock TriggerData( GameOverTrigger )
{
   tickPeriodMS = 1000;
   
   // ���ø�����Ĭ��ֵ
   PEName = "δ����";
   Terrain = "Ĭ��";
   Var = "Ĭ��";
   VarLeftType = "Ĭ��";
   
   ViewTime = 0;
};

function GameOverTrigger::onEnterTrigger( %this, %trigger, %obj )
{
   // ���ǰ��̬��Ϣ
   echo("��ɫ�����µ���̬����" @ PEName);
   %obj.client.SetPE(PEName, Terrain, Var, VarLeftType, ViewTime);
   Parent::onEnterTrigger( %this, %trigger, %obj );
}

function GameOverTrigger::onTickTrigger( %this, %trigger )
{
	// ÿ�뽫����������ֵ�����Trigger
   ViewTime = this.GetObject(n).client.PEViewTime;
   
   Parent::onTickTrigger( %this, %trigger);
}