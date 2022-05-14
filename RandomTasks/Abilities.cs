using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Abilities : MonoBehaviour
{
    public List<AbilityData> abilitiesPanel1;
    public List<AbilityData> abilitiesPanel2;
    public List<AbilityData> abilitiesPanel3;
    public List<AbilityData> abilitiesPanel4;
    public List<AbilityData> abilitiesPanel5;
    public List<KeyCode> abilPanel1KeyCodes;
    public List<KeyCode> abilPanel2KeyCodes;
    public List<KeyCode> abilPanel3KeyCodes;
    public List<KeyCode> abilPanel4KeyCodes;
    public List<KeyCode> abilPanel5KeyCodes;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 10; i++)
        {
            if (abilitiesPanel1.Count < 10) { abilitiesPanel1.Add(null); }
            if (abilitiesPanel2.Count < 10) { abilitiesPanel2.Add(null); }
            if (abilitiesPanel3.Count < 10) { abilitiesPanel3.Add(null); }
            if (abilitiesPanel4.Count < 10) { abilitiesPanel4.Add(null); }
            if (abilitiesPanel5.Count < 10) { abilitiesPanel5.Add(null); }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}

