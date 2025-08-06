using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// food screen should display a few options (buttons) for food, effect on the tama depends on the food.
public class FoodMenuActivity : MinimenuActivity
{

    FoodMenuObj currentSelectedFood;
    [SerializeField] GameObject confirmChoiceBox;
    [SerializeField] TMPro.TextMeshProUGUI confirmChoiceText;

    internal override void ChangeScreen()
    {
        mainScreen.SetActive(true);
    }

    // time to open up the confirm selection box
    public override void MenuButtonClicked(MenuSlot clickedSlot)
    {
        FoodMenuSlot slot = clickedSlot as FoodMenuSlot;

        if (slot != null)
        {
            currentSelectedFood = slot.foodItem;
            confirmChoiceText.text = $"Eat {currentSelectedFood.name}?";
            confirmChoiceBox.SetActive(true);

            backButton.SetActive(false); // again, don't want the player clicking those right now
            for (int i = 0; i < menuButtonSlots.Length; i++) { menuButtonSlots[i].gameObject.SetActive(false); }
        }
    }


    // these two funcs are called from buttons that they've been assigned to in the inspector,
    // which is the easiest way to do it without technically hard coding it, but it's not really ideal
    // since it's not obvious i think that they get called that way. 
    public void ConfirmAndEatSelectedFood()
    {
        Feed();
        CloseConfirmationBox();
        // probably want to briefly turn the menu off and play an anim of lil guy eating here.
    }

    public void CloseConfirmationBox()
    {
        currentSelectedFood = null;
        confirmChoiceBox.SetActive(false);

        backButton.SetActive(true);
        for (int i = 0; i < menuButtonSlots.Length; i++) { menuButtonSlots[i].gameObject.SetActive(true); }
    }

    public void Feed()
    {
        if (currentSelectedFood == null) { return; }

        GameStateManager.Instance.CritterRef.status.ChangeStat(StatType.hungry, currentSelectedFood.satisfyingness);
        GameStateManager.Instance.CritterRef.status.ChangeStat(StatType.happy, currentSelectedFood.deliciousness);
        GameStateManager.Instance.CritterRef.status.ChangeStat(StatType.health, currentSelectedFood.healthiness);
        GameStateManager.Instance.CritterRef.status.ChangeStat(StatType.affection, currentSelectedFood.caring);

        Debug.Log("fed buddy!");
    }


    internal override void ActivityFinishCleanup()
    {
        mainScreen.SetActive(false);
    }

}
