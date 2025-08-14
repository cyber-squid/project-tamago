using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ***** IMPORTANT!!! REMEMBER, THINK ABOUT HOW TO IMPLEMENT CHOICE DIALOGUES LATER. *****
// for now, just try to get a piece of dialogue from the dialogue class to display. 
public class Dialogue
{
    public string[] linesToSay;
    public TalkExpression[] expressions;

    public Dialogue(string[] linesToSay, TalkExpression[] expressions)
    {
        this.linesToSay = linesToSay;
        this.expressions = expressions;
    }

    public virtual void OnSaid() { }
}

/*
 * some potential values:
 * 
 * numberOfTimesSpokenToInLifetime
 * numberOfTimesSpokenToInAnHour
 * numberOfTimesSpokenToInARow
 */