using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private bool isPlayer01;//User//The default value of this variable is FALSE
    [SerializeField] private bool isPlayer02;//AI/Enemy

    public List<GameObject> player01Cards = new List<GameObject>();//List is dynamic "array". Array has the fixed number(length)
    public List<GameObject> player02Cards = new List<GameObject>();

    public GameObject[] cards;//card pool(All of the game cards in the pool/system)

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        RandomStart();

        ArrangeCardAtBeginning(isPlayer01, player01Cards);
        ArrangeCardAtBeginning(isPlayer02, player02Cards);
    }

    void RandomStart()//50% player move first or AI move first
    {
        int randomNumber = Random.Range(0, 100);//0-99 "not include" 100

        if(randomNumber < 50)
        {
            isPlayer01 = true;//player 01 move first
        }
        else
        {
            isPlayer02 = true;
        }
    }

    //MARKER if the player X move first, he only get 3 cards
    //MARKER another player move later, but he can get 4.
    void ArrangeCardAtBeginning(bool player, List<GameObject> playerCards)
    {


        if (player)//isPlayer02 or isPlayer01
        {
            for (int i = 0; i < 3; i++)
            {
                int randomNumber = Random.Range(0, cards.Length);
                playerCards.Add(cards[randomNumber]);//player02Cards/player01Cards
            }
        } 
        else 
        {
            for (int i = 0; i < 4; i++)
            {
                int randomNumber = Random.Range(0, cards.Length);
                playerCards.Add(cards[randomNumber]);
            }
        }

        Debug.Log("Player " + player + "---" + playerCards.Count);
    }


}
