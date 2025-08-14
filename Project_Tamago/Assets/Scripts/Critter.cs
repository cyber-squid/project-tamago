using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Critter : MonoBehaviour
{
    [SerializeField] SpeciesData currentSpecies; // exposing to ui only for debugging!!!
    public SpeciesData CurrentSpecies { get { return currentSpecies; } }
    [SerializeField] SpeciesData[] possibleSpeciesToHatchAs;

    public FriendStats status;
    int numberOfConvosHad;

    string bonusEvolveRequirement;

    SpriteRenderer spriteRenderer;


    void Start()
    {
        // have a little animation play here first
        OnHatch();

        status = new FriendStats("Squishy");

        TimeTracker.OnHourPassed += DecreaseAllStats; 
    }


    void OnHatch()
    {
        currentSpecies = DecideHatchSpecies();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currentSpecies.characterIdleSprites[0];

        // have the player input their new buddy's name at this point

    }

    SpeciesData DecideHatchSpecies()
    {
        if (possibleSpeciesToHatchAs == null) 
        { Debug.Log("YOU DIDN'T SET STARTING SPECIES IN CRITTER SCRIPT INSPECTOR!!");  return null; }

        return possibleSpeciesToHatchAs[Random.Range(0, possibleSpeciesToHatchAs.Length)];
    }


    public void ToggleVisibility(bool isVisible)
    {
        spriteRenderer.enabled = isVisible;
    }

    void Update()
    {
        // should probably be moving around on the screen
    }

    void DecreaseAllStats()
    {
        status.ChangeStat(StatType.happy, StatChangeRange.negativeMinor);
        status.ChangeStat(StatType.hungry, StatChangeRange.negativeMinor);
        status.ChangeStat(StatType.health, StatChangeRange.negativeMinor);
    }
}







// a class that contains all relevant info for a species (sprites for idling, happy, sad, depletion rates, etc)
// needs a function where, when the class is set with a species enum value (when starting or evolving), relevant data should update
// need to figure out how that info should be organised in more detail...