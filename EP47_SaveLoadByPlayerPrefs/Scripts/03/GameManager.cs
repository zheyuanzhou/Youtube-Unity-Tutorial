using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPaused;

    public int coins, diamonds;
    public Text coinText, diamondText;

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
        coinText.text = coins.ToString();//MARKER UI Display
        diamondText.text = diamonds.ToString();//MARKER UI Display
    }



}
