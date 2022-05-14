using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeListActive : MonoBehaviour
{
    public static UpgradeListActive Instance;

    public bool autoStart = false;
    public float waitReduction;

    [Space]
    public List<int> upgradeLevelsDamage;
    public List<double> upgradeCostsDamage;
    public List<float> upgradeAmountDamage;


    [Space]
    public List<int> upgradeLevelsArmor;
    public List<double> upgradeCostsArmor;
    public List<float> upgradeAmountArmor;

    [Space]
    public List<int> upgradeLevelsIncome;
    public List<double> upgradeCostsIncome;
    public List<float> upgradeAmountIncome;

    [Space]
    public List<int> upgradeLevelsMisc;
    public List<double> upgradeCostsMisc;
    public List<int> upgradeAmountMisc;

    [Space]
    public double healingPotion = 100;

    private void Awake()
    {
        Instance = this;
    }
}
