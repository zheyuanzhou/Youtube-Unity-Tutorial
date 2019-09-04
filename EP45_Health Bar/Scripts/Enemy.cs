using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRange;
    //private SpriteRenderer sp;//MARKER replace with localScale later

    private Animator anim;
    public GameObject projectile;
    public Transform firePoint;
    private Transform target;

    private void Start()
    {
        wayPointTarget = wayPoint01;
        //sp = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) >= attackRange)
        {
            anim.SetBool("isAttack", false);
            Patrol();
        }
        else
        {
            anim.SetBool("isAttack", true);
        }

        //MARKER ONLY FOR TEST
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<HealthBar>().hp -= 70;
        }
    }

    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, wayPoint01.position) < 0.01f)
        {
            wayPointTarget = wayPoint02;

            //sp.flipX = false
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }

        if (Vector2.Distance(transform.position, wayPoint02.position) < 0.01f)
        {
            wayPointTarget = wayPoint01;

            //sp.flipX = true
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }
    }

    //CORE This function will be added on the Animation window "Attack Animation X Frame"
    public void Shot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }


}
