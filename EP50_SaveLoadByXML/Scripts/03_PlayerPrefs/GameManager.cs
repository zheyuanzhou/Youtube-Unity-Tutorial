using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPaused;//When the variabel is false, the game continue

    public int coins, diamonds;//WE can use GameManager.instance.coin to get access from other script
    public Text coinText, diamondText;

    //MARKER ALL ENEMIES IN THIS GAME
    public List<Bat> bats = new List<Bat>();

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

    private void Update()
    {
        coinText.text = coins.ToString();//MARKER UI display
        diamondText.text = diamonds.ToString();
    }

}
