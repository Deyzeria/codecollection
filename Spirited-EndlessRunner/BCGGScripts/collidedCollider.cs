using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidedCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collider");

        GameStageControl.Instance.StartCoroutine("PipeReached");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        GameStageControl.Instance.StartCoroutine("PipeReached");

    }
}
