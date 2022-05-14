using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button barOpener;
    public GameObject rightMenu;
    public GameObject shopMenu;
    public GameObject UpgradeMenu;

    public GameObject settingMenu;
    public GameObject statsMenu;


    public void RightMenuTrigger()
    {
        rightMenu.GetComponent<Animator>().SetTrigger("SwitchPosition");
    }

    public void ShopMenuTrigger(bool cond)
    {
        shopMenu.GetComponent<Animator>().SetTrigger("SwitchPosition");
        barOpener.interactable = cond;
    }

    public void StatsMenuTrigger(bool cond)
    {
        statsMenu.GetComponent<Animator>().SetTrigger("SwitchPosition");
        barOpener.interactable = cond;
    }

    public void UpgradeMenuTrigger(bool cond)
    {
        UpgradeMenu.GetComponent<Animator>().SetTrigger("SwitchPosition");
        barOpener.interactable = cond;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
