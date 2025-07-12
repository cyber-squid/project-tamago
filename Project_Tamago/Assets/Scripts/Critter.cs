using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Species;

public class Critter : MonoBehaviour
{
    Species currentSpecies;
    FriendStats status;
    int numberOfConvosHad;



    void Update()
    {
        
    }
}

public struct SpecificSpeciesData
{

    public Sprite
    enum DepletionRate // should hunger and happy depletion rates be separate?
    {
        fast,
        mid,
        slow
    }

    enum Personality 
    {
        laidback,
        friendly,
        shy
    }

    DepletionRate depletionRate;
    Personality personality;

    public void SetUp(SpeciesID species)
    {

    }
}

public class Species
{
    public enum SpeciesID
    {
        baby1,
        baby2,
        teen1,
        teen2,
        adult1,
        adult2
    }

    SpecificSpeciesData data;

}




// a class that contains all relevant info for a species (sprites for idling, happy, sad, depletion rates, etc)
// needs a function where, when the class is set with a species enum value (when starting or evolving), relevant data should update
// need to figure out how that info should be organised in more detail...