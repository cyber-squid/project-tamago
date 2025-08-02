using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// food screen should display a few options (buttons) for food, effect on the tama depends on the food.
public class FoodMenuActivity : GenericActivity
{
    [SerializeField] GameObject foodMenu;
    [SerializeField] GameObject confirmBox;
    [SerializeField] GameObject backButton;
    [SerializeField] FoodMenuSlot[] menuButtonSlots;
    FoodMenuObj currentSelectedFood;

    private void Start()
    {
        for (int i = 0; i < menuButtonSlots.Length; i++) 
        { 
            menuButtonSlots[i].foodMenuActivity = this;

            Button button = menuButtonSlots[i].gameObject.GetComponent<Button>();
            button.onClick.AddListener(menuButtonSlots[i].OpenConfirmationBox);
        }

        foodMenu.SetActive(false);
    }

    internal override void ChangeScreen()
    {
        // activate food options page

        foodMenu.SetActive(true);

        // uhh how do i make this less goofy
        //GameStateManager.Instance.CritterReference.status.ChangeStat(StatType.hungry, StatChangeRange.positiveMid);
        //Debug.Log("fed buddy!");
    }


    public void OpenConfirmationBox(FoodMenuSlot clickedSlot)
    {
        currentSelectedFood = clickedSlot.foodItem;
        confirmBox.SetActive(true);

        backButton.SetActive(false);
        for (int i = 0; i < menuButtonSlots.Length; i++) { menuButtonSlots[i].gameObject.SetActive(false); }
    }

    public void ConfirmAndEatSelectedFood()
    {
        Feed();
        CloseConfirmationBox();
        // probably want to briefly turn the menu off and play an anim of lil guy eating here.
    }

    public void CloseConfirmationBox()
    {
        currentSelectedFood = null;
        confirmBox.SetActive(false);

        backButton.SetActive(true);
        for (int i = 0; i < menuButtonSlots.Length; i++) { menuButtonSlots[i].gameObject.SetActive(true); }
    }

    public void Feed()
    {
        if (currentSelectedFood == null) { return; }

        GameStateManager.Instance.CritterReference.status.ChangeStat(StatType.hungry, currentSelectedFood.satisfyingness);
        GameStateManager.Instance.CritterReference.status.ChangeStat(StatType.happy, currentSelectedFood.deliciousness);
        GameStateManager.Instance.CritterReference.status.ChangeStat(StatType.health, currentSelectedFood.healthiness);
        GameStateManager.Instance.CritterReference.status.ChangeStat(StatType.affection, currentSelectedFood.caring);

        Debug.Log("fed buddy!");
    }


    internal override void ActivityFinishCleanup()
    {
        foodMenu.SetActive(false);
    }
}
