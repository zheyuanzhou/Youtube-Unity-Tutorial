using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public Transform[] player01oddTrans;
    public Transform[] player01evenTrans;//array: a collection of the the same type store together
    public Transform[] player02oddTrans;
    public Transform[] player02evenTrans;

    public Transform worldCanvasTrans;

    private void Start()
    {
        DisplayCard(GameManager.instance.player01Cards, player01oddTrans, player01evenTrans);
        DisplayCard(GameManager.instance.player02Cards, player02oddTrans, player02evenTrans);
    }

    void DisplayCard(List<GameObject> playerCards, Transform[] oddTrans, Transform[] evenTrans) //CORE player 01(Parameter: playerCards List , playerEnveTrans, playerOddTrans)
    {
        if(playerCards.Count % 2 == 0)
        {
            //Even position : 4
            for(int i = 0; i < 4; i++)// cards.length is 4
            {
                int randomNumber = Random.Range(0, playerCards.Count);
                GameObject newCard = Instantiate(playerCards[randomNumber], new Vector2(evenTrans[i].position.x, evenTrans[i].position.y), Quaternion.identity);
                newCard.transform.SetParent(worldCanvasTrans);
            }

        }
        else
        {
            //Odd position : 3
            for (int i = 0; i < 3; i++)// cards.length is 4
            {
                int randomNumber = Random.Range(0, playerCards.Count);
                GameObject newCard = Instantiate(playerCards[randomNumber], new Vector2(oddTrans[i].position.x, oddTrans[i].position.y), Quaternion.identity);
                newCard.transform.SetParent(worldCanvasTrans);
            }
        }


    }


}
