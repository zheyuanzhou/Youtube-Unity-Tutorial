using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MARKER THIS CLASS is used for us to combine all elements needed to saved together
[System.Serializable]
public class Save
{
    public int coinsNum;
    public int diamondsNum;

    public float playerPositionX;
    public float playerPositionY;

    //MARKER If you want to save the enemy position 
    public List<float> enemyPositionX = new List<float>();
    public List<float> enemyPositionY = new List<float>();
    public List<bool> isDead = new List<bool>();

    //MARKER Enemy Health Point
    public List<int> enemyHps = new List<int>();

}
