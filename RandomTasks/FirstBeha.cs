using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBeha : MonoBehaviour
{
    public Vector3 vectorArray;
    int newNumber = 3;
    private void Update()
    {
        transform.Rotate(vectorArray, Space.Self);
    }

    public void ChangeVector()
    {
        switch (newNumber)
        {
            case 1:
                vectorArray = new Vector3(0f, 3f, 0f);
                newNumber = 2;
                break;

            case 2:
                vectorArray = new Vector3(0f, 0f, 3f);
                newNumber = 3;
                break;

            case 3:
                vectorArray = new Vector3(3f, 0f, 0f);
                newNumber = 1;
                break;
        }
    }
}
