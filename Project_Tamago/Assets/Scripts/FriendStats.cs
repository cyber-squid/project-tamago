using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendStats 
{
    string nickname;

    int age;

    Personality personality;

    int hungry = 50;
    int happy = 50;
    int health = 50;
    public int affection {  get; private set; }

    public string currentBonusEvolvePassword { get; private set; }


    public void ChangeStat(StatType statType, StatChangeRange changeRange)
    {
        switch (statType)
        {
            case StatType.hungry:
                hungry += (int)changeRange;
                hungry = RoundOffStat(hungry);
                Debug.Log(hungry);
                break;
            case StatType.happy:
                happy += (int)changeRange;
                happy = RoundOffStat(happy);
                break;
            case StatType.health:
                health += (int)changeRange;
                health = RoundOffStat(health);
                break;
            case StatType.affection:
                affection += (int)changeRange;
                affection = RoundOffStat(affection);
                Debug.Log(affection);
                break;
            default:
                break;
        }
        
    }

    public void ChangeStat(StatType statType, int customChange) // in case something really good or really bad happens for your buddy.
    {
        switch (statType)
        {
            case StatType.hungry:
                hungry += customChange;
                hungry = RoundOffStat(hungry);
                break;
            case StatType.happy:
                happy += customChange;
                happy = RoundOffStat(happy);
                break;
            case StatType.health:
                health += customChange;
                health = RoundOffStat(health);
                break;
            case StatType.affection:
                affection += customChange;
                affection = RoundOffStat(affection);
                break;
            default:
                Debug.Log("nothing happened for this stat.");
                break;
        }
    }


    int RoundOffStat(int stat)
    {
        if (stat > 100) { stat = 100; }
        if (stat < 0) {  stat = 0; }
        return stat;
    }
}



public enum Personality
{
    laidback,
    friendly,
    shy
}
public enum StatType
{
    hungry,
    happy, 
    health,
    affection
}

public enum StatChangeRange
{
    positiveMajor = 35, positiveMid = 20, positiveMinor = 10,
    negativeMajor = -35, negativeMid = -20, negativeMinor = -10,
    noEffect = 0
}