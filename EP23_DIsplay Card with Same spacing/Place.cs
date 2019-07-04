using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public Transform firstTrans;
    public Transform lastTrans;
    public GameObject[] cards;

    public Transform canvasTrans;//MARKER 卡牌的例子需要

    private void Start()
    {
        DisplaywithSpace();
    }

    private void DisplaywithSpace()
    {
        float space = (lastTrans.position.x - firstTrans.position.x) / (cards.Length - 1);

        for(int i = 0; i < cards.Length; i++)
        {
            //cards[i].transform.position = new Vector2(firstTrans.position.x + space * i, firstTrans.position.y);//MARKER 图片的例子

            GameObject newCard = Instantiate(cards[i], new Vector2(firstTrans.position.x + space * i, firstTrans.position.y), Quaternion.identity);//MARKER 卡牌的例子
            newCard.gameObject.transform.SetParent(canvasTrans);
        }
    }

}
