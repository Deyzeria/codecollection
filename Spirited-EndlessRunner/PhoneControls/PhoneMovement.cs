using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneMovement : MonoBehaviour
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
    public static PhoneMovement Instance;
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        if (data.Direction == SwipeDirection.Left && curPos != 0 && reached == true)
        {
            curPos--;
            reached = false;
        }

        if (data.Direction == SwipeDirection.Right && curPos != 2 && reached == true)
        {
            curPos++;
            reached = false;
        }

        if (data.Direction == SwipeDirection.Up)
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
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
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
        if (col.tag == "Blocks" || col.transform.parent.tag == "Blocks" && isAlive)
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
