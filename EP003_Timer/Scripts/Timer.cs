using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private float maxTime;
    [SerializeField] private float currentTime;
    [SerializeField] private Text timeDisplay;

    [SerializeField] private bool isGameOver;

    [SerializeField] private Animator gameOverAnim;

    private void Awake()
    {
        isGameOver = false;

        currentTime = maxTime;
        timeDisplay.text = maxTime.ToString();//ToString: float transfer to string type
    }

    private void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            timeDisplay.text = ((int)currentTime).ToString();//int type
        }

        AlertColor();
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (currentTime <= 0)
        {
            Debug.Log("Game Over!");
            isGameOver = true;
            Time.timeScale = 0;

            //make the gameover animation
            gameOverAnim.SetTrigger("isActive");
        }
    }

    private void AlertColor()
    {
        if (currentTime <= 5)
        {
            timeDisplay.color = new Vector4(200, 0, 0, 255);
        }
    }
}
