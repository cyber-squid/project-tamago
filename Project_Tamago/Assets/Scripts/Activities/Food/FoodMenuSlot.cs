using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenuSlot : MenuSlot
{
    [SerializeField] FoodMenuObj foodInThisSlot;
    public FoodMenuObj foodItem { get { return foodInThisSlot; } }

    public override void SetUpSlotImage()
    {
        GetComponent<Button>().GetComponent<Image>().sprite = foodInThisSlot.foodImage;
    }
}