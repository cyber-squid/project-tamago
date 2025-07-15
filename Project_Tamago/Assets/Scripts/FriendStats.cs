using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendStats 
{
    string nickname;

    int age;

    Personality personality;

    int hungry;
    int happy;
    int health;
    int affection;

    public int happinessEvolveRequirement;
    public string bonusEvolveRequirement;

}

public enum Personality
{
    laidback,
    friendly,
    shy
}