using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// unity sucks and needs any code to somehow, someway relate to a monobehaviour. 
// will probably have a separate GameStateManager monobehaviour that updates this info and does stuff with it. 

public static class GlobalStats
{

    public const int LENGTH_OF_AN_HOUR = 3600;

    // need to keep track of current time and how long it's been since specific things have occured.
    public static float elapsedTime {  get; private set; }

    public static int previousHour;
    public static int previousDay;

    public delegate void HourPassed();
    public static event HourPassed OnHourPassed;

    static int decreaseStatsTime = 2;

    // right now we just need a decreasing timer, and once enough time (an hour) has elapsed,
    // it should probably send an event out, for things like hunger and happiness 
    public static void UpdateElapsedTime(GameStateManager manager) // i don't want anyone else calling this func but idk how else to do it other than this goofiness
    {
        if (previousDay < DateTime.Now.Day)
        {
            // MOOOM IM GETTING AHEAD OF MYSELF AGAIN
        }

        /*
        if (previousHour < DateTime.Now.Hour)
        {
            int differenceInHours = DateTime.Now.Hour - previousHour;
            for (int i = 0; i < differenceInHours; i++) { OnHourPassed(); } // add event call to update game here
            previousHour = DateTime.Now.Hour;
        }*/


        elapsedTime += Time.deltaTime;

        Debug.Log("time passed: " + elapsedTime);
        // test code :)
        if (elapsedTime > decreaseStatsTime) 
        {
            // event call for decreasing stats
            OnHourPassed();
            elapsedTime = 0;
        }


    }

}
