datablock TriggerData( PartEnvTrigger )
{
   tickPeriodMS = 1000;	
};

function PartEnvTrigger::onEnterTrigger( %this, %trigger, %obj )
{
   echo( "��ҵ�����Ŀ�ĵ�");
   
   Parent::onEnterTrigger( %this, %trigger, %obj );
}

function PartEnvTrigger::onTickTrigger( %this, %trigger )
{
   // echo( "The player has just left the Temple of Evil! - The player lives to fight another day!");
   
   Parent::onTickTrigger( %this, %trigger);
}