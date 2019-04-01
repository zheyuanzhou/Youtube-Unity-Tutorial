using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Card
{

    public int cardMana;
    public int cardAtt;
    public int cardHealth;

    public string cardName;
    [TextArea(1,5)]
    public string cardDescription;

    public Sprite cardSprite;

    //step 2
    public Sprite cardBackground;
    //public string cardClass;//enum

    //step 3
    public enum CardClass
    {
        Human,
        Orc,
        Undead,
        NightElf
    }

    public CardClass cardClass;


}
