using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericActivity : MonoBehaviour
{
    public delegate void ActivityStarted();
    public static event ActivityStarted OnActivityStartedOrEnded;

    [SerializeField] internal GameObject mainScreen; 

    public void StartActivity()
    {
        OnActivityStartedOrEnded();
        ChangeScreen();
    }

    public void EndActivity()
    {
        ActivityFinishCleanup();
        OnActivityStartedOrEnded();
    }


    internal abstract void ChangeScreen();

    internal abstract void ActivityFinishCleanup();
}
