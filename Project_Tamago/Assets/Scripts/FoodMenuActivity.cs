using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// food screen should display a few options (buttons) for food, effect on the tama depends on the food.
public class FoodMenuActivity : GenericActivity
{
    [SerializeField] GameObject foodMenu;

    internal override void ChangeScreen()
    {
        // activate food options page

        foodMenu.SetActive(true);



        // uhh how do i make this less goofy
        //GameStateManager.Instance.CritterReference.status.ChangeStat(StatType.hungry, StatChangeRange.positiveMid);
        //Debug.Log("fed buddy!");
    }




    internal override void ActivityFinishCleanup()
    {
        foodMenu.SetActive(false);
    }
}
