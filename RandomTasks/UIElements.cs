using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    public Image HPBar;
    public Image MPBar;
    public Text HPText;
    public Text MPText;
    int HPMax, MPMax;
    int HPChange, MPChange;

    private void Start()
    {
        HPMax = transform.GetComponentInParent<Stats>().healthMax;
        MPMax = transform.GetComponentInParent<Stats>().manaMax;
        HPBar.fillAmount = 0;
        MPBar.fillAmount = 0;
    }

    private void FixedUpdate()
    {
        StatUpdate();
    }

    private void StatUpdate()
    {
        int HPCurr = transform.GetComponentInParent<Stats>().healthCurrent;
        int MPCurr = transform.GetComponentInParent<Stats>().manaCurrent;

        if (HPChange != HPCurr)
        {
            HPText.GetComponent<Text>().text = HPCurr.ToString();
            HPChange = HPCurr;
            //This shit needs to be done(Changing the HPBar and MPBar fillamount
            if (HPCurr != HPMax)
            {
                int diff = HPMax - HPCurr;
                int amount = (diff / HPMax);
                HPBar.fillAmount = amount; 
            }
        }

        if (MPChange != MPCurr) {
            MPText.GetComponent<Text>().text = MPCurr.ToString();
            MPChange = MPCurr;
            if (MPCurr != MPMax)
            {
                int diff = MPMax - MPCurr;
                int amount = (diff * 100 / HPMax) / 100;
            }
        }
    }
}
