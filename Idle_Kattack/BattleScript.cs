using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BattleScript : MonoBehaviour
{
    public static BattleScript Instance;
    public Image MCHealthBar;
    public Image ENHealthBar;
    public List<GameObject> Chars;
    //public List<Vector2> CharPos;
    //public Vector2 targetPos;
    public List<GameObject> ActualCharacter;
    public List<GameObject> UIElements;
    public List<TextMeshProUGUI> StatsForList;

    [Space]
    public double MCHealth = 10;
    public double MCArmor = 0f;
    double currentMCHealth;
    public double MCDamage = 0.1d;
    public int multiAttackMC = 1;
    public int MCCritChance = 0;
    public int MCCritDamage = 2;
    public int MCSpeed = 0;

    [Space]
    public double ENHealth = 1;
    public double ENArmor = 0f;
    double currentENHealth;
    public double ENDamage = 0.1d;
    public int multiAttackEN = 1;
    public int ENCritChance = 0;
    public int ENSpeed = 0;

    [Space]
    public bool Continue = false;
    public bool StrongAttack = false;
    public bool attackTrigger = false;
    int critRoll = 0;
    //bool ReachedOld = true;
    int curTurn = 1;
    //int prevTurn = 0;
    bool fighting = true;
    public double wonEnemies = 0;
    float rangeR = 1;

    [Space]
    public GameObject currentLevel;
    public EnemyList GenericEnemyList;

    Animator MCAnim;
    Animator ENAnim;

    private void Awake()
    {
        Instance = this;
        currentMCHealth = MCHealth;
        currentLevel = GameObject.FindWithTag("CurrentLvl");
        GenericEnemyList = currentLevel.GetComponent<EnemyList>();
        MCAnim = ActualCharacter[0].GetComponent<Animator>();
    }

    private void Start()
    {
        ENHealth = 0.1;
        UpdateMCData();
        FightFound();
    }

    /*public void EnemyPassData(double HP, double Damage, int Speed)
    {
        ENHealth = HP;
        currentENHealth = ENHealth;
        ENDamage = Damage;
        ENSpeed = Speed;
    }*/

    void updateStatPage()
    {
        StatsForList[0].SetText("{0}/{1}<sprite=7>", (float)currentMCHealth, (float)MCHealth);
        StatsForList[1].SetText("{0}<sprite=0>", (float)MCDamage);
        StatsForList[2].SetText("{0}<sprite=1>", (float)MCArmor);
        StatsForList[3].SetText("{0} <sprite=9>", multiAttackMC);
        StatsForList[4].SetText("{0} <sprite=3>", MCCritChance);
        StatsForList[5].SetText("{0} <sprite=3>%", MCCritDamage*100);
        StatsForList[6].SetText("{0} <sprite=8>", MCSpeed);
    }

    //ONLY happens on the very start. It loads everything from stats
    public void UpdateMCData()
    {
        MCDamage = 0;

        //Will not work, because within the upgrade there are many other types of upgrades. Either rewrite it here, like make more checks, or throw it away and make separate lists for Health, Armor and so on.
        for (int i = 0; i< UpgradeListActive.Instance.upgradeLevelsDamage.Count; i++)
        {
            MCDamage += UpgradeListActive.Instance.upgradeLevelsDamage[i] * (float)UpgradeListActive.Instance.upgradeAmountDamage[i];
            MCDamage = System.Math.Round(MCDamage, 2);
        }
        MCArmor = 0;
        for (int i = 0; i < UpgradeListActive.Instance.upgradeLevelsArmor.Count; i++)
        {
            MCArmor += UpgradeListActive.Instance.upgradeLevelsArmor[i] * (float)UpgradeListActive.Instance.upgradeAmountArmor[i];
            MCArmor = System.Math.Round(MCArmor, 2);
        }

        updateStatPage();
    }

    //Updates for different datas- when you upgrade something, call those and input the amount of increase;
    public void UpdateDamage(float damageTemp)
    {
        MCDamage += damageTemp;
        MCDamage = System.Math.Round(MCDamage, 2);
        updateStatPage();
    }

    public void UpdateArmor(float armorTemp)
    {
        MCArmor += armorTemp;
        MCArmor = System.Math.Round(MCArmor, 2);
        updateStatPage();
    }

    public void UpdateHealth(float healthTemp)
    {
        MCHealth += healthTemp;
        currentMCHealth += healthTemp;
        MCHealth = System.Math.Round(MCHealth, 2);
        currentMCHealth = System.Math.Round(currentMCHealth, 2);
        updateStatPage();
    }

    public void UpdateCrit(int critTemp)
    {
        MCCritChance += critTemp;
        updateStatPage();
    }

    public void UpdateMultiAttack(int multiAttackTemp)
    {
        multiAttackMC += multiAttackTemp;
        updateStatPage();
    }



    public void StartFight() //Trigger on Screen Press
    {
        UIElements[7].GetComponent<Button>().interactable = false; //Fight button disable
        UIElements[10].SetActive(false);

        UIElements[0].SetActive(true); //Activating Cubes that show the result of the Speed roll
        UIElements[1].SetActive(true); //Activating Cubes that show the result of the Speed roll

        int MCInitResult = Random.Range(1, 21);
        UIElements[2].GetComponent<Text>().text = MCInitResult.ToString() + " <color=green>+ " + MCSpeed + "</color>";
        int ENInitResult = Random.Range(1, 21);
        UIElements[3].GetComponent<Text>().text = ENInitResult.ToString() + " <color=green>+ " + ENSpeed + "</color>";

        MCInitResult += MCSpeed;
        ENInitResult += ENSpeed;

        if (MCInitResult > ENInitResult)
        {
            curTurn = 0;
        }
        else
        {
            curTurn = 1;
        }
        fighting = true;
        StartCoroutine(Fight());
    }

    IEnumerator Fight()
    {
        while (fighting)
        {
            Chars[curTurn].GetComponent<Animator>().SetTrigger("Trigger");
            ActualCharacter[curTurn].GetComponent<Animator>().SetFloat("Speed", 1);
            yield return new WaitUntil(() => Continue);
            ActualCharacter[curTurn].GetComponent<Animator>().SetFloat("Speed", 0);
            Continue = false;

            if (curTurn == 0)
            {
                for (int i = 0; i < multiAttackMC && currentENHealth > 0; i++)
                {
                    if (StrongAttack)
                    {
                        StrongAttack = false;
                        critRoll = 0;
                        MCAnim.SetTrigger("CritTrigger");
                    }
                    else
                    {
                        critRoll = Random.Range(0, 101);
                        MCAnim.SetTrigger("AttackTrigger");
                    }
                    yield return new WaitUntil(() => attackTrigger);
                    attackTrigger = false;
                    if(currentENHealth > 0)
                    {
                        ENAnim.SetTrigger("Damaged");
                    }

                    // +- damage dealt
                    double tempDamageMin = MCDamage - (MCDamage * 0.1f);
                    double tempDamageMax = MCDamage + (MCDamage * 0.1f);
                    double tempDamageDealt = Random.Range((float)tempDamageMin, (float)tempDamageMax);

                    //If Crit rolled
                    if (critRoll <= MCCritChance)
                    {
                        tempDamageDealt *= MCCritDamage;
                        UIElements[8].GetComponent<TextMeshProUGUI>().color = Color.red;
                        UIElements[8].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                    }
                    else
                    {
                        UIElements[8].GetComponent<TextMeshProUGUI>().color = Color.yellow;
                        UIElements[8].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                    }
                    //Rounding for better numbers
                    tempDamageDealt = System.Math.Round(tempDamageDealt, 2);
                    if (tempDamageDealt - ENArmor > 0)
                    {
                        tempDamageDealt -= ENArmor;
                    }
                    else
                    {
                        tempDamageDealt = 0;
                    }
                    currentENHealth -= tempDamageDealt;

                    UIElements[8].GetComponent<TextMeshProUGUI>().SetText("-{0}", (float)tempDamageDealt);
                    UIElements[8].GetComponent<Animator>().SetTrigger("Trigger");
                    double hpBarFill;
                    hpBarFill = currentENHealth / ENHealth;
                    ENHealthBar.fillAmount = (float)hpBarFill;

                    Chars[curTurn].GetComponent<Animator>().SetTrigger("Trigger");
                    yield return new WaitUntil(() => Continue);
                    attackTrigger = false;
                    Continue = false;
                    curTurn = 1;
                }
            }
            else
            {

                //Enemy attacks Main Character
                for (int i = 0; i < multiAttackEN && currentMCHealth > 0; i++)
                {
                    ENAnim.SetTrigger("AttackTrigger");
                    yield return new WaitUntil(() => attackTrigger);
                    attackTrigger = false;
                    MCAnim.SetTrigger("Damaged");
                    double damageDealt;
                    if (ENDamage - MCArmor > 0)
                    {
                        damageDealt = ENDamage - MCArmor;
                    }
                    else
                    {
                        damageDealt = 0;
                    }
                    currentMCHealth -= damageDealt;

                    UIElements[9].GetComponent<TextMeshProUGUI>().color = Color.yellow;
                    UIElements[9].GetComponent<TextMeshProUGUI>().SetText("-{0}", (float)damageDealt);
                    UIElements[9].GetComponent<Animator>().SetTrigger("Trigger");
                    double hpBarFill = currentMCHealth / MCHealth;
                    MCHealthBar.fillAmount = (float)hpBarFill;

                    Chars[curTurn].GetComponent<Animator>().SetTrigger("Trigger");
                    yield return new WaitUntil(() => Continue);
                    attackTrigger = false;
                    Continue = false;
                    curTurn = 0;
                }
            }

            if (currentMCHealth <= 0 || currentENHealth <= 0)
            {
                UIElements[0].SetActive(false);
                UIElements[1].SetActive(false);
                if (currentENHealth <= 0) // Enemy lost
                {
                    ENAnim.SetBool("Dead", true);
                    yield return new WaitUntil(() => Continue);
                    Continue = false;
                    attackTrigger = false;
                    fighting = false;
                    if (wonEnemies == 10)
                    {
                        MCAnim.SetInteger("Status", 1);
                        MoneyScript.Instance.NumberToAddBoss();
                        //BetweenFightsScript.Instance.BetweenBattleWait();
                    } else
                    {
                        Destroy(ActualCharacter[1].gameObject);
                        wonEnemies++;
                        MoneyScript.Instance.NumberToAddNormal();
                        BetweenFightsScript.Instance.BetweenBattleWait();
                    }
                }
                else // Hero lost
                {
                    MCAnim.SetInteger("Status", -1);
                    fighting = false;
                    // Lost Condition here
                }
            }
        }
    }


    //============================================================================================================================================ \\

    public void FightFound()
    {
        GameObject Enemy;
        if (wonEnemies == 10)
        {
            ENHealth = ENHealth * 4;
            ENHealth = System.Math.Round(ENHealth, 2);
            currentENHealth = ENHealth;

            ENDamage = ENDamage * 2;
            ENDamage = System.Math.Round(ENDamage, 2);

            ENArmor = ENArmor * 2;
            ENArmor = System.Math.Round(ENArmor, 4);

            ENHealthBar.fillAmount = 1;
            Enemy = Instantiate(GenericEnemyList.Boss, Chars[1].transform.position, Quaternion.identity);
        } else
        {
            ENHealth = ENHealth * Random.Range(rangeR, rangeR + 1);
            ENHealth = System.Math.Round(ENHealth, 2);
            currentENHealth = ENHealth;

            ENDamage = ENDamage * Random.Range(rangeR, rangeR + 0.5f);
            ENDamage = System.Math.Round(ENDamage, 2);

            ENArmor = ENArmor * Random.Range(rangeR, rangeR + 0.3f);
            ENArmor = System.Math.Round(ENArmor, 4);

            ENHealthBar.fillAmount = 1;
            Enemy = Instantiate(GenericEnemyList.GenericEnemy[Random.Range(0, GenericEnemyList.GenericEnemy.Count)], Chars[1].transform.position, Quaternion.identity);
        }
        
        ActualCharacter[1] = Enemy;
        ENAnim = ActualCharacter[1].GetComponent<Animator>();
        RectTransform rt = Enemy.GetComponent<RectTransform>();
        Enemy.transform.SetParent(Chars[1].transform, true);

        rt.anchoredPosition= new Vector2(Enemy.GetComponent<CoordinateScript>().vectorXOffset, Enemy.GetComponent<CoordinateScript>().vectorYOffset);
        rt.localScale = new Vector3(Enemy.GetComponent<CoordinateScript>().scaleOffset, Enemy.GetComponent<CoordinateScript>().scaleOffset, 1);
        //Chars[1].SetActive(true);


        //Here add the check for having an upgradde to autoskip the start
        UIElements[7].GetComponent<Button>().interactable = true;
        UIElements[10].SetActive(true);
        
    }



    //============================================================================================================================================ \\

    public void StrongAttackTrigger()
    {
        StrongAttack = true;
    }

    public void HealingReceive()
    {
        double healingTemp = UpgradeListActive.Instance.healingPotion;
        if (currentMCHealth + healingTemp >= MCHealth)
        {
            currentMCHealth = MCHealth;
        }
        else
        {
            currentMCHealth += healingTemp;
        }
        double hpBarFill = currentMCHealth / MCHealth;
        MCHealthBar.fillAmount = (float)hpBarFill;
        UIElements[9].GetComponent<TextMeshProUGUI>().color = Color.green;
        UIElements[9].GetComponent<TextMeshProUGUI>().SetText("+{0}", (float)healingTemp);
        UIElements[9].GetComponent<Animator>().SetTrigger("Trigger");
    }
}