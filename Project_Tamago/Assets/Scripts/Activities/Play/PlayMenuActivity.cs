using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuActivity : MinimenuActivity
{
    // originally stole code from foodmenuactivity to make this work, but i decided that 
    // if i'm making an accessory selection activity later, i will probably need the code again. thus 
    // i pulled it into its own deriving class :)
    internal override void ChangeScreen()
    {
        menuPanel.SetActive(true);
    }

    // time to start a minigame!
    public override void MenuButtonClicked(MenuSlot clickedSlot)
    {
        PlayMenuSlot slot = clickedSlot as PlayMenuSlot;
        if (slot != null) { Debug.Log("Starting a game!"); }
    }

    internal override void ActivityFinishCleanup()
    {
        menuPanel.SetActive(false);
    }
}
