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
                break;
            case StatType.happy:
                happy += (int)changeRange;
                break;
            case StatType.health:
                health += (int)changeRange;
                break;
            case StatType.affection:
                affection += (int)changeRange;
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
                break;
            case StatType.happy:
                happy += customChange;
                break;
            case StatType.health:
                health += customChange;
                break;
            case StatType.affection:
                affection += customChange;
                break;
            default:
                break;
        }
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
    negativeMajor = -35, negativeMid = -20, negativeMinor = -10
}