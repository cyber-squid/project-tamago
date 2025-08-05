using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuSlot : MenuSlot
{
    [SerializeField] Minigame minigameScreenInThisSlot;
    public Minigame minigamePanel { get { return minigameScreenInThisSlot; } }
}
