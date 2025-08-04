using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class MinimenuActivity : GenericActivity
{

    [SerializeField] internal GameObject menuPanel;
    [SerializeField] internal GameObject backButton;
    [SerializeField] internal MenuSlot[] menuButtonSlots;

    void Start()
    {
        for (int i = 0; i < menuButtonSlots.Length; i++)
        {
            menuButtonSlots[i].minimenu = this;

            Button button = menuButtonSlots[i].gameObject.GetComponent<Button>();
            button.onClick.AddListener(menuButtonSlots[i].MenuButtonClicked);
        }

        menuPanel.SetActive(false);
    }

    public abstract void MenuButtonClicked(MenuSlot slot);

}
