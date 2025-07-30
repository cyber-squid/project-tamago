using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public static class TimeTracker
{
    // need to keep track of current time and how long it's been since specific things have occured.
    public static float elapsedTime {  get; private set; }

    public static int previousHour;
    public static int previousDay;

    public delegate void HourPassed();
    public static event HourPassed OnHourPassed;

    static int decreaseStatsTime = 40; // this should be the tama's depletion rate, just here for testing

    // right now we just need a decreasing timer, and once enough time (an hour) has elapsed,
    // it should probably send an event out, for things like hunger and happiness 
    public static void UpdateElapsedTime(GameStateManager manager) // i don't want anyone else calling this func but idk how else to do it other than this goofiness
    {
        if (previousDay < DateTime.Now.Day)
        {
            // MOOOM IM GETTING AHEAD OF MYSELF AGAIN
        }

        /* i think we'll have to handle this different for time changes. 
         * older tamagotchis don't actually deplete meters if you pass several hours, it's just a time adjustment.
         * but if you completely close the game, it should account for hours that passed since you last opened it
         * 
         * the internal timer should probably be totally separate from the display timer?? which would just sync with your system time
         * internal timer should NOT be influenced by a change in time zone or adjusting system time 
         * but i feel like you should still be able to speed things along or change your tama's bed routine if you choose
        if (previousHour < DateTime.Now.Hour)
        {
            int differenceInHours = DateTime.Now.Hour - previousHour;
            for (int i = 0; i < differenceInHours; i++) { OnHourPassed(); } 
            previousHour = DateTime.Now.Hour;
        }*/


        elapsedTime += Time.deltaTime;

        // test code :)
        if (elapsedTime > decreaseStatsTime) 
        {
            // event call for decreasing stats
            OnHourPassed();
            elapsedTime = 0;
        }


    }

}
