using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SingleTabScript : MonoBehaviour
{
    public statusEnum Status;
    int statusInt = 0;
    public enum statusEnum { Damage, Armor, Income, Health, Passive, Crit, MultiAttack, Misc };
    public int thisItemNumber;
    public Button buttonThis;
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI priceText;
    public double priceNumber;

    private void Start()
    {
        confirmLevel();
    }

    void confirmLevel()
    {
        switch (Status)
        {
            case statusEnum.Damage:
                statusInt = 0;
                priceNumber = UpgradeListActive.Instance.upgradeCostsDamage[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsDamage[thisItemNumber]);
                numberText.SetText("Effect: + {0} <sprite=0>", UpgradeListActive.Instance.upgradeAmountDamage[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsDamage[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.Armor:
                statusInt = 1;
                priceNumber = UpgradeListActive.Instance.upgradeCostsArmor[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsArmor[thisItemNumber]);
                numberText.SetText("Effect: + {0} <sprite=1>", UpgradeListActive.Instance.upgradeAmountArmor[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsArmor[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.Income:
                priceNumber = UpgradeListActive.Instance.upgradeCostsIncome[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsIncome[thisItemNumber]);
                numberText.SetText("Effect: + {0} <sprite=4>", UpgradeListActive.Instance.upgradeAmountIncome[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsIncome[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.Passive:
                priceNumber = UpgradeListActive.Instance.upgradeCostsIncome[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsIncome[thisItemNumber]);
                numberText.SetText("Effect: + {0} <sprite=5>", UpgradeListActive.Instance.upgradeAmountIncome[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsIncome[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.Health:
                priceNumber = UpgradeListActive.Instance.upgradeCostsArmor[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsArmor[thisItemNumber]);
                numberText.SetText("Effect: + {0} <sprite=7>", UpgradeListActive.Instance.upgradeAmountArmor[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsArmor[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.Crit:
                priceNumber = UpgradeListActive.Instance.upgradeCostsMisc[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsMisc[thisItemNumber]);
                numberText.SetText("Effect: + {0} <sprite=3>", UpgradeListActive.Instance.upgradeAmountMisc[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsDamage[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.MultiAttack:
                priceNumber = UpgradeListActive.Instance.upgradeCostsMisc[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsMisc[thisItemNumber]);
                numberText.SetText("Effect: + {0} <sprite=9>", UpgradeListActive.Instance.upgradeAmountMisc[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsMisc[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            default:
                Debug.Log("Rip");
                statusInt = 999;
                break;
        }
    }

    public void UpdatePrices()
    {
        switch (Status)
        {
            case statusEnum.Damage:
                if (UpgradeListActive.Instance.upgradeLevelsDamage[thisItemNumber] < 1000)
                {
                    priceNumber = UpgradeListActive.Instance.upgradeCostsDamage[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsDamage[thisItemNumber]);
                    levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsDamage[thisItemNumber]);
                    priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                } else
                {
                    ShopScript.Instance.UnlockSword(thisItemNumber);
                }
                break;
            case statusEnum.Health:
            case statusEnum.Armor:
                priceNumber = UpgradeListActive.Instance.upgradeCostsArmor[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsArmor[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsArmor[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.Passive:
            case statusEnum.Income:
                priceNumber = UpgradeListActive.Instance.upgradeCostsIncome[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsIncome[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsIncome[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            case statusEnum.MultiAttack:
            case statusEnum.Crit:
            case statusEnum.Misc:
                priceNumber = UpgradeListActive.Instance.upgradeCostsMisc[thisItemNumber] * (1 + UpgradeListActive.Instance.upgradeLevelsMisc[thisItemNumber]);
                levelText.SetText("Level: {0}", UpgradeListActive.Instance.upgradeLevelsMisc[thisItemNumber]);
                priceText.SetText("Price: {0} <sprite=2>", (float)priceNumber);
                break;
            default:
                Debug.Log("Rip");
                break;
        }
    }
}
