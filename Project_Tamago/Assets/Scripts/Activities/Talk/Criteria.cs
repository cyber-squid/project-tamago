using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Criteria
{

    
    public string CriteriaToString()
    {
        // archived, bc i'm pretty sure i can just use the newtonsoft jsonconvert func instead here!
        // which is a lot nicer and cleaner 
        /*
        // thank you random stackexchange person. you saved a life today
        var bools = from pairs in gameStateBools
                    select pairs.Key + "=" + pairs.Value;

        string boolsAsLongString = "{" + string.Join(",", bools) + "}";


        var ints = from pairs in gameStateInts
                   select pairs.Key + "=" + pairs.Value;

        string intsAsLongString = "{" + string.Join(",", ints) + "}";

        var strings = from pairs in gameStateStrings
                      select pairs.Key + "=" + pairs.Value;

        string stringsAsLongString = "{" + string.Join(",", strings) + "}";

        return boolsAsLongString + intsAsLongString + stringsAsLongString;*/
        return Newtonsoft.Json.JsonConvert.SerializeObject(this);
    }


    public Dictionary<string, bool> gameStateBools = new Dictionary<string, bool>
    {
        { "hungerIsAt20OrLower", false },
        { "hungerIsBetween21And50", false },
        { "hungerIsAt51OrHigher", false },
        { "thisDialoguePathHasBeenUsed", false }
    };
    public Dictionary<string, int> gameStateInts = new Dictionary<string, int>
    {
        { "age", 0 },
        { "numberOfTimesSpokenToInARow", 0 },
        { "numberOfTimesSpokenToInAnHour", 0 }
    };
    public Dictionary<string, string> gameStateStrings = new Dictionary<string, string>
    {
        { "species", "None" },
        { "personality", "Relaxed" },
        { "favouriteFood", "Chicken" },
            //{ "happyLevel", new IntState(0) },
            //{ "justWokeUp", new BoolState(true) }
    };


    // please help. how else do i represent this. i wanna just make these strings consts too but then i'd need an entire page for that
    void SetUpBools()
    {
        gameStateBools = new Dictionary<string, bool>
        {
            { "hungerIsAt20OrLower", false },
            { "hungerIsBetween21And50", false },
            { "hungerIsAt51OrHigher", false },
            { "thisDialoguePathHasBeenUsed", false }
        };
    }

    public void SetUpInts() 
    {
        gameStateInts = new Dictionary<string, int>
        {
            { "age", 0 },
            { "numberOfTimesSpokenToInARow", 0 },
            { "numberOfTimesSpokenToInAnHour", 0 }
        };
    }

    public void SetUpStrings() 
    {
        gameStateStrings = new Dictionary<string, string>
        {
            { "species", "None" },
            { "personality", "Relaxed" },
            { "favouriteFood", "Chicken" },
            //{ "happyLevel", new IntState(0) },
            //{ "justWokeUp", new BoolState(true) }
        };
    }
}


// *** IMPORTANT REMINDER: i am once again getting ahead of myself
// don't need to think about how to make it so a state only returns or represents a single value type right now
// just need to make sure that a criteria can be used as a key to select a dialogue
// we can also think about how to make editing criteria a relatively scalable thing later
public class State
{
    internal int stateInt;
    internal bool stateBool;
    internal string stateString;

    /*
    public State(int intValue)
    { 
        stateAsInt = intValue;
    }*/


    /*
    public void SetState(State state)
    {
        this = state;
    }

    public void SetState(int stateAsInt)
    {
        stateInt = stateAsInt;
    }

    public void RetrieveState()
    {
        if (this == typeof(BoolState))
        {
            return stateBool;
        }
    }*/

    public virtual string StateAsString() { return null; }

}

public class IntState : State
{
    public int representationalInt { get { return stateInt; } }

    public IntState(int givenValue)
    {
        stateInt = givenValue;
    }

    public override string StateAsString() { return representationalInt.ToString(); }
}

public class BoolState : State
{
    public bool representationalBool { get { return stateBool; } }

    public BoolState(bool givenValue)
    {
        stateBool = givenValue;
    }
}