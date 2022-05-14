using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOLMoney : MonoBehaviour
{
    public static DDOLMoney Instance;


    private void Awake()
    {
        if(DDOLMoney.Instance == null)
        {
            Debug.Log("Start");
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.Log("Finish");
            Destroy(this.gameObject);
        }
    }
}
