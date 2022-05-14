using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuScripts : MonoBehaviour
{
    public enum statusEnum { Damage, Armor, Income, Misc }
    public statusEnum Status;
    public List<GameObject> TabsDamage;
    public List<GameObject> TabsArmor;
    public List<GameObject> TabsIncome;
    public List<GameObject> TabsMisc;
    int currentlyActive = 0;
    int currentPage = 0;
    public Button upButton;
    public Button downButton;

    // Start is called before the first frame update
    void Start()
    {
        if(currentPage == 0)
        {
            upButton.interactable = false;
        }
    }

    public void SwitchPage(int switchTo)
    {
        switch (currentlyActive)
        {
            case 0:
                TabsDamage[currentPage].SetActive(false);
                break;
            case 1:
                TabsArmor[currentPage].SetActive(false);
                break;
            case 2:
                TabsIncome[currentPage].SetActive(false);
                break;
            case 3:
                TabsMisc[currentPage].SetActive(false);
                break;
        }
        upButton.interactable = false;
        downButton.interactable = true;
        currentlyActive = switchTo;
        currentPage = 0;
        switch (currentlyActive)
        {
            case 0:
                TabsDamage[currentPage].SetActive(true);
                MoneyScript.Instance.currentStatus = MoneyScript.statusEnum.Damage;
                if (currentPage >= TabsDamage.Count - 1)
                {
                    downButton.interactable = false;
                } 
                break;
            case 1:
                TabsArmor[currentPage].SetActive(true);
                MoneyScript.Instance.currentStatus = MoneyScript.statusEnum.Armor;
                if (currentPage >= TabsArmor.Count - 1)
                {
                    downButton.interactable = false;
                }
                break;
            case 2:
                TabsIncome[currentPage].SetActive(true);
                MoneyScript.Instance.currentStatus = MoneyScript.statusEnum.Income;
                if (currentPage >= TabsIncome.Count - 1)
                {
                    downButton.interactable = false;
                }
                break;
            case 3:
                TabsMisc[currentPage].SetActive(true);
                MoneyScript.Instance.currentStatus = MoneyScript.statusEnum.Misc;
                if (currentPage >= TabsMisc.Count - 1)
                {
                    downButton.interactable = false;
                }
                break;
        }
        
        MoneyScript.Instance.checkPrices();
    }

    public void SwitchTab(bool downQues)
    {
        upButton.interactable = true;
        downButton.interactable = true;
        if (downQues)
        {
            switch (currentlyActive)
            {
                case 0:
                    TabsDamage[currentPage].SetActive(false);
                    currentPage++;
                    TabsDamage[currentPage].SetActive(true);
                    if (currentPage >= TabsDamage.Count - 1)
                    {
                        downButton.interactable = false;
                    }
                    break;
                case 1:
                    TabsArmor[currentPage].SetActive(false);
                    currentPage++;
                    TabsArmor[currentPage].SetActive(true);
                    if (currentPage >= TabsArmor.Count - 1)
                    {
                        downButton.interactable = false;
                    }
                    break;
                case 2:
                    TabsIncome[currentPage].SetActive(false);
                    currentPage++;
                    TabsIncome[currentPage].SetActive(true);
                    if (currentPage >= TabsIncome.Count - 1)
                    {
                        downButton.interactable = false;
                    }
                    break;
                case 3:
                    TabsMisc[currentPage].SetActive(false);
                    currentPage++;
                    TabsMisc[currentPage].SetActive(true);
                    if (currentPage >= TabsMisc.Count - 1)
                    {
                        downButton.interactable = false;
                    }
                    break;
                default:
                    break;
            }
        } else
        {
            switch (currentlyActive)
            {
                case 0:
                    TabsDamage[currentPage].SetActive(false);
                    currentPage--;
                    TabsDamage[currentPage].SetActive(true);
                    if (currentPage - 1 < 0)
                    {
                        upButton.interactable = false;
                    }
                    break;
                case 1:
                    TabsArmor[currentPage].SetActive(false);
                    currentPage--;
                    TabsArmor[currentPage].SetActive(true);
                    if (currentPage - 1 < 0)
                    {
                        upButton.interactable = false;
                    }
                    break;
                case 2:
                    TabsIncome[currentPage].SetActive(false);
                    currentPage--;
                    TabsIncome[currentPage].SetActive(true);
                    if (currentPage - 1 < 0)
                    {
                        upButton.interactable = false;
                    }
                    break;
                case 3:
                    TabsMisc[currentPage].SetActive(false);
                    currentPage--;
                    TabsMisc[currentPage].SetActive(true);
                    if (currentPage - 1 < 0)
                    {
                        upButton.interactable = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
