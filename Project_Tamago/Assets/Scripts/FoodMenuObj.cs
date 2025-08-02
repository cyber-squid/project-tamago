using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Object")]
public class FoodMenuObj : ScriptableObject
{
    public Sprite foodImage;

    public StatChangeRange satisfyingness; // how well fed does this make your tama?
    public StatChangeRange deliciousness; // how happy?
    public StatChangeRange healthiness; // etc etc
    public StatChangeRange caring;
}
