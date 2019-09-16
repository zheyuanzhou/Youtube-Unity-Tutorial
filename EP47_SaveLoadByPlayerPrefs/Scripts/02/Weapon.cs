using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AXE
public class Weapon : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;//STEP 01 Weapon Rotation

    //STEP 02 Weapon Move to Mouse Position
    [SerializeField] private float moveSpeed;
    private Vector3 targetPos;//ACTUALLY This is our mousePosition
    private bool isClicked;
    private bool isRotating;

    //STEP 03
    private Transform playerTrans;//Weapon Return Position
    private bool canComeBack;//default is false
    private bool returnWeapon;
    public Transform weaponTrans;
    private bool isDamage;//MARKER avoid always damage when stop on the ground //FIXME isDamage

    //STEP 05 Effects
    public GameObject slashEffect;
    public GameObject weaponReturnEffect;

    //Trail Effect
    private TrailRenderer tr;

    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        tr = GetComponentInChildren<TrailRenderer>();
        tr.enabled = false;
    }

    private void Update()
    { 
        SelfRotation();

        if (Input.GetMouseButtonDown(0) && isClicked == false)//STEP 03 !isCLicked Avoid click twice
        {
            isClicked = true;
            //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//MARKER CANNOT view the axex
            targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);//MARKER SAVE the TARGET Position
        }

        if(isClicked)
        {
            isRotating = true;//MARKER AXE Start Rotation
            ThrowWeapon();//MARKER If click, Throw the weapon
        }

        //IF AXE Reach the Target Position
        ReachAtMousePosition();

        //STEP 03

        if (Input.GetMouseButtonDown(0) && canComeBack)
        {
            isDamage = true;//FIXME isDamage

            returnWeapon = true;
        }

        if(returnWeapon)
        {
            BackWeapon();
        }

        //CORE When The AXE is back to our player 
        ReachAtPlayerPosition();

        //STEP 04 MARKER Making the weapon come with our player
        if (!isClicked && !returnWeapon && !canComeBack)
        {
            transform.position = playerTrans.position;
        }
    }

    //IF AXE Reach the Target Position
    private void ReachAtMousePosition()
    {
        if (Vector2.Distance(targetPos, transform.position) <= 0.01f)
        {
            isRotating = false;
            isDamage = false;//FIXME isDamage

            tr.enabled = false;

            canComeBack = true;
        }
    }

    //CORE When The AXE is back to our player 
    private void ReachAtPlayerPosition()
    {
        if (Vector2.Distance(transform.position, playerTrans.position) <= 0.01f)
        {
            isRotating = false;
            isDamage = false;//FIXME isDamage
            isClicked = false;

            canComeBack = false;
            returnWeapon = false;

            transform.rotation = new Quaternion(0, 0, 0, 0);//MARKER MAKING SURE the weapon is correct direction

            tr.enabled = false;
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
        isRotating = true;
        isDamage = true;//FIXME isDamage
        tr.enabled = true;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && isDamage)//FIXME isDamage [Avoid The AXE stop on the ground but still takes damage to Enemy]
        {
            other.GetComponentInChildren<HealthBar>().hp -= 20;

            EventSystem.instance.CameraShakeEvent(0.4f);//MARKER OB PATTERN

            Instantiate(slashEffect, transform.position, Quaternion.identity);
        }
    }

    private void BackWeapon()
    {
        isRotating = true;

        tr.enabled = true;

        transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, moveSpeed * 5 * Time.deltaTime);

        //STEP 05
        if (Vector2.Distance(transform.position, playerTrans.position) <= 0.01f)
        {
            EventSystem.instance.CameraShakeEvent(0.4f);//MARKER OB PATTERN
            Instantiate(weaponReturnEffect, playerTrans.position, Quaternion.identity);
        }
    }

}
