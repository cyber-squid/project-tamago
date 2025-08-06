using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuSlot : MonoBehaviour
{
    [HideInInspector] public MinimenuActivity minimenu;

    public void MenuButtonClicked()
    {
        minimenu.MenuButtonClicked(this);
    }

    public abstract void SetUpSlotImage();
}
