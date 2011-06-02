//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// InGameGui is the main TSControl through which the game is viewed.
// The InGameGui also contains the hud controls.
//-----------------------------------------------------------------------------

function InGameGui::onWake(%this)
{
   // Turn off any shell sounds...
   // alxStop( ... );

   $enableDirectInput = "1";
   activateDirectInput();

   // Message hud dialog
   Canvas.pushDialog( MainChatHud );
   Canvas.pushDialog( BackpackGui  );
   
   chatHud.attach(HudMessageVector);

   // just update the action map here
   moveMap.push();
   
   // hack city - these controls are floating around and need to be clamped
   schedule(0, 0, "refreshCenterTextCtrl");
   schedule(0, 0, "refreshBottomTextCtrl");
}

function InGameGui::onSleep(%this)
{
   Canvas.popDialog( MainChatHud  );
   Canvas.pushDialog( BackpackGui  );
   
   // pop the keymaps
   moveMap.pop();
}


//-----------------------------------------------------------------------------

function refreshBottomTextCtrl()
{
   BottomPrintText.position = "0 0";
}

function refreshCenterTextCtrl()
{
   CenterPrintText.position = "0 0";
}


