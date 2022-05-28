using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnEnd : MonoBehaviour
{
    public GameObject MainMenu;
    public void OnFinish()
    {
        MainMenu.GetComponent<MainMenu>().contAnim1();
    }

    public void OnFinish2()
    {
        MainMenu.GetComponent<MainMenu>().contAnim2();
    }
}
