using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetweenFightsScript : MonoBehaviour
{
    public static BetweenFightsScript Instance;

    public Button buttonLeft;
    public Image buttonLeftCooldown;

    public Button buttonMiddle;
    public Image buttonMiddleCooldown;

    public Button buttonRight;
    public Image buttonRightCooldown;

    //Make this a modifiable value that also automatically assigns to the background Quad
    //public GameObject backgroundQuad;
    public Material backgroundMaterial;

    public Animator MCAnimator;
    [HideInInspector]
    public Vector2 offsetB;
    bool battleWait = false;
    public bool Sprint;

    private void Awake()
    {
        Instance = this;
        backgroundMaterial.mainTextureOffset = new Vector2(0, 0);
    }

    public void HealthPotion()
    {
        gameObject.GetComponent<BattleScript>().HealingReceive();
        buttonLeftCooldown.fillAmount = 1;
        buttonLeft.interactable = false;
        StartCoroutine(HealthPotionCD());
    }

    public void SprintButton()
    {
        Sprint = true;
        buttonMiddle.interactable = false;
        buttonMiddleCooldown.fillAmount = 1;
        StartCoroutine(SprintButtonCD());
    }


    public void StrongAttackButton()
    {
        gameObject.GetComponent<BattleScript>().StrongAttackTrigger();
        buttonRight.interactable = false;
        buttonRightCooldown.fillAmount = 1;
        StartCoroutine(StrongAttackButtonCD());
    }

    IEnumerator SprintButtonCD()
    {
        for (float i = 14; i > -1; i--)
        {
            yield return new WaitForSecondsRealtime(1);
            buttonMiddleCooldown.GetComponent<Image>().fillAmount = i / 15;
        }
        buttonMiddle.interactable = true;
    }

    IEnumerator StrongAttackButtonCD()
    {
        for (float i = 14; i > -1; i--)
        {
            yield return new WaitForSecondsRealtime(1);
            buttonRightCooldown.GetComponent<Image>().fillAmount = i / 15;
        }
        buttonRight.interactable = true;
    }

    IEnumerator HealthPotionCD()
    {
        for(float i = 59; i > -1; i--)
        {
            yield return new WaitForSecondsRealtime(1);
            buttonLeftCooldown.GetComponent<Image>().fillAmount = i / 60;
        }
        buttonLeft.GetComponent<Button>().interactable = true;
    }

    private void FixedUpdate()
    {
        if (battleWait)
        {
            backgroundMaterial.mainTextureOffset += offsetB * Time.deltaTime;
        }
    }

    public void BetweenBattleWait()
    {
        float WaitTime = 0;
        if (Sprint)
        {
            WaitTime = 1;
            MCAnimator.SetFloat("Speed", 3);
            offsetB = new Vector2(0.8f, 0);
            Sprint = false;
        }
        else
        {
            offsetB = new Vector2(0.08f, 0);
            MCAnimator.SetFloat("Speed", 1);
            WaitTime = Random.Range(0, 15 - UpgradeListActive.Instance.waitReduction);
            WaitTime += 1;
        }
        Debug.Log(WaitTime);
        battleWait = true;
        StartCoroutine(WaitingTime(WaitTime));
    }

    IEnumerator WaitingTime(float WaitTime)
    {
        yield return new WaitForSecondsRealtime(WaitTime);
        battleWait = false;
        MCAnimator.SetFloat("Speed", 0);
        gameObject.GetComponent<BattleScript>().FightFound();
    }
}
