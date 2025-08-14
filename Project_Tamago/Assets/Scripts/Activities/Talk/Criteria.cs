using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Criteria
{
    public Dictionary<string, bool> gameStateBools;
    public Dictionary<string, int> gameStateInts;
    public Dictionary<string, string> gameStateStrings;


    public Criteria()
    {
        SetUpBools();
        SetUpInts();
        SetUpStrings();
    }

    // thank you random stackexchange person. you saved a life today
    public string CriteriaToString()
    {
        var bools = from pairs in gameStateBools
                    select pairs.Key + "=" + pairs.Value;

        string almostDone = "{" + string.Join(",", bools) + "}";

        string thisIsSilly = SingleDictToString();
        string idrc = IDontGetItAndAmGettingAnnoyed();
        return almostDone + thisIsSilly + idrc;
    }

    public string SingleDictToString()
    {
        var ints = from pairs in gameStateInts
                   select pairs.Key + "=" + pairs.Value;

        return "{" + string.Join(",", ints) + "}";
    }

    public string IDontGetItAndAmGettingAnnoyed()
    {
        var strings = from pairs in gameStateStrings
                      select pairs.Key + "=" + pairs.Value;

        return "{" + string.Join(",", strings) + "}";
    }

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