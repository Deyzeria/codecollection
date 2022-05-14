using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{ 
    public List<Transform> groundPositions;
    public List<Transform> jumpPositions;
    [Space]
    public int curPos = 1;
    public bool reached = true;
    public bool jumped = false;
    public bool up = true;
    bool isAlive = true;
    private Animator anim;
    public static Movement Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.A) && curPos != 0)
            {
                curPos--;
                reached = false;
            }

            if (Input.GetKeyDown(KeyCode.D) && curPos != 2)
            {
                curPos++;
                reached = false;
            }

            /*if (Input.GetKeyDown(KeyCode.Space) && jumped == false)
            {
                jumped = true;
                up = true;
            }*/
            if (Input.GetKey(KeyCode.Space))
            {
                if (jumped == false)
                {
                    jumped = true;
                    up = true;
                    if (Settings.Instance != null)
                    {
                        if (Settings.Instance.Jump.isActiveAndEnabled)
                        {
                            Settings.Instance.SoundJump();
                        }
                        else
                        {
                            Settings.Instance.Jump.enabled = true;
                        }
                    }
                }
            }

            if (reached == false && jumped == false)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, groundPositions[curPos].transform.position, 10 * Time.deltaTime);
            }

            if (jumped == true)
            {
                if (up == true)
                {
                    transform.position = Vector3.MoveTowards(transform.position, jumpPositions[curPos].transform.position, 10 * Time.deltaTime);
                    anim.SetBool("jmp", true);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, groundPositions[curPos].transform.position, 10 * Time.deltaTime);
                }
            }

            if (transform.position.y >= 4.99f)
            {
                up = false;
            }

            if (transform.position.z == groundPositions[curPos].transform.position.z && transform.position.y == groundPositions[curPos].transform.position.y)
            {
                reached = true;
                if (jumped == true && up == false)
                {
                    jumped = false;
                    anim.SetBool("jmp", false);
                }
            }
        }
    }

    

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collided");
        if(col.tag == "Blocks" || col.transform.parent.tag == "Blocks" && isAlive)
        {
            anim.SetTrigger("rip");
            PauseTheDeath.Instance.FindAllAndFreeze();
            isAlive = false;
            if (Settings.Instance)
            {
                Settings.Instance.Jump.enabled = false;
                Settings.Instance.Sound.enabled = false;
            }
        }
    } 

    public void pauseAnim(int spd)
    {
        anim.speed = spd;
    }
}
