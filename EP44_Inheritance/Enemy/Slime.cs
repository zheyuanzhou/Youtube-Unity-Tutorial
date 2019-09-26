using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    protected override void Introduction()
    {
        //base.Introduction();
        Debug.Log("Hi This is Mr. Green!");
    }

    protected override void Move()
    {
        base.Move();
    }

    protected override void Attack()
    {
        
    }

}
