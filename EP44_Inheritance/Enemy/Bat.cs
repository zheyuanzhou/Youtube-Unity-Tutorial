using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;

    private void Awake()
    {
        wayPointTarget = wayPoint01;//At the beginning, bat move to the right waypoint
    }

    protected override void Introduction()
    {
        //base.Introduction();
        Debug.Log("Hi This is BATMAN!");
    }

    protected override void Move()
    {
        base.Move();

        //MARKER Override Part
        if(Vector2.Distance(transform.position, target.position) > distance)
        {
            //When we reached at the waypoint01, we have to mvoe to the waypoint 02
            if(Vector2.Distance(transform.position, wayPoint01.position) < 0.01f)
            {
                wayPointTarget = wayPoint02;
            }

            if(Vector2.Distance(transform.position, wayPoint02.position) < 0.01f)
            {
                wayPointTarget = wayPoint01;
            }

            transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed * Time.deltaTime);
        }
    }

    protected override void Attack()
    {
        
    }


}
