using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform player;
    Vector3 lastMouseCoordinate = Vector3.zero;
    [Range(0f, 10f)]
    public float turnSpeed;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;
            if (mouseDelta.x < 0)
            {
                //Debug.Log("MovedLeft");
                transform.Rotate(0, -turnSpeed, 0, Space.Self);
            }
            if (mouseDelta.x > 0)
            {
                //Debug.Log("MovedRight");
                transform.Rotate(0, turnSpeed, 0, Space.Self);
            }
            if (mouseDelta.y < 0)
            {
                //Debug.Log("MovedUp");
                transform.Rotate(turnSpeed, 0, 0, Space.Self);
            }
            if (mouseDelta.y > 0)
            {
                //Debug.Log("MovedDown");
                transform.Rotate(-turnSpeed, 0, 0, Space.Self);
            }
            lastMouseCoordinate = Input.mousePosition;
        }
    }
}
