using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public static ShopScript Instance;
    public List<Button> Swords;
    public List<GameObject> SwordGO;

    private void Awake()
    {
        Instance = this;
    }

    public void UnlockSword(int whichSword)
    {
        if (Swords[whichSword] != null)
        {
            Swords[whichSword].interactable = true;
        }
    }

    public void ChangeSword(int whichSword)
    {
        for (int i = 0; i < SwordGO.Count; i++)
        {
            SwordGO[i].SetActive(false);
        }
        SwordGO[whichSword].SetActive(true);
    }
}
