using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// gives you all the current info on your buddy when you open it.
public class StatsMenuActivity : GenericActivity
{
    [SerializeField] SpriteRenderer critterPortrait;
    [SerializeField] TextMeshProUGUI critterName;
    [SerializeField] TextMeshProUGUI critterSpecies;

    [SerializeField] TextMeshProUGUI critterAge;
    [SerializeField] TextMeshProUGUI critterPersonality;

    [SerializeField] Slider hungryMeter;
    [SerializeField] Slider happyMeter;
    [SerializeField] Slider healthMeter;
    [SerializeField] Slider affectionMeter;

    private void Start()
    {
        mainScreen.SetActive(false);

        hungryMeter.maxValue = 100;
        happyMeter.maxValue = 100;
        healthMeter.maxValue = 100;
        affectionMeter.maxValue = 100;
    }

    // maybe name, species, personality and portrait are only set when critter calls OnEvolve?
    internal override void ChangeScreen()
    {
        UpdateCritterSpeciesInfo();
        UpdateCritterIndividualStatsInfo();

        mainScreen.SetActive(true);
    }

    void UpdateCritterSpeciesInfo()
    {
        critterPortrait.sprite = GameStateManager.Instance.CritterRef.CurrentSpecies.characterIdleSprites[0];

        critterName.text = GameStateManager.Instance.CritterRef.status.personalName;
        critterSpecies.text = "the " + GameStateManager.Instance.CritterRef.CurrentSpecies.name;

        critterPersonality.text = GameStateManager.Instance.CritterRef.status.personality.ToString();
    }

    void UpdateCritterIndividualStatsInfo()
    {
        critterAge.text = GameStateManager.Instance.CritterRef.status.age.ToString() + " yrs";

        hungryMeter.value = GameStateManager.Instance.CritterRef.status.hungry;
        happyMeter.value = GameStateManager.Instance.CritterRef.status.happy;
        healthMeter.value = GameStateManager.Instance.CritterRef.status.health;
        affectionMeter.value = GameStateManager.Instance.CritterRef.status.affection;
    }


    internal override void ActivityFinishCleanup()
    {
        mainScreen.SetActive(false);
    }
}
