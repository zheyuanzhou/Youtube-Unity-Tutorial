
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : Enemy
{
    private float moveRate = 2.0f;
    private float moveTimer;

    private float shotRate = 2.1f;
    private float shotTimer;
    public GameObject projectile;

    [SerializeField] private float minX, maxX, minY, maxY;

    protected override void Introduction()
    {
        base.Introduction();
    }

    protected override void Move()
    {
        //base.Move();//MARKER Give up the base Move Function!!
        RandomMove();
    }

    private void RandomMove()
    {
        moveTimer += Time.deltaTime;

        if(moveTimer > moveRate)
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            moveTimer = 0;
        }
    }

    protected override void Attack()
    {
        base.Attack();

        shotTimer += Time.deltaTime;

        if(shotTimer > shotRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotTimer = 0;
        }
    }

}
