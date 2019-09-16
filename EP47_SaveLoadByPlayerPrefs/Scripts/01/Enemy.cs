using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRange;

    private Animator anim;//WALK & ATTACK Animation
    public GameObject projectile;
    public Transform firePoint;
    private Transform target;

    //Hurt Effect
    private SpriteRenderer sp;
    private Material defaultMat;
    [SerializeField] private Material hurtMat;

    //Death Effect
    //private bool isDead;
    [SerializeField] private GameObject fireExplosion;
    public Transform fireExplosionTrans;

    private void Start()
    {
        wayPointTarget = wayPoint01;//original Target is wayPoint01
        sp = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        defaultMat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (GetComponentInChildren<HealthBar>().hp <= 0)
        {
            //isDead = true;
            anim.SetBool("isDied", true);
            GetComponent<CircleCollider2D>().enabled = false;

            Instantiate(fireExplosion, fireExplosionTrans.position, Quaternion.identity);

            EventSystem.instance.CameraShakeEvent(0.2f);//MARKER OB PATTERN
            return;
        }

        if (Vector2.Distance(transform.position, target.position) >= attackRange)
        {
            anim.SetBool("isAttack", false);

            Patrol();
        }
        else
        {
            anim.SetBool("isAttack", true);
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, wayPoint01.position) < 0.01f)
        {
            wayPointTarget = wayPoint02;

            //sp.flipX = false
            TurnAround();
        }

        if (Vector2.Distance(transform.position, wayPoint02.position) < 0.01f)
        {
            wayPointTarget = wayPoint01;

            //sp.flipX = true
            TurnAround();
        }
    }

    //CORE This function will be added on the Animation window "Attack Animation X Frame"
    public void Shot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }

    private void TurnAround()
    {
        Vector3 localTemp = transform.localScale;
        localTemp.x *= -1;
        transform.localScale = localTemp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon")
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
