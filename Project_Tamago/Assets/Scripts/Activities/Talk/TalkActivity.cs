using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TalkActivity : GenericActivity
{
    // if the button is clicked on, it should prompt the tama to talk. 
    // this should create a query that uses all the currently loaded rules to determine the dialogue lines.

    //

    // the response, along with prompting that particular dialogue, should then nullify the context data relevant to that dialogue since it's been said, but leave other data alone so
    // that the next query can use it to poll the appropriate dialogue. for example, if you bathed tama, and fed it a food it dislikes, it should comment on the food first, then 
    // remove the last eaten food var, and the next query can otherwise use the same values


    // in certain cases, we'd want the game to force a talk, eg if something calls for checking a query that would prompt the force talk if it passes.

    TalkDecisionHandler talkDecisionHandler;

    internal override void ChangeScreen()
    {
        // should probably calculate, or retreive current query somewhere here?
        if (talkDecisionHandler.dialogueDict.ContainsKey("testtext"))
        {
            
        }
        mainScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            EndActivity();
        }
    }


    internal override void ActivityFinishCleanup()
    {
        mainScreen.SetActive(false);
    }
}