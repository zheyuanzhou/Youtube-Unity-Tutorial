using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card[] cards;
    public GameObject[] gameCards;

    public Text manaText;
    public Text attackText;
    public Text healthText;

    public Text nameText;
    public Text descriptionText;

    public Image cardImage;
    public Image cardBackgroundImage;

    public Text cardClass;

    public Color humanColor;
    public Color orcColor;
    public Color undeadColor;
    public Color nightElfColor;

    //TODO CardColor

    private void Awake()
    {
        for(int i =0; i < cards.Length; i++)
        {
            gameCards[i].transform.Find("Mana").GetChild(0).GetComponent<Text>().text = cards[i].cardMana.ToString();
            gameCards[i].transform.Find("Attack").GetChild(0).GetComponent<Text>().text = cards[i].cardAttack.ToString();
            gameCards[i].transform.Find("Health").GetChild(0).GetComponent<Text>().text = cards[i].cardHealth.ToString();
            gameCards[i].transform.Find("NameBoard").GetChild(0).GetComponent<Text>().text = cards[i].cardName;
            gameCards[i].transform.Find("DescriptionBoard").GetChild(0).GetComponent<Text>().text = cards[i].cardDescription;
            gameCards[i].transform.Find("CardProfile_Mask").GetChild(1).GetComponent<Image>().sprite = cards[i].cardSprite;
            gameCards[i].transform.Find("CardProfile_Mask").GetChild(0).GetComponent<Image>().sprite = cards[i].cardBackground;

            gameCards[i].transform.Find("Class").GetChild(0).GetComponent<Text>().text = cards[i].cardClass.ToString();
        
            if(cards[i].cardClass.ToString() == "Human")
            {
                gameCards[i].GetComponent<Image>().color = humanColor;
            }
            if (cards[i].cardClass.ToString() == "Orc")
            {
                gameCards[i].GetComponent<Image>().color = orcColor;
            }
            if (cards[i].cardClass.ToString() == "UnDead")
            {
                gameCards[i].GetComponent<Image>().color = undeadColor;
            }
            if (cards[i].cardClass.ToString() == "NightElf")
            {
                gameCards[i].GetComponent<Image>().color = nightElfColor;
            }

        }
    }


    //MARKER Episode Single Card Creation
    //manaText.text = cards[0].cardMana.ToString();
    //attackText.text = cards[0].cardAttack.ToString();
    //healthText.text = cards[0].cardHealth.ToString();

    //cardImage.sprite = cards[0].cardSprite;
    //nameText.text = cards[0].cardName;
    //descriptionText.text = cards[0].cardDescription;

    //cardBackgroundImage.sprite = cards[0].cardBackground;

}
