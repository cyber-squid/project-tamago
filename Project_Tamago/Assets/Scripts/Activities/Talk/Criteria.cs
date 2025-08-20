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

}