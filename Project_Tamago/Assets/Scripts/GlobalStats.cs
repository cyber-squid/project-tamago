using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// unity sucks and needs any code to somehow, someway relate to a monobehaviour. 
// will probably have a separate GameStateManager monobehaviour that updates this info and does stuff with it. 
public static class GlobalStats
{
    // need to keep track of current time and how long it's been since specific things have occured.
    public static int elapsedSavefileTime {  get; private set; }
    public static int timeSinceLastChecked { get; private set; }


    //OOOUGHGH im restarted
    public static void UpdateElapsedTime(GameStateManager manager)
    {
        elapsedSavefileTime += (int)Time.deltaTime;
        // not sure how to check what hour it is or even if we ought to...
    }
}
