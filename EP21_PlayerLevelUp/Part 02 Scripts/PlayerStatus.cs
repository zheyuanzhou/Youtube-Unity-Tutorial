using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public string playerName, description;

    public int playerLevel, maxLevel;

    public int currentExp;
    public int[] nextLevelExp;//MARKER If we receive enough EXP, We can Level up//MARKER int[] : int type array

    public int currentHp, currentMp, maxHp, maxMp;
    public int attack, defense;

    //MARKER Although both function called at start method, There have different order
    //MARKER Or you can change the start below to Awake method to make this script call eariler than right script
    private void Start()//eariler than start function
    {
        nextLevelExp = new int[maxLevel + 1];//maxLEvel is 10, array length is 10//MARKER UPDATE: We have nextLevelExp[11].length is 11
        nextLevelExp[1] = 1000;

        for(int i = 2; i < maxLevel; i++)
        {
            nextLevelExp[i] = Mathf.RoundToInt(nextLevelExp[i - 1] * 1.1f);//if i is 0; we did not have array[-1]
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))//When we press space bar/hit enemy, we receive X EXP
        {
            AddExp();
        }
    }

    public void AddExp()
    {
        currentExp += 600;

        //MARKER when we reach level 10, nextLevelExp[10] do NOT exist, We only have nextLevelExp[9]
        if (currentExp >= nextLevelExp[playerLevel] && playerLevel < maxLevel)
        {
            LevelUp();
        }

        if(playerLevel >= maxLevel)
        {
            currentExp = 0;//if you reach to level max, our player cannot receive exp any more
        }

        FindObjectOfType<UIManager>().UpdatePlayerStatus();
    }

    private void LevelUp()
    {
        currentExp -= nextLevelExp[playerLevel];
        playerLevel++;//playerLevel = playerLevel + 1

        maxHp = Mathf.RoundToInt(maxHp * 1.2f);
        currentHp = maxHp;
        maxMp += 20;
        currentMp = maxMp;
        attack = Mathf.CeilToInt(attack * 1.1f);
        defense = Mathf.RoundToInt(defense * 1.05f);
    }
}
