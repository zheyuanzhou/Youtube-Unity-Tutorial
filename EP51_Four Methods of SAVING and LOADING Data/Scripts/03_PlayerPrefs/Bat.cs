using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Animator anim;//WALK & ATTACK Animation
    private Transform target;
    private SpriteRenderer sp;
    private Material defaultMat;
    [SerializeField] private Material hurtMat;
    [SerializeField] private GameObject fireExplosion;
    public Transform fireExplosionTrans;

    //MARKER If you want to save your enemy status by Serialization
    public bool isDead;
    [HideInInspector]
    public float batPositionX, batPositionY;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        defaultMat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        batPositionX = transform.position.x;
        batPositionY = transform.position.y;

        if(!isDead)
        {
            //MARKER MoveTowards to the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (GetComponentInChildren<HealthBar>().hp <= 0)
            {
                isDead = true;
                anim.SetBool("isDied", true);
                GetComponent<Collider2D>().enabled = false;

                Instantiate(fireExplosion, fireExplosionTrans.position, Quaternion.identity);

                EventSystem.instance.CameraShakeEvent(0.2f);//MARKER OB PATTERN
                return;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon" && !isDead)
        {
            StartCoroutine(HurtEffect());
        }
    }

    IEnumerator HurtEffect()
    {
        sp.material = hurtMat;
        yield return new WaitForSeconds(0.2f);
        sp.material = defaultMat;
    }

    //MARKER ATTACH to the last frame on the Death Animation
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
