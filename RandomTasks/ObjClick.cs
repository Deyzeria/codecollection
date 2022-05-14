using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjClick : MonoBehaviour
{
    public GameObject cubeCube;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "MyObjectName")
                {
                    cubeCube.GetComponent<FirstBeha>().ChangeVector();
                }
            }
        }
    }

}
