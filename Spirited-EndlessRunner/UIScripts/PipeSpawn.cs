using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    public static PipeSpawn Instance;
    public float speed;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnThePipe()
    {
        pipe.GetComponent<PipeMove>().speed = speed;
        GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
