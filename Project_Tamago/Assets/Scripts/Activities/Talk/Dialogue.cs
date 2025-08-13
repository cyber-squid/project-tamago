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

    public Dialogue(string[] linesToSay)
    {
        this.linesToSay = linesToSay;
    }

    public virtual void OnSaid() { }

}


public class Query
{
    List<string> criteria;
}

/*
 * some potential values:
 * 
 * numberOfTimesSpokenToInLifetime
 * numberOfTimesSpokenToInAnHour
 * numberOfTimesSpokenToInARow
 */