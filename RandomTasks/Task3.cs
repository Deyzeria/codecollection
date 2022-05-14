using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    public GameObject openWindow;

    public void OpenTheWindow(bool status)
    {
        openWindow.SetActive(status);
    }
}
