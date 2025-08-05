using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// gives you all the current info on your buddy when you open it.
public class StatsMenuActivity : GenericActivity
{
    [SerializeField] GameObject menuPanel;
    Critter critterInfo;

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
        menuPanel.SetActive(false);
        critterInfo = FindObjectOfType<Critter>().GetComponent<Critter>();

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

        menuPanel.SetActive(true);
    }

    void UpdateCritterSpeciesInfo()
    {
        critterPortrait.sprite = critterInfo.CurrentSpecies.characterIdleSprites[0];

        critterName.text = critterInfo.status.personalName;
        critterSpecies.text = "the " + critterInfo.CurrentSpecies.name;

        critterPersonality.text = critterInfo.status.personality.ToString();
    }

    void UpdateCritterIndividualStatsInfo()
    {
        critterAge.text = critterInfo.status.age.ToString() + " yrs";

        hungryMeter.value = critterInfo.status.hungry;
        happyMeter.value = critterInfo.status.happy;
        healthMeter.value = critterInfo.status.health;
        affectionMeter.value = critterInfo.status.affection;
    }


    internal override void ActivityFinishCleanup()
    {
        menuPanel.SetActive(false);
    }
}
