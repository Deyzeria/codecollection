using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Basic Stats")]
    public int healthMax = 100;
    public int healthCurrent;
    public int manaMax = 100;
    public int manaCurrent;
    [Space]
    [Header("Movement Stats")]
    public int speed;

    public GameObject target;

    // Start is called before the first frame update
    private void Awake()
    {
        healthCurrent = healthMax;
        manaCurrent = manaMax;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //targeting
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    target = hit.transform.gameObject;
                }
                else { target = null; }
            }
            else { target = null; }

        }
    }
}
