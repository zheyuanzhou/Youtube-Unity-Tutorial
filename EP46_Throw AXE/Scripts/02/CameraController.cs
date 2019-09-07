using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTrans;//Player Transform position

    [SerializeField] private float smoothSpeed;//Smoothly FOLLOW the Player
    [SerializeField] private float minX, maxX, minY, maxY;// The Limitation of the environment

    //MARKER Camera SHAKE SHAKE
    private float shakeAmplitude;//How much Camera would shake
    private Vector3 shakeActive;//Camera Shake Position

    public bool isShaked;//MARKER Once this Boolean value is true, the CAMERA will SHAKE SHAKE. This variable will be used on other scripts

    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        //MARKER Camera Smoothly folow the Player
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z), smoothSpeed * Time.deltaTime);

        //MARKER Limit the Camera Range according to the environment
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY),
                                         transform.position.z);

        //MARKER CAMERA SHAKE SHAKE 
        if(shakeAmplitude > 0)
        {
            shakeActive = new Vector3(Random.Range(-shakeAmplitude, shakeAmplitude), Random.Range(-shakeAmplitude, shakeAmplitude), 0);
            shakeAmplitude -= Time.deltaTime;
        }
        else
        {
            shakeActive = Vector3.zero;
        }

        if(isShaked)
        {
            transform.position += shakeActive;
        }

       //MARKER ONLY FOR TEST 
       //if(Input.GetKeyDown(KeyCode.Space))
       //{
       //     CameraShake(0.6f);
       //}
    }

    //MARKER This Function will be called outside of the script if You need one shake effect
    public void CameraShake(float _shakeAmount)
    {
        shakeAmplitude = _shakeAmount;
    }


}
