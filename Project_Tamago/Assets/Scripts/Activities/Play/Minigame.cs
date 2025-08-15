using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Minigame : MonoBehaviour
{
    public Sprite minigameMenuImage;
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
        GameStateManager.Instance.CritterRef.animator.SetBool("somethingNiceHappened", false);
        playMenu.FinishMinigame();
    }
}
