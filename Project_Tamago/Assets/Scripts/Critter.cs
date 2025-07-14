using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Critter : MonoBehaviour
{
    SpeciesImmutableData currentSpecies;
    public FriendStats status;
    int numberOfConvosHad;

    string bonusEvolveRequirement;

    void Update()
    {
        // should probably be moving around on the screen
        
    }

    // 
}







// a class that contains all relevant info for a species (sprites for idling, happy, sad, depletion rates, etc)
// needs a function where, when the class is set with a species enum value (when starting or evolving), relevant data should update
// need to figure out how that info should be organised in more detail...