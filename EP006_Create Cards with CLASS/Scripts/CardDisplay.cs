using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card[] cards;
    public GameObject[] gameCards;//step 3

    public Text manaText;
    public Text attText;
    public Text healthText;

    public Text nameText;
    public Text descriptionText;

    public Image cardImage;
    public Image cardBackground;//step 2

    //step 3
    public Text cardClass;

    public Color humanColor;
    public Color orcColor;
    public Color undeadColor;
    public Color nightElfColor;

    public void Awake()
    {
        //Marker single card Display
        //manaText.text = cards[0].cardMana.ToString();
        //attText.text = cards[0].cardAtt.ToString();
        //healthText.text = cards[0].cardHealth.ToString();

        //nameText.text = cards[0].cardName;
        //descriptionText.text = cards[0].cardDescription;

        //cardImage.sprite = cards[0].cardSprite;
        //cardBackground.sprite = cards[0].cardBackground;


        //step 2
        for (int i = 0; i < cards.Length; i++)
        {
            gameCards[i].transform.Find("Mana").GetChild(0).GetComponent<Text>().text = cards[i].cardMana.ToString();
            gameCards[i].transform.Find("Attack").GetChild(0).GetComponent<Text>().text = cards[i].cardAtt.ToString();
            gameCards[i].transform.Find("Health").GetChild(0).GetComponent<Text>().text = cards[i].cardHealth.ToString();
            gameCards[i].transform.Find("Name Banner").GetChild(0).GetComponent<Text>().text = cards[i].cardName;
            gameCards[i].transform.Find("Description Banner").GetChild(0).GetComponent<Text>().text = cards[i].cardDescription;
            gameCards[i].transform.Find("Card Image").GetChild(1).GetComponent<Image>().sprite = cards[i].cardSprite;
            gameCards[i].transform.Find("Card Image").GetChild(0).GetComponent<Image>().sprite = cards[i].cardBackground;

            //step3
            gameCards[i].transform.Find("Class Banner").GetChild(0).GetComponent<Text>().text = cards[i].cardClass.ToString();

            if(cards[i].cardClass.ToString() == "Human")
            {
                gameCards[i].GetComponent<Image>().color = humanColor;
            }
            if (cards[i].cardClass.ToString() == "Orc")
            {
                gameCards[i].GetComponent<Image>().color = orcColor;
            }
            if (cards[i].cardClass.ToString() == "Undead")
            {
                gameCards[i].GetComponent<Image>().color = undeadColor;
            }
            if (cards[i].cardClass.ToString() == "NightElf")
            {
                gameCards[i].GetComponent<Image>().color = nightElfColor;
            }

        }

        //Debug.Log(gameCards[0].transform.Find("Mana").GetChild(0).GetComponent<Text>().text);

        //manaText.text = cards[0].cardMana.ToString();
        //attText.text = cards[0].cardAtt.ToString();
        //healthText.text = cards[0].cardHealth.ToString();

        //nameText.text = cards[0].cardName;
        //descriptionText.text = cards[0].cardDescription;

        //cardImage.sprite = cards[0].cardSprite;
        //cardBackground.sprite = cards[0].cardBackground;
    }

    //step 3

}
