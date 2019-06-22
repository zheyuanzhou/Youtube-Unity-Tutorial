using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //CORE Singleton mode
    public static PlayerController instance;//MARKER KEEp in the different scene

    private Rigidbody2D rb;
    public float moveH, moveV;
    [SerializeField] private float moveSpeed = 5.0f;

    public string scenePassword;//MARKER store one name when the plar leave for another scene

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }
}
