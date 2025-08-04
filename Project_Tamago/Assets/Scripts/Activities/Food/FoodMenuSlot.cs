using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenuSlot : MenuSlot
{
    [SerializeField] FoodMenuObj foodInThisSlot;
    public FoodMenuObj foodItem { get { return foodInThisSlot; } }
}