using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ***** IMPORTANT!!! REMEMBER, THINK ABOUT HOW TO IMPLEMENT CHOICE DIALOGUES LATER. *****
// for now, just try to get a piece of dialogue from the dialogue class to display. 
[Serializable]
public class Dialogue
{
    public DialoguePiece[] setOfLines;

    public virtual void OnSaid() { }
}

[Serializable]
public class DialoguePiece
{
    public string lineToSay;
    public TalkExpression expression;

    public bool isChoice;


}

/*
 * some potential values:
 * 
 * numberOfTimesSpokenToInLifetime
 * numberOfTimesSpokenToInAnHour
 * numberOfTimesSpokenToInARow
 */