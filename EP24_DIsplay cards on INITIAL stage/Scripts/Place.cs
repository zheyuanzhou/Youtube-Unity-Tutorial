using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public Transform firstTrans;
    public Transform lastTrans;
    public GameObject[] cards;

    public Transform worldCanvasTrans;

    private void Start()
    {
        DisplayCard();
    }

    private void DisplayCard() 
    {
        //MARKER space number is cards.length - 1
        //MARKER the while length of the display board is the lastPosition.x - firstPositon.x
        float space = (lastTrans.position.x - firstTrans.position.x) / (cards.Length - 1);

        for(int i = 0; i < cards.Length; i++)
        {
            //MARKER Display "sprite" with the same distance
            //cards[i].transform.position = new Vector2(firstTrans.position.x + space * i, firstTrans.position.y);

            //MARKER Display "Card UI Object" with the same distance
            GameObject newCard = Instantiate(cards[i], new Vector2(firstTrans.position.x + space * i, firstTrans.position.y), Quaternion.identity);
            //attch to worldCanvas as the parent each GameObject [card]
            newCard.transform.SetParent(worldCanvasTrans);
        }
    }



}
