using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Buttons")]
    public KeyCode forwardButton = KeyCode.W;
    public KeyCode backButton = KeyCode.S;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode jumpButton = KeyCode.Space;
    public KeyCode lockButton = KeyCode.LeftShift;
    [Space]
    [Header("Movement Integers")]
    public int forwardMomentum = 5;
    public int backwardMomentum = 1;
    public int sidewaysMomentum = 3;
    public float rotateSpeed = 1f;
    public int jumpStrength;
    [Space]
    [Range(0f, 10f)]
    public float speedBuff = 1f;
    Rigidbody rb;
    [Range(1, 3)]
    public int jumpAmount = 1;
    int currentJump = 0;
    public bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Moving FWD and BCW
        if (Input.GetKey(forwardButton)) 
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * (forwardMomentum * speedBuff);
            //rb.AddForce(new Vector3(0, 0, sidewaysMomentum * speedBuff), ForceMode.Force);
        }
        if (Input.GetKey(backButton))
        {
            transform.position += transform.TransformDirection(Vector3.back) * Time.deltaTime * (backwardMomentum * speedBuff);
            //rb.AddForce(new Vector3(0, 0, -sidewaysMomentum * speedBuff), ForceMode.Force);
        }

        //Rotating and moving
        if (Input.GetKey(leftButton) && Input.GetKey(forwardButton) && !Input.GetKey(lockButton))
        {
            transform.Rotate(0, -rotateSpeed, 0, Space.Self);
        }
        if (Input.GetKey(rightButton) && Input.GetKey(forwardButton) && !Input.GetKey(lockButton))
        {
            transform.Rotate(0, rotateSpeed, 0, Space.Self);
        }

        //Rotating standing
        if (Input.GetKey(leftButton) && !Input.GetKey(forwardButton) && !Input.GetKey(lockButton))
        {
            transform.Rotate(0, 0.5f * -rotateSpeed, 0, Space.Self);
        }
        if (Input.GetKey(rightButton) && !Input.GetKey(forwardButton) && !Input.GetKey(lockButton))
        {
            transform.Rotate(0, 0.5f * rotateSpeed, 0, Space.Self);
        }

        //Moving Sideways
        if (Input.GetKey(leftButton) && Input.GetKey(lockButton))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * (sidewaysMomentum * speedBuff);
            //rb.AddForce(new Vector3(-sidewaysMomentum * speedBuff, 0, 0), ForceMode.Force);

        }
        if (Input.GetKey(rightButton) && Input.GetKey(lockButton))
        {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * (sidewaysMomentum * speedBuff);
            //rb.AddForce(new Vector3(sidewaysMomentum * speedBuff, 0, 0), ForceMode.Force);
        }

        if (Input.GetKeyDown(jumpButton) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpStrength, 0), ForceMode.Impulse);
            /*if (jumpAmount > 1 && currentJump < jumpAmount-1)
            {
                currentJump++;
            }
            else
            { */
                isGrounded = false;
            //}
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
            //currentJump = 0;
        }
    }
}
