using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuSlot : MenuSlot
{
    [SerializeField] Minigame minigameScreenInThisSlot;
    public Minigame minigamePanel { get { return minigameScreenInThisSlot; } }

    public override void SetUpSlotImage()
    {
        GetComponent<Button>().GetComponent<Image>().sprite = minigameScreenInThisSlot.minigameMenuImage;
    }
}
