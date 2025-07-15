using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Species Data")]
public class SpeciesData : ScriptableObject
{
    public string speciesName;
    public Sprite[] characterIdleSprites;

    public SpeciesData[] availableEvolutions; // should be ordered by highest evo requirement
    public int happinessEvolveRequirement; // this'll probably be a friendstats thing, start at 100 and go down 20 for every mistake? could be raised or lowered through convo
    public string bonusEvolveRequirement; // a phrase that can be set depending on a condition you meet. eg 10 candies == "sweeties", good convos == "close friend"


    public DepletionRate depletionRate;

    public void OnEvolution(Critter critter)
    {
        for (int i = 0; i < availableEvolutions.Length; i++) 
        {
            if (critter.status.happinessEvolveRequirement >= 
                availableEvolutions[i].happinessEvolveRequirement)
            {
                if (availableEvolutions[i].bonusEvolveRequirement != null)
                {
                    if (critter.status.bonusEvolveRequirement == availableEvolutions[i].bonusEvolveRequirement)
                    {
                        // evolve to this species
                    }
                    else break;
                }
                //evolve to this species
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

