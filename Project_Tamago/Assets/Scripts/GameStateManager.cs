using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// handles updating the global stats and game state, and contains a globally accessible ref to the tama.
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    public Critter CritterRef { get { return critterRef; } }
    [SerializeField] Critter critterRef;

    [SerializeField] Button[] allActivityButtons;
    bool activityIsInProgress = false;

    private void Start()
    {
        if (Instance != null)
        {
            Instance.gameObject.SetActive(false);
            Debug.LogWarning("Hey! Why do you have multiple gamestatemanagers in here?!");
        }
        Instance = this;

        GenericActivity.OnActivityStartedOrEnded += SetActivityState;
    }

    void Update()
    {
        TimeTracker.UpdateElapsedTime(this);
    }

    void SetActivityState()
    {
        activityIsInProgress = !activityIsInProgress;

        for (int i = 0; i < allActivityButtons.Length; i++) 
        { allActivityButtons[i].gameObject.SetActive(!activityIsInProgress); }

        Debug.Log("activity open: " + activityIsInProgress);
    }
}

public class SaveManager
{

}