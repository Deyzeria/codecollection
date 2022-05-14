using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTabFull : MonoBehaviour
{
    public List<SingleTabScript> tabScriptList;
    public enum statusEnum { Damage, Armor, Income, Health, Passive, Crit, MultiAttack, Misc }

    public statusEnum Status;

    public void UpgradeTheItem(int number)
    {
        switch (tabScriptList[number].Status)
        {
            case SingleTabScript.statusEnum.Damage:
                Status = statusEnum.Damage;
                break;
            case SingleTabScript.statusEnum.Armor:
                Status = statusEnum.Armor;
                break;
            case SingleTabScript.statusEnum.Income:
                Status = statusEnum.Income;
                break;
            case SingleTabScript.statusEnum.Health:
                Status = statusEnum.Health;
                break;
            case SingleTabScript.statusEnum.Passive:
                Status = statusEnum.Passive;
                break;
            case SingleTabScript.statusEnum.Crit:
                Status = statusEnum.Crit;
                break;
            case SingleTabScript.statusEnum.MultiAttack:
                Status = statusEnum.MultiAttack;
                break;
        }
        switch (Status)
        {
            case statusEnum.Damage:
                MoneyScript.Instance.NumberToSubtract(UpgradeListActive.Instance.upgradeCostsDamage[number] * (1 + UpgradeListActive.Instance.upgradeLevelsDamage[number]));
                BattleScript.Instance.UpdateDamage(UpgradeListActive.Instance.upgradeAmountDamage[number]);
                UpgradeListActive.Instance.upgradeLevelsDamage[number]++;
                tabScriptList[number].UpdatePrices();
                break;

            case statusEnum.Armor:
                MoneyScript.Instance.NumberToSubtract(UpgradeListActive.Instance.upgradeCostsArmor[number] * (1 + UpgradeListActive.Instance.upgradeLevelsArmor[number]));
                BattleScript.Instance.UpdateArmor(UpgradeListActive.Instance.upgradeAmountArmor[number]);
                UpgradeListActive.Instance.upgradeLevelsArmor[number]++;
                tabScriptList[number].UpdatePrices();
                break;

            case statusEnum.Income:
                MoneyScript.Instance.NumberToSubtract(UpgradeListActive.Instance.upgradeCostsIncome[number] * (1 + UpgradeListActive.Instance.upgradeLevelsIncome[number]));
                MoneyScript.Instance.UpdateActiveIncome(UpgradeListActive.Instance.upgradeAmountIncome[number]);
                UpgradeListActive.Instance.upgradeLevelsIncome[number]++;
                tabScriptList[number].UpdatePrices();
                break;

            case statusEnum.Health:
                MoneyScript.Instance.NumberToSubtract(UpgradeListActive.Instance.upgradeCostsArmor[number] * (1 + UpgradeListActive.Instance.upgradeLevelsArmor[number]));
                BattleScript.Instance.UpdateHealth(UpgradeListActive.Instance.upgradeAmountArmor[number]);
                UpgradeListActive.Instance.upgradeLevelsArmor[number]++;
                tabScriptList[number].UpdatePrices();
                break;

            case statusEnum.Passive:
                MoneyScript.Instance.NumberToSubtract(UpgradeListActive.Instance.upgradeCostsIncome[number] * (1 + UpgradeListActive.Instance.upgradeLevelsIncome[number]));
                MoneyScript.Instance.UpdatePassiveIncome(UpgradeListActive.Instance.upgradeAmountIncome[number]);
                UpgradeListActive.Instance.upgradeLevelsIncome[number]++;
                tabScriptList[number].UpdatePrices();
                break;

            case statusEnum.Crit:
                MoneyScript.Instance.NumberToSubtract(UpgradeListActive.Instance.upgradeCostsMisc[number] * (1 + UpgradeListActive.Instance.upgradeLevelsMisc[number]));
                BattleScript.Instance.UpdateCrit(UpgradeListActive.Instance.upgradeAmountMisc[number]);
                UpgradeListActive.Instance.upgradeLevelsMisc[number]++;
                tabScriptList[number].UpdatePrices();
                break;

            case statusEnum.MultiAttack:
                MoneyScript.Instance.NumberToSubtract(UpgradeListActive.Instance.upgradeCostsMisc[number] * (1 + UpgradeListActive.Instance.upgradeLevelsMisc[number]));
                BattleScript.Instance.UpdateMultiAttack(UpgradeListActive.Instance.upgradeAmountMisc[number]);
                UpgradeListActive.Instance.upgradeLevelsMisc[number]++;
                tabScriptList[number].UpdatePrices();
                break;

            default:
                break;
        }
    }
}