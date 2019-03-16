using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float maxHp = 100.0f;
    public float currentHp = 10.0f;

    private void Awake()
    {
        currentHp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I have hitted" + collision);
        currentHp -= 15.0f;
        Debug.Log("Current Hp is " + currentHp);
    }

}
