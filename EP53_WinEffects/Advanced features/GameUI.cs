using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int coinNum;
    public Text timerText;
    public Text coinText;

    private bool isTimeouts;

    public GameObject winCanvas;
    public GameObject[] stars;
    private bool canClick;

    [SerializeField] private int highestScore;
    public Text highestScoreText;
    public Text scoreText;

    private void Start()
    {
        coinText.text = coinNum.ToString();
    }

    private void Update()
    {
        Timer();

        if(isTimeouts)
        {
            StartCoroutine(ShowStarsCo());
        }
    }

    //MARKER This funrction will be called on Event Button Listener
    public void PressButton()
    {
        if (!isTimeouts)
        {
            coinNum++;
            coinText.text = coinNum.ToString();
        }
    }

    //MARKER This function will be called on Update Function
    private void Timer()
    {
        if (isTimeouts == false)
        {
            timer -= Time.deltaTime;
            timerText.text = "0" + timer.ToString("F2");

            if (timer <= 0)//TIME Expire
            {
                isTimeouts = true;
                timerText.text = "00:00";  
            }
        }
    }

    IEnumerator ShowStarsCo()
    {
        DisplayScore();
        winCanvas.SetActive(true);

        if (coinNum < 4)
        {
            stars[0].SetActive(true);//SHOW first star

            yield return new WaitForSeconds(1.0f);//MARKER After one second, you can press the restart button to play again
            canClick = true;
        }
        else if (coinNum < 8)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);//Show Second star

            yield return new WaitForSeconds(1.0f);
            canClick = true;
        }
        else
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);//SHOW FULL STARS

            yield return new WaitForSeconds(1.0f);
            canClick = true;
        }
    }

    public void RestartButton()
    {
        if (canClick)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("Highest", highestScore);//MARKER SAVE
        }
    }

    private void DisplayScore()
    {
        if(coinNum > PlayerPrefs.GetInt("Highest"))//If our result is greater than record, 
        {
            highestScore = coinNum;//HighestScore should be assigned to our coins Result
        }
        else
        {
            highestScore = PlayerPrefs.GetInt("Highest");//MARKER Once our result is less than record, HighestScore still equal to the Saving data
        }

        highestScoreText.text = highestScore.ToString();//Text.text
        scoreText.text = coinNum.ToString();//Text.text
    }


}
