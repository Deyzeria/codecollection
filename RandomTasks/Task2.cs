using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task2 : MonoBehaviour
{
    public Image SwitchImage;
    public List<Color> colors;
    int ohGodWhy;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(colorSwitch());
    }

    IEnumerator colorSwitch()
    {
        while (true)
        {
            SwitchImage.color = colors[ohGodWhy];
            ohGodWhy++;
            if(ohGodWhy >= colors.Count)
            {
                ohGodWhy = 0;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
