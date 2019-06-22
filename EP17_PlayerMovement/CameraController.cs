using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float smoothSpeed;

    [SerializeField] private float minX, maxX, minY, maxY;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();//MARKER use tag to find target
        target = PlayerController.instance.transform;//MARKER using singleton way to get target
    }

    private void LateUpdate()
    {
        //MARKER Method 1 tradition method of move camera MARKER FOLLOW TARGET(PLAYER)
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);//transform.position : camera current position 

        //MARKER smoothly move Camera
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), smoothSpeed * Time.deltaTime);

        //MARKER Limit the Range
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),//x limit range
                                         Mathf.Clamp(transform.position.y, minY, maxY),//y limit range
                                         transform.position.z);
    }

}
