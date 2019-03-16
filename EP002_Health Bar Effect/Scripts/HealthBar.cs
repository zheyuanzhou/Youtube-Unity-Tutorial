using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image healthPointImage;
    public Image healthPointEffect;

    private PlayerControl player;
    [SerializeField] private float hurtSpeed = 0.003f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    private void Update()
    {
        healthPointImage.fillAmount = player.currentHp / player.maxHp;

        if(healthPointEffect.fillAmount >= healthPointImage.fillAmount)
        {
            healthPointEffect.fillAmount -= hurtSpeed;
        }
        else
        {
            healthPointEffect.fillAmount = healthPointImage.fillAmount;
        }
    }

}
