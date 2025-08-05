using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    [HideInInspector] public PlayMenuActivity playMenu;
    int successiveTimesWon;

    private void OnEnable()
    {
        BeginMinigame();
    }

    internal abstract void BeginMinigame();

    internal abstract void OnWinMinigame();

    internal virtual void ExitGame()
    {
        playMenu.FinishMinigame();
    }
}
