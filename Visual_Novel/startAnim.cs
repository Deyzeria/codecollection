using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startAnim : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Image>().enabled = true;
    }

    public void DestroyOnFinishAnim()
    {
        ChatBox_Filler.Instance.StartGame();
        Destroy(gameObject);
    }
}
