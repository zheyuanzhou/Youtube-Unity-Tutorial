using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public string playerName;
    public string playerDescription;

    public int playerLevel;
    public int maxLevel;

    public int currentExp;
    public int[] nextLevelExp;

    public int currentHp, currentMp, maxHp, maxMp;

    public int attack, defense;

    private void Awake()//MARKER MARKER START 可能有问题
    {
        nextLevelExp = new int[maxLevel + 1];

        nextLevelExp[1] = 1000;
        for(int i = 2; i < maxLevel; i++)
        {
            nextLevelExp[i] = Mathf.RoundToInt(nextLevelExp[i - 1] * 1.1f);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddExp();
        }
    }

    void AddExp()
    {
        currentExp += 600;

        if(currentExp >= nextLevelExp[playerLevel] && playerLevel < maxLevel)
        {
            PlayerLevelUp();//When the player increase EXP until the max exp in this level, Levelup now!
        }

        if(playerLevel >= maxLevel)
        {
            currentExp = 0;
        }

        FindObjectOfType<UIManager>().UpdatePlayerStatus();
    }

    private void PlayerLevelUp()
    {
        currentExp -= nextLevelExp[playerLevel];
        playerLevel++;

        maxHp = Mathf.RoundToInt(maxHp * 1.2f);
        maxMp = Mathf.CeilToInt(maxMp * 1.05f);
        currentHp = maxHp;
        currentMp = maxMp;

        attack += 25;
        defense += 10;
    }
}
