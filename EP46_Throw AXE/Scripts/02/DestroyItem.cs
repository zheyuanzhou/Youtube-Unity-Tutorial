using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MARKER This script will be attached to the Item which would be destroyed
public class DestroyItem : MonoBehaviour
{
    private Animator anim;
    private CameraController cameraController;
    private BoxCollider2D boxCollider;

    private bool isDead;

    public GameObject slashEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cameraController = FindObjectOfType<CameraController>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon" && !isDead)
        {
            anim.SetTrigger("isDestroyed");//MARKER Make another Animation [Loop is false]

            cameraController.isShaked = true;
            cameraController.CameraShake(0.4f);

            isDead = true;//MARKER Making sure our weapon will not damage this item again
            boxCollider.enabled = false;

            Instantiate(slashEffect, transform.position, Quaternion.identity);//Make one slash visual effect
        }
    }

}
