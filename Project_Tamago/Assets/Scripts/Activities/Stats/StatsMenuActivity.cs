using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenuActivity : GenericActivity
{
    [SerializeField] GameObject menuPanel;
    Critter critterInfo;

    [SerializeField] SpriteRenderer critterPortrait;
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

    internal override void ChangeScreen()
    {
        menuPanel.SetActive(true);

        critterPortrait.sprite = critterInfo.CurrentSpecies.characterIdleSprites[0];

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
