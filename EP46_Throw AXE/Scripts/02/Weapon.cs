using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;//STEP 01 Weapon Rotation

    //STEP 02 Move to Mouse Position
    [SerializeField] private float moveSpeed;
    private Vector3 targetPos;
    private bool isClicked;
    private bool isRotating;

    //STEP 03
    private Transform playerTrans;
    private bool canComeBack;//default is false
    private bool returnWeapon;
    public Transform weaponTrans;
    private bool isDamage;//MARKER avoid always damage when stop on the ground //FIXME isDamage

    //STEP 05 Effects
    private CameraController cameraController;
    public GameObject slashEffect;
    public GameObject weaponReturnEffect;

    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Update()
    { 
        SelfRotation();

        if (Input.GetMouseButtonDown(0) && isClicked == false)//STEP 03 !isCLicked Avoid click twice
        {
            isClicked = true;
            targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);//MARKER SAVE the TARGET Position
        }

        if(isClicked)
        {
            isRotating = true;//MARKER Make the weapon Rotation
            ThrowWeapon();//MARKER If click, Throw the weapon
        }

        if(Vector2.Distance(targetPos, transform.position) <= 0.01f)
        {
            isRotating = false;
            //isClicked = false;//MARKER STEP 03 you can click again Or you can choose to delet this line which makes your weapon come back by press space bar
            canComeBack = true;
            isDamage = false;//FIXME isDamage
        }

        //STEP 03

        if(Input.GetMouseButtonDown(0) && canComeBack)
        {
            returnWeapon = true;
            isDamage = true;//FIXME isDamage
        }

        if(returnWeapon)
        {
            BackWeapon();
        }

        if (Vector2.Distance(transform.position, playerTrans.position) <= 0.01f)
        {
            isRotating = false;
            canComeBack = false;
            returnWeapon = false;
            isClicked = false;
            isDamage = false;//FIXME isDamage

            transform.rotation = new Quaternion(0, 0, 0, 0);//MARKER MAKING SURE the weapon is correct direction
        }

        //STEP 04 MARKER Making the weapon come with our player
        if(!isClicked && !returnWeapon && !canComeBack)
        {
            transform.position = playerTrans.position;
        }
    }

    private void SelfRotation()
    {
        if(isRotating)//STEP 02
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);//STEP 01 Weapon Rotation
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }

    //STEP 02
    private void ThrowWeapon()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//MARKER cannot view the axex
        //transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        //Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);//TARGET

        //targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        //Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);//TARGET

        isRotating = true;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        isDamage = true;//FIXME isDamage

        transform.SetParent(null);//STEP 04
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && isDamage)//FIXME isDamage
        {
            other.GetComponentInChildren<HealthBar>().hp -= 20;
            cameraController.isShaked = true;
            cameraController.CameraShake(0.4f);

            Instantiate(slashEffect, transform.position, Quaternion.identity);
        }
    }

    private void BackWeapon()
    {
        isRotating = true;
        transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, moveSpeed * 5 * Time.deltaTime);
        transform.SetParent(weaponTrans);

        //STEP 05
        if (Vector2.Distance(transform.position, playerTrans.position) <= 0.01f)
        {
            StartCoroutine(ComeBackEffect());
            Instantiate(weaponReturnEffect, playerTrans.position, Quaternion.identity);
        }
    }

    //STEP 05 Effects
    IEnumerator ComeBackEffect()
    {
        cameraController.isShaked = true;
        cameraController.CameraShake(0.5f);
        yield return new WaitForSeconds(0.6f);
        cameraController.isShaked = false;
    }

}
