using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlot : MonoBehaviour
{
    [HideInInspector] public MinimenuActivity minimenu;

    public void MenuButtonClicked()
    {
        minimenu.MenuButtonClicked(this);
    }
}

public class FoodMenuSlot : MenuSlot
{
    [SerializeField] FoodMenuObj foodInThisSlot;
    public FoodMenuObj foodItem { get { return foodInThisSlot; } }
}

public class PlayMenuSlot : MenuSlot
{
    [SerializeField] GameObject minigameInThisSlot;
    public GameObject minigameItem { get { return minigameInThisSlot; } }
}