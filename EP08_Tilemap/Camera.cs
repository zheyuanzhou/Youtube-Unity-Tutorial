using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-6.31/11.6/-7.2
public class Camera : MonoBehaviour
{
    private Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(target.position.x, -6.3f, 6.3f),
        Mathf.Clamp(target.position.y, -7.2f, 11.6f),
        transform.position.z);
    }

}
