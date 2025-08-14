using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Species Data")]
public class SpeciesData : ScriptableObject
{
    public string speciesName;
    public Sprite[] characterIdleSprites;
    public Sprite[] characterTalkSprites = new Sprite[11]; // number of expressions there are. how to get from the enum??

    public SpeciesData[] availableEvolutions; // should be ordered by highest evo requirement
    public int affectionEvolveRequirement; // this'll probably be a friendstats thing, start at 100 and go down 20 for every mistake? could be raised or lowered through convo
    public string bonusEvolveRequirement; // a phrase that can be set depending on a condition you meet. eg 10 candies == "sweeties", good convos == "close friend"


    public DepletionRate depletionRate;

    public void OnEvolution(Critter critter)
    {
        for (int i = 0; i < availableEvolutions.Length; i++) 
        {
            if (critter.status.affection >= 
                availableEvolutions[i].affectionEvolveRequirement)
            {
                if (availableEvolutions[i].bonusEvolveRequirement != "")
                {
                    if (critter.status.currentBonusEvolvePassword == availableEvolutions[i].bonusEvolveRequirement)
                    {
                        // evolve to this species
                        critter.FinishEvolution(availableEvolutions[i]);
                    }
                    else break;
                }
                //evolve to this species
                critter.FinishEvolution(availableEvolutions[i]);
                break;
            }
        }
    }
}

public enum DepletionRate // should hunger and happy depletion rates be separate?
{
    fast,
    mid,
    slow
}

public enum TalkExpression
{
    smiling,
    joy,
    embarrassedSmiling,
    openMouth,
    confused,
    shocked,
    expressionless,
    frowning,
    upset,
    pained,
    frustrated,
    disinterested
}

