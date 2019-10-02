using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MARKER This script will be attached to the Item which would be destroyed
public class DestroyItem : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;

    private bool isDead;

    public GameObject slashEffect;

    //MARKER drop items
    private int randNum;
    public GameObject[] dropItems;

    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon" && !isDead)
        {
            isDead = true;//MARKER Making sure our weapon will not damage this item again
            boxCollider.enabled = false;

            anim.SetTrigger("isDestroyed");//MARKER Make another Animation [Loop is false]

            EventSystem.instance.CameraShakeEvent(0.4f);//MARKER OB PATTERN

            Instantiate(slashEffect, transform.position, Quaternion.identity);//Make one slash visual effect
        }
    }

    //MARKER THIS method will be trigger on the end frame of the "isDestroyed" Animation 
    public void DropRandomItem()
    {
        randNum = Random.Range(0, 2);
        Instantiate(dropItems[randNum], transform.position, Quaternion.identity);
    }

}
