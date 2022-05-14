using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sizeOfObject { Large, Small, Long}
public class ObjectMovement : MonoBehaviour
{
    public sizeOfObject objectSize;
    public GameObject boxColS;
    public GameObject BoxColL;
    public GameObject BoxColLong;
    public float speed = 0;

    public void Start()
    {
        if(objectSize == sizeOfObject.Small)
        {
            boxColS.SetActive(true);
        }
        else if (objectSize == sizeOfObject.Large)
        {
            BoxColL.SetActive(true);
        }
        else if (BoxColLong != null && objectSize == sizeOfObject.Long)
        {
            BoxColLong.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
