using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeciesImmutableData : MonoBehaviour
{
    string speciesName;
    Sprite[] characterIdleSprites;



    SpeciesImmutableData[] availableEvolutions; // should be ordered by highest evo requirement
    int happinessEvolveRequirement; // this'll probably be a friendstats thing, start at 100 and go down 20 for every mistake? could be raised or lowered through convo
    string bonusEvolveRequirement; // a phrase that can be set depending on a condition you meet. eg 10 candies == "sweeties", good convos == "close friend"


    //GlobalStats.speciesGeneralData
    //Personality personality; this.availableEvolutions


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

public enum Personality
{
    laidback,
    friendly,
    shy
}