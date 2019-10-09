using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    public static EventSystem instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    public delegate void MyDelegate(float shakeAmount);
    public static event MyDelegate cameraShakeEvent;

    public void CameraShakeEvent(float _shakeAmount)
    {
        if(cameraShakeEvent != null)
        {
            cameraShakeEvent(_shakeAmount);
        }
    }

}
