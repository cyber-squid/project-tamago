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
