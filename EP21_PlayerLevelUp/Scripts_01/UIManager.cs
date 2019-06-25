using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerStatus playerStatus;

    public Text nameText, levelText, currentExpText;
    public Text hpText, mpText;
    public Text attackText, defenseText;

    public Text nextToLevelText;

    private void Start()
    {
        UpdatePlayerStatus();
    }

    public void UpdatePlayerStatus()
    {
        nameText.text = playerStatus.playerName;
        levelText.text = "" + playerStatus.playerLevel;
        currentExpText.text = "" + playerStatus.currentExp;

        hpText.text = "" + playerStatus.currentHp + "/" + playerStatus.maxHp;
        mpText.text = "" + playerStatus.currentMp + "/" + playerStatus.maxMp;

        attackText.text = "" + playerStatus.attack;
        defenseText.text = "" + playerStatus.defense;

        nextToLevelText.text = playerStatus.nextLevelExp[playerStatus.playerLevel].ToString();
    }

}
