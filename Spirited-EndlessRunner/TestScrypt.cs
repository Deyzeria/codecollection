using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScrypt : MonoBehaviour
{
    public GameObject TreOn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Box = Instantiate(TreOn, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
