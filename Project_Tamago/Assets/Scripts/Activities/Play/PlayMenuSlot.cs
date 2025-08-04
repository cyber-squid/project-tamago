using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuSlot : MenuSlot
{
    [SerializeField] GameObject minigameInThisSlot;
    public GameObject minigameItem { get { return minigameInThisSlot; } }
}
