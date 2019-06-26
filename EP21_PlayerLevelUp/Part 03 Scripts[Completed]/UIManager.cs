using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerStatus playerStatus;//drag the gameObject with PlayerStatus script/OPTIONALscriptableobject/ singleclass

    public Text nameText;
    public Text levelText, hpText, mpText, expText;
    public Text attackText, defenseText, nextExpText;

    public Slider expSldier;
    public Text sliderText;

    public Image playerImage;

    private void Start()
    {
        UpdatePlayerStatus();
    }

    public void UpdatePlayerStatus() 
    {
        nameText.text = playerStatus.playerName;

        levelText.text = playerStatus.playerLevel.ToString();//convert int type into string type
        hpText.text = "" + playerStatus.currentHp + "/" + playerStatus.maxHp;//currentHp/maxHP//MARKER 100/120
        mpText.text = "" + playerStatus.currentMp + "/" + playerStatus.maxMp;
        expText.text = "" + playerStatus.currentExp;
        attackText.text = "" + playerStatus.attack;
        defenseText.text = "" + playerStatus.defense;
        nextExpText.text = "" + playerStatus.nextLevelExp[playerStatus.playerLevel];//Your level nextLevel Exp

        expSldier.value = playerStatus.currentExp;
        expSldier.maxValue = playerStatus.nextLevelExp[playerStatus.playerLevel];

        sliderText.text = playerStatus.currentExp + "/" + playerStatus.nextLevelExp[playerStatus.playerLevel];

        playerImage.sprite = playerStatus.playerSprite;
    }


}
