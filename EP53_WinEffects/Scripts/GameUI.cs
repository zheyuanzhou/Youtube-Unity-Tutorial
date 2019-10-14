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

    private void Start()
    {
        coinText.text = coinNum.ToString();
    }

    private void Update()
    {
        Timer();
    }

    //MARKER This funrction will be called on Event Button Listener
    public void PressButton()
    {
        if(!isTimeouts)
        {
            coinNum++;
            coinText.text = coinNum.ToString();
        }
    }

    //MARKER This function will be called on Update Function
    private void Timer()
    {
        if(isTimeouts == false)
        {
            timer -= Time.deltaTime;
            timerText.text = "0" + timer.ToString("F2");

            if (timer <= 0)//TIME Expire
            {
                isTimeouts = true;
                timerText.text = "00:00";

                StartCoroutine(ShowStarsCo());
            }
        }
    }

    IEnumerator ShowStarsCo()
    {
        winCanvas.SetActive(true);

        if(coinNum < 4)
        {
            stars[0].SetActive(true);//SHOW first star

            yield return new WaitForSeconds(1.0f);//MARKER After one second, you can press the restart button to play again
            canClick = true;
        } 
        else if(coinNum < 8)
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
        if(canClick)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
