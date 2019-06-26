using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    #region
    [Header("Player Status")]
    public string playerName, description;

    public int playerLevel, maxLevel;

    public int currentExp;
    public int[] nextLevelExp;//MARKER If we receive enough EXP, We can Level up//MARKER int[] : int type array

    public int currentHp, currentMp, maxHp, maxMp;
    public int attack, defense;
    #endregion

    public Text hpDisplayText, mpDisplayText, attDisplayText, defDisplayText;
    public GameObject[] gameObjectWithAnimators;
    private int curHp, preHp, curMp, preMp, curAtt, preAtt, curDef, preDef;

    [SerializeField] private Sprite[] sprites;
    public Sprite playerSprite;//MARKER The playerSprite will be chosen from the sprites array according to their level

    public ParticleSystem lvEffect;


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

        curHp = maxHp;
        curMp = maxMp;
        preHp = 0;//MARKER in the beginning of the game, no previous hp, when we press button, prehp will be equal to maxHp
        preMp = 0;
        curAtt = attack;
        curDef = defense;
        preAtt = 0;
        preDef = 0;

        playerSprite = sprites[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))//When we press space bar/hit enemy, we receive X EXP
        {
            AddExp(150);
        }
    }

    public void AddExp(int amount)
    {
        currentExp += amount;

        //MARKER when we press the button, our previous data will be assigned
        preHp = maxHp;//TODO We can try preHp = curHp later. In this case there is the same
        preMp = maxMp;
        preAtt = curAtt;
        preDef = curDef;

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

        //MARKER write before all data updated
        curHp = maxHp;
        curMp = maxMp;
        curAtt = attack;
        curDef = defense;

        MakingAnimation();
        UpdateProfile();
    }

    private void MakingAnimation()
    {
        for(int i = 0; i < gameObjectWithAnimators.Length; i++)
        {
            hpDisplayText.text = "+" + (curHp - preHp);
            mpDisplayText.text = "+" + (curMp - preMp);
            attDisplayText.text = "+" + (curAtt - preAtt);
            defDisplayText.text = "+" + (curDef - preDef);

            gameObjectWithAnimators[i].GetComponent<Animator>().SetTrigger("Levelup");
        }
    }

    private void UpdateProfile()
    {
        if(playerLevel < 3)//lv 1 lv 2
        {
            playerSprite = sprites[0];
        } 
        else if(playerLevel < 5)
        {
            playerSprite = sprites[1];
        } 
        else if(playerLevel < 8)
        {
            playerSprite = sprites[2];
        }
        else
        {
            playerSprite = sprites[3];
        }

        if(playerLevel == 3 || playerLevel == 5 || playerLevel == 8 || playerLevel == 10)
        {
            StartCoroutine(LevelUpEffectCo());
        }
    }

    IEnumerator LevelUpEffectCo()
    {
        lvEffect.gameObject.SetActive(true);
        lvEffect.Play();
        yield return new WaitForSeconds(lvEffect.duration);
        lvEffect.gameObject.SetActive(false);

    }
}
