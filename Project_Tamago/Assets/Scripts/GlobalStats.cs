using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// unity sucks and needs any code to somehow, someway relate to a monobehaviour. 
// will probably have a separate GameStateManager monobehaviour that updates this info and does stuff with it. 

public static class GlobalStats
{

    public static SpeciesGeneralData speciesGeneralData { get; private set; }

    public const int LENGTH_OF_AN_HOUR = 3600;

    // need to keep track of current time and how long it's been since specific things have occured.
    public static int elapsedSavefileTime {  get; private set; }
    public static int timeSinceLastHour { get; private set; }
    public static int timeSinceTimeWasLastChecked { get; private set; }



    // okay i was getting ahead of myself before
    // right now we just need a decreasing timer, and once enough time (an hour) has elapsed,
    // it should probably send an event out, for things like hunger and happiness 
    public static void UpdateElapsedTime(GameStateManager manager) // i don't want anyone else calling this func but idk how else to do it other than this goofiness
    {
        int f = DateTime.Now.Hour;
        elapsedSavefileTime += (int)Time.deltaTime;
        // not sure how to check what hour it is or even if we ought to...
    }

}
