using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private Transform playerTrans;
    [SerializeField] private float moveSpeed;

    public GameObject pickupEffect;

    private bool isOwned;

    public enum ItemType
    {
        Coin,
        Diamond
    }

    public ItemType itemType;

    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && !isOwned)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, moveSpeed * Time.deltaTime);

            if(Vector2.Distance(transform.position, playerTrans.position) < 0.01f)
            {
                isOwned = true;
                Instantiate(pickupEffect, playerTrans.position, Quaternion.identity);

                if(itemType == ItemType.Coin)
                {
                    GameManager.instance.coins += 10;//MARKER
                }
                else if(itemType == ItemType.Diamond)
                {
                    GameManager.instance.diamonds += 5;
                }

                Destroy(gameObject);
            }
        }
    }

}
