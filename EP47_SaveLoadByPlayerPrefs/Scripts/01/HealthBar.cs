using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpImage;//"Red" Health bar Image
    public Image hpEffectImage;//"White Effect" Health bar Image

    [HideInInspector] public float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float hurtSpeed = 0.005f;

    private void Start()
    {
        hp = maxHp;//At the beginning of the game, The hp is the maxHp
    }

    private void Update()
    {
        hpImage.fillAmount = hp / maxHp;

        if(hpEffectImage.fillAmount > hpImage.fillAmount)
        {
            hpEffectImage.fillAmount -= hurtSpeed;
        }
        else
        {
            hpEffectImage.fillAmount = hpImage.fillAmount;
        }
    }


}
