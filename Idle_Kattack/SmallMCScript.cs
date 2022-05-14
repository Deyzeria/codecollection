using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMCScript : MonoBehaviour
{
    GameObject BScriptHolder;
    public BattleScript BScript;

    private void Awake()
    {
        BScript = GameObject.FindWithTag("GameController").GetComponent<BattleScript>();
    }

    public void ContinueTrigger()
    {
        BScript.Continue = true;
    }
    
    public void AttackTrigger()
    {
        BScript.attackTrigger = true;
    }
}
