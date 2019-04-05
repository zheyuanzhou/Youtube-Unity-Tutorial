using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card[] cards;

    public Text manaText;
    public Text attackText;
    public Text healthText;

    public Text nameText;
    public Text descriptionText;

    public Image cardImage;

    //TODO CardColor,CardBG and class

    private void Awake()
    {
        manaText.text = cards[0].cardMana.ToString();
        attackText.text = cards[0].cardAttack.ToString();
        healthText.text = cards[0].cardHealth.ToString();

        cardImage.sprite = cards[0].cardSprite;
        nameText.text = cards[0].cardName;
        descriptionText.text = cards[0].cardDescription;
    }
}
