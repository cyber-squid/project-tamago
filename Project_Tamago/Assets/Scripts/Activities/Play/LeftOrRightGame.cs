using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeftOrRightGame : Minigame
{
    [SerializeField] SpriteRenderer leftLight;
    [SerializeField] SpriteRenderer rightLight;

    bool isLeft;
    bool inputTaken = false;

    internal override void BeginMinigame()
    {
        Debug.Log("game open");
        isLeft = (Random.Range(0, 2) == 0);

        leftLight.color = Color.white;
        rightLight.color = Color.white;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { ExitGame(); }

        if (!inputTaken)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("yurr");
                if (isLeft)
                {
                    leftLight.color = Color.green;
                    StartCoroutine(DisplayResults());
                    OnWinMinigame();
                }
                else
                {
                    leftLight.color = Color.red;
                    StartCoroutine(DisplayResults());
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("bleeh");
                if (!isLeft)
                {
                    rightLight.color = Color.green;
                    StartCoroutine(DisplayResults());
                    OnWinMinigame();
                }
                else
                {
                    rightLight.color = Color.red;
                    StartCoroutine(DisplayResults());
                }
            }
        }

    }

    IEnumerator DisplayResults()
    {
        yield return new WaitForSeconds(2.25f);
        ExitGame();
    }


    internal override void OnWinMinigame()
    {
        GameStateManager.Instance.CritterRef.status.ChangeStat(StatType.happy, StatChangeRange.positiveMid);
        GameStateManager.Instance.CritterRef.animator.SetBool("somethingNiceHappened", true);
    }

}
