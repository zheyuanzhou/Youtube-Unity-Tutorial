using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpImage;
    public Image hpEffectImage;

    [SerializeField] public float hp;
    [SerializeField] private float maxHp;
    [SerializeField] private float hurtSpeed = 0.005f;

    private void Start()
    {
        hp = maxHp;
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
