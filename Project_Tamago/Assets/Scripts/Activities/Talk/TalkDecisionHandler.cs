using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;


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

[System.Serializable]
public class TalkDecisionHandler
{
    public Dictionary<string, Dialogue> dialogueCriteriaPairs; 
    public List<Criteria> criteriaList;
    public List<Dialogue> dialogueList;

    public TalkDecisionHandler() 
    {
        dialogueCriteriaPairs = new Dictionary<string, Dialogue>();

        SetUpCriteria(); SetUpDialogue();

        for (int i = 0; i < dialogueList.Count; i++)
        {
            dialogueCriteriaPairs.Add(criteriaList[i].CriteriaToString(), dialogueList[i]);
        }
    }

    public Dialogue DetermineDialogue(string key)
    {
        return dialogueCriteriaPairs[key];
    }

    // NOT what the final version of this func will look like
    public void SetUpCriteria()
    {
        criteriaList = new List<Criteria>() { new Criteria(), new Criteria(), new Criteria() };


        criteriaList[0].gameStateBools["hungerIsAt20OrLower"] = true;
        criteriaList[0].gameStateBools["hungerIsBetween21And50"] = false;
        criteriaList[0].gameStateBools["hungerIsAt51OrHigher"] = false;

        criteriaList[1].gameStateBools["hungerIsAt20OrLower"] = false;
        criteriaList[1].gameStateBools["hungerIsBetween21And50"] = true;
        criteriaList[1].gameStateBools["hungerIsAt51OrHigher"] = false;

        criteriaList[2].gameStateBools["hungerIsAt20OrLower"] = false;
        criteriaList[2].gameStateBools["hungerIsBetween21And50"] = false;
        criteriaList[2].gameStateBools["hungerIsAt51OrHigher"] = true;
    }
    
    public void SetUpDialogue()
    {
        dialogueList = new List<Dialogue>()
        {
            new Dialogue(new string[2] {"dawg im so hecking hungry like holy moly", "can you pls feed me like. rn ;-;"}),
            new Dialogue(new string[2] {"hey um i'm not crazy hungy but i'm hungy", "would you mind giving me something to eat?"}),
            new Dialogue(new string[3] {"yippee that food was so yummy btw :3", "v nice stuff, would recommend", "honestly i could go for more o<o"})
        };
    }
}




/*
criteriaList[0].gameStateDict["hungerIsAt20OrLower"].stateBool = true;
criteriaList[0].gameStateDict["hungerIsBetween21And50"].stateBool = false;
criteriaList[0].gameStateDict["hungerIsAt51OrHigher"].stateBool = false;

criteriaList[1].gameStateDict["hungerIsAt20OrLower"].stateBool = false;
criteriaList[1].gameStateDict["hungerIsBetween21And50"].stateBool = true;
criteriaList[1].gameStateDict["hungerIsAt51OrHigher"].stateBool = false;

criteriaList[2].gameStateDict["hungerIsAt20OrLower"].stateBool = false;
criteriaList[2].gameStateDict["hungerIsBetween21And50"].stateBool = false;
criteriaList[2].gameStateDict["hungerIsAt51OrHigher"].stateBool = true;*/


/*public Dictionary<string, State> gameStateDict;

public Criteria() 
{ 
    gameStateDict = new Dictionary<string, State>
    {
        { "hungerIsAt20OrLower", new BoolState(false) },
        { "hungerIsBetween21And50", new BoolState(false) },
        { "hungerIsAt51OrHigher", new BoolState(false) },
        //{ "happyLevel", new IntState(0) },
        //{ "justWokeUp", new BoolState(true) }
    };
}*/