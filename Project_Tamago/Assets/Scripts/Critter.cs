using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
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
    public Animator animator;


    void Start()
    {
        // have a little animation play here first
        OnHatch();

        // this should eventually be fit  into a "name your buddy" sequence instead
        status = new FriendStats("Squishy");

        TimeTracker.OnHourPassed += DecreaseAllStats; 
    }

    void Update()
    {
        // should probably be moving around on the screen

        

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            status.ChangeStat(StatType.affection, StatChangeRange.positiveMajor);
            //StartEvolution();
        }
    }

    void IdleAnimation()
    {

    }

    void OnHatch()
    {
        currentSpecies = DecideHatchSpecies();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = currentSpecies.characterIdleSprites[0];

        animator = GetComponent<Animator>();

        // have the player input their new buddy's name at this point

    }

    SpeciesData DecideHatchSpecies()
    {
        if (possibleSpeciesToHatchAs == null) 
        { Debug.Log("YOU DIDN'T SET STARTING SPECIES IN CRITTER SCRIPT INSPECTOR!!");  return null; }

        return possibleSpeciesToHatchAs[Random.Range(0, possibleSpeciesToHatchAs.Length)];
    }

    void StartEvolution()
    {
        // should start a little animation here 
        currentSpecies.OnEvolution(this);
    }

    public void FinishEvolution(SpeciesData newSpecies)
    {
        currentSpecies = newSpecies;
        spriteRenderer.sprite = currentSpecies.characterIdleSprites[0];
    }


    public void ToggleVisibility(bool isVisible)
    {
        spriteRenderer.enabled = isVisible;
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