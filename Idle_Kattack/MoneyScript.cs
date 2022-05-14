using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BreakInfinity;


public class MoneyScript : MonoBehaviour
{
    public enum statusEnum { Damage, Armor, Income, Misc }
    public statusEnum currentStatus;
    public static MoneyScript Instance;
    public int GameState = 0;
    public TextMeshProUGUI DisplayedNumber;
    public TextMeshProUGUI DisplayedNumber2;
    public double moneyNumber;
    public double activeIncome = 5;
    public double passiveIncome = 0;
    public bool menuOn = true;

    BigDouble totalAmountCollected;
    //0.42e2 = 42 || 42e2 = 4200
    public List<Button> damageUpgradeButton;
    public List<Button> armorUpgradeButton;
    public List<Button> incomeUpgradeButton;
    public List<Button> miscUpgradeButton;

    public TextMeshProUGUI actInc;
    public TextMeshProUGUI pasInc;

    //Save this too
    public TextMeshProUGUI totalCollected;

    private void Start()
    {
        Instance = this;

        activeIncome = 0;
        for (int i = 0; i < UpgradeListActive.Instance.upgradeLevelsIncome.Count; i++)
        {
            activeIncome += UpgradeListActive.Instance.upgradeLevelsIncome[i] * (float)UpgradeListActive.Instance.upgradeAmountIncome[i];
            //activeIncome = Mathf.Round((float)activeIncome * 100f) / 100f;
        }

        //activeIncome = Mathf.Round(activeIncome);

        string tempString = moneyNumber.ToString("G4");
        DisplayedNumber.SetText(tempString);
        DisplayedNumber2.SetText(tempString);


        checkPrices();

        StartCoroutine(PassiveIncome());
        menuOn = false;

        StatsUpdate();
    }

    public void UpdateActiveIncome(float incomeTemp)
    {
        activeIncome += incomeTemp;
        StatsUpdate();
    }

    public void UpdatePassiveIncome(float incomeTemp)
    {
        passiveIncome += incomeTemp;
        StatsUpdate();
    }

    //This must be called from buttons
    public void SwitchBool(bool temp)
    {
        menuOn = temp;
        if (menuOn)
        {
            checkPrices();
        }
    }

    public void NumberToAddNormal()
    {
        moneyNumber += activeIncome;
        totalAmountCollected += activeIncome;
        string tempString = moneyNumber.ToString("G4");
        DisplayedNumber.SetText(tempString);
        DisplayedNumber2.SetText(tempString);
        checkPrices();
    }

    public void NumberToAddBoss()
    {
        moneyNumber += activeIncome * 10;
        totalAmountCollected += activeIncome * 10;
        string tempString = moneyNumber.ToString("G4");
        DisplayedNumber.SetText(tempString);
        DisplayedNumber2.SetText(tempString);
        StatsUpdate();
    }

    public void NumberToSubtract(double sumToSubt)
    {
        moneyNumber -= sumToSubt;
        string tempString = moneyNumber.ToString("G4");
        DisplayedNumber.SetText(tempString);
        DisplayedNumber2.SetText(tempString);
        checkPrices();
    }

    public void checkPrices()
    {
        if (menuOn)
        {
            switch (currentStatus)
            {
                case statusEnum.Damage:
                    for (int i = 0; i < damageUpgradeButton.Count; i++)
                    {
                        if (UpgradeListActive.Instance.upgradeLevelsDamage[i] < 1000)
                        {
                            if (moneyNumber >= UpgradeListActive.Instance.upgradeCostsDamage[i] * (1 + UpgradeListActive.Instance.upgradeLevelsDamage[i]))
                            {
                                damageUpgradeButton[i].interactable = true;
                            }
                            else
                            {
                                damageUpgradeButton[i].interactable = false;
                            }
                        } else
                        {
                            damageUpgradeButton[i].interactable = false;
                        }
                    }
                    break;

                case statusEnum.Armor:
                    for (int i = 0; i < armorUpgradeButton.Count; i++)
                    {
                        if (moneyNumber >= UpgradeListActive.Instance.upgradeCostsArmor[i] * (1 + UpgradeListActive.Instance.upgradeLevelsArmor[i]))
                        {
                            armorUpgradeButton[i].interactable = true;
                        }
                        else
                        {
                            armorUpgradeButton[i].interactable = false;
                        }
                    }
                    break;

                case statusEnum.Income:
                    for (int i = 0; i < incomeUpgradeButton.Count; i++)
                    {
                        if (moneyNumber >= UpgradeListActive.Instance.upgradeCostsIncome[i] * (1 + UpgradeListActive.Instance.upgradeLevelsIncome[i]))
                        {
                            incomeUpgradeButton[i].interactable = true;
                        }
                        else
                        {
                            incomeUpgradeButton[i].interactable = false;
                        }
                    }
                    break;

                case statusEnum.Misc:
                    for (int i = 0; i < miscUpgradeButton.Count; i++)
                    {
                        if (moneyNumber >= UpgradeListActive.Instance.upgradeCostsMisc[i] * (1 + UpgradeListActive.Instance.upgradeLevelsMisc[i]))
                        {
                            miscUpgradeButton[i].interactable = true;
                        }
                        else
                        {
                            miscUpgradeButton[i].interactable = false;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
    }


    IEnumerator PassiveIncome()
    {
        while(true)
        {
            moneyNumber += passiveIncome * 5;
            totalAmountCollected += passiveIncome * 5;
            string tempString = moneyNumber.ToString("G4");
            DisplayedNumber.SetText(tempString);
            DisplayedNumber2.SetText(tempString);
            checkPrices();
            StatsUpdate();

            yield return new WaitForSecondsRealtime(5f);
        }
    }

    void StatsUpdate()
    {
        string tempString = activeIncome.ToString("G4");
        tempString += "<sprite=4>";
        actInc.SetText(tempString);
        tempString = passiveIncome.ToString("G4");
        tempString += "<sprite=5>";
        pasInc.SetText(tempString);
        tempString = totalAmountCollected.ToString("G4");
        tempString += "<sprite=2>";
        totalCollected.SetText(tempString);
    }

}
