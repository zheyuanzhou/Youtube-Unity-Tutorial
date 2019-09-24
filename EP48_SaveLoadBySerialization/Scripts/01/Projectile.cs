using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MARKER THIS IS THE ENEMY PROJECTILE 
public class Projectile : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float moveSpeed;

    public GameObject destroyEffect, attackEffect;

    private float lifeTimer;//How long the projectile auto destroy
    [SerializeField] private float maxLife = 2.0f;//After two seconds, the projectile auto destroy

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        lifeTimer += Time.deltaTime;
        if(lifeTimer >= maxLife)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<HealthBar>().hp -= 35;

            Instantiate(attackEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
