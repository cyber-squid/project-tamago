using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// giant set of "rules" aka dialogues, (one for each personality?), and criteria that must be met to meet them.
// represented by a dictionary, with the keys being criteria, and the values being the dialogues.
// the criteria represent a wide array of data about the game state. energy, last game played, how mamy times you discussed today, etc.

// perhaps criteria can be a class that has a massive, premade list of variables representing current state (probably its own dictionary?), 
// with the criteria keys in the dictionary being instances that collectively represent all the different kinds of states the game could possibly be in?
// and the query is a criteria class instance, whose values have been updated over the course of the game? then, when you want to talk, 
// the query is (maybe turned into a string first? idk) used to check for the criteria class with all the same values, and the dialogue value paired 
// to that gets passed to the talkactivity.
//
// for an event that your tama forces an interaction, we could set a flag somewhere in talkactivity to activate, which in turn 
// automatically compares the query to the dictionary. 


// to poll for a line from the dictionary, we can concatenate together all the values for all the criteria into one big string. 
// if this string matches a key in the dictionary, we can pass the dialogue value paired to it to the talkactivity, for it to display. 


public class TalkDecisionHandler
{
    public Dictionary<string, Dialogue> dialogueDict; // = new Dictionary<string, Dialogue>();

    

    public TalkDecisionHandler() 
    {
        dialogueDict = new Dictionary<string, Dialogue>();

        string[] loadedText = new string[3];
        loadedText[0] = "hi";
        loadedText[1] = "its me";
        loadedText[2] = "blehhh";
        Dialogue dialogue = new Dialogue(loadedText);
        dialogueDict.Add("testtext", dialogue);
    }
    /*
     * queryhandler 
     */



    public Dialogue DetermineDialogue(string key)
    {
        return dialogueDict[key];
    }



}

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