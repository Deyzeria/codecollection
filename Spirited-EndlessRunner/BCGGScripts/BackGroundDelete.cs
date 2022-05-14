using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDelete : MonoBehaviour
{
    public GameObject spawner;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("A");
        Destroy(other.gameObject);
        spawner.GetComponent<BackGSpawn>().DoIt();
    }
}
