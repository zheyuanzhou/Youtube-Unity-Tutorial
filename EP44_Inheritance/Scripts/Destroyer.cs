using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float lifeTimer;

    private void Start()
    {
        Destroy(gameObject, lifeTimer);
    }
}
