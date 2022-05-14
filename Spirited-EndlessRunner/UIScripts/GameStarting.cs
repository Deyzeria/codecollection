using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarting : MonoBehaviour
{
    public float fade = 1f;
    public float clr = 1f;
    public float difference = 0.1f;
    public Image pic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (clr > 0)
        {
            Color temp = pic.GetComponent<Image>().color;
            clr -= difference * Time.deltaTime;
            temp.b = clr;
            temp.r = clr;
            pic.GetComponent<Image>().color = temp;
        } else
        if (fade > 0)
        {
            Color temp = pic.GetComponent<Image>().color;
            fade -= difference * Time.deltaTime;
            temp.a = fade;
            pic.GetComponent<Image>().color = temp;
        } else
        {
            gameObject.SetActive(false);
        }*/
    }
}
