using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTrans;//Player Transform position

    [SerializeField] private float smoothLerpSpeed;//Smoothly FOLLOW the Player
    [SerializeField] private float minX, maxX, minY, maxY;// The Limitation of the environment

    //ZOOM IN AND OUT
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField] private float zoomLerpSpeed = 10; 

    //MARKER Camera SHAKE SHAKE
    private float shakeAmplitude;//How much Camera would shake
    private Vector3 shakeActive;//Camera Shake Position

    //public bool isShaked;//MARKER Once this Boolean value is true, the CAMERA will SHAKE SHAKE. This variable will be used on other scripts

    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        targetZoom = Camera.main.orthographicSize;
    }

    private void OnEnable()
    {
        EventSystem.cameraShakeEvent += CameraShake;
    }

    private void OnDisable()
    {
        EventSystem.cameraShakeEvent -= CameraShake;
    }

    private void Update()
    {
        FollowSmooth();
        RestrictCamera();
        Zoom();
        ShakeCamera();
    }

    //MARKER Camera Smoothly folow the Player
    private void FollowSmooth()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z), smoothLerpSpeed * Time.deltaTime);
    }

    //MARKER Limit the Camera Range according to the environment
    private void RestrictCamera()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY),
                                         transform.position.z);
    }

    //MARKER Camera Zoom In and Out
    private void Zoom()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollWheel * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 3.5f, 7.5f);//Min and Max
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetZoom, zoomLerpSpeed * Time.deltaTime);
    }

    //MARKER CAMERA SHAKE SHAKE 
    private void ShakeCamera()
    {
        if (shakeAmplitude > 0)
        {
            shakeActive = new Vector3(Random.Range(-shakeAmplitude, shakeAmplitude), Random.Range(-shakeAmplitude, shakeAmplitude), 0);
            shakeAmplitude -= Time.deltaTime;
        }
        else
        {
            shakeActive = Vector3.zero;
        }

        transform.position += shakeActive;
    }

    //CORE This Function will be called On EventSystem Delegate Pattern
    public void CameraShake(float _shakeAmount)
    {
        shakeAmplitude = _shakeAmount;
    }


}
