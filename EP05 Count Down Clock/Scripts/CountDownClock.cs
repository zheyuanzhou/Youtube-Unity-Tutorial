using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownClock : MonoBehaviour
{

    public Image clockBackground;
    public GameObject maxTime;
    public GameObject currentTime;

    [Range(0, 60)]
    public int gameTime;//This variable is the level time in the game

    private void Awake()
    {
        clockBackground.fillAmount = (float)gameTime / 60;

        int maxTimeAngle = (int)(gameTime * 360) / 60;
        maxTime.transform.eulerAngles = new Vector3(0, 0, -maxTimeAngle);
    }

    private void Update()
    {
        float currentTimeAngle = (float)((Time.realtimeSinceStartup * 360) / 60);
        currentTime.transform.eulerAngles = new Vector3(0, 0, -currentTimeAngle);
        Debug.Log(currentTimeAngle);

        Alert();
        CheckGameOver();
    }

    private void Alert()
    {
        if(gameTime - (Time.realtimeSinceStartup / 60) <= 10)
        {
            currentTime.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
            clockBackground.color = new Vector4(1, 0, 0, 1);
        }
    }

    private void CheckGameOver()
    {
        if(Time.realtimeSinceStartup >= gameTime * 60)
        {
            Debug.Log("Game Over");
        }
    }

}
