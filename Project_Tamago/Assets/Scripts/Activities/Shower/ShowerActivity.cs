using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowerActivity : GenericActivity
{
    [SerializeField] float showerCompletionAmount;
    float completionPerClick = 10;
    bool showerGameActive;

    [SerializeField] TMPro.TextMeshProUGUI text;

    internal override void ChangeScreen()
    {
        // shouldn't be showering more than once in 3 hours, bc otherwise you could just spam shower to get health up
        // that needs time working fully tho. so i'm gonna pretend that doesn't factor for now
        mainScreen.SetActive(true);
        showerGameActive = true;
        showerCompletionAmount = 0;
        text.text = "Keep clicking to wash!";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndActivity();
        }

        if (showerGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                showerCompletionAmount += completionPerClick;

                if (showerCompletionAmount > 100)
                {
                    GameStateManager.Instance.CritterRef.status.ChangeStat(StatType.health, 45); // showering should probably do a lot for health since not much else affects it
                    GameStateManager.Instance.CritterRef.animator.SetBool("somethingNiceHappened", true);
                    text.text = "Yay!";
                    showerGameActive = false;
                    StartCoroutine(ShowerAnimation());
                }
            }

            showerCompletionAmount -= completionPerClick * Time.deltaTime;
            
        }

        showerCompletionAmount = Mathf.Clamp(showerCompletionAmount, 0, 100);
    }

    IEnumerator ShowerAnimation()
    {
        // have buddy in a bath here
        yield return new WaitForSeconds(3.5f);
        // have them jump out here, let the anim play out here too.
        EndActivity();
        yield break;
    }

    internal override void ActivityFinishCleanup()
    {
        GameStateManager.Instance.CritterRef.animator.SetBool("somethingNiceHappened", false);
        mainScreen.SetActive(false);
    }
}
