using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenuSlot : MonoBehaviour
{

    public FoodMenuObj foodItem; // pls set in inspector!
    [HideInInspector] public FoodMenuActivity foodMenuActivity;



    public void OpenConfirmationBox()
    {
        foodMenuActivity.OpenConfirmationBox(this);
    }

    // i think the easiest way to have the func i want to call listen for a button click without exposing it to
    // the rest of the scripts is this, where you set it up on awake, which necessitates the food menu being open
    // before the game fully starts. which i hate, and think is gross, and i think the func being exposed is
    //  honestly the lesser evil, so i will do that instead for now, but may come back to this if i have to.

    // okay i wrote that all before i realised i need code to set up the button images with the sprites of food 
    // before the game even starts. but i also figured out a way to call a 
    /*void Awake()
    {
        Button foodMenuButton = GetComponent<Button>();
        if (foodMenuButton != null) { foodMenuButton.onClick.AddListener(OpenConfirmationBox); }
    }*/
}
