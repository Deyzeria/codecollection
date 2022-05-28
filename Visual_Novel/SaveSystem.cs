using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //This entire code was written in a fewer state of rush.
    //It features awful conversions from Bool to Int and back, so please, for the love of god, just ignore it.
    //If I had more time, it would have been much better, but, well, it is how it is ;_;
    public static void SavePlayer(int currentStage, bool newGame, int Relat0, int Relat1, int Relat2, bool Cause1, bool Cause2, bool Cause3)
    {
        
        PlayerPrefs.SetInt("currentStage", currentStage);
        if (newGame)
        {
            PlayerPrefs.SetInt("NewGame", 1);
        } else
        {
            PlayerPrefs.SetInt("NewGame", 0);
        }
        PlayerPrefs.SetInt("Relat0", Relat0);
        PlayerPrefs.SetInt("Relat1", Relat1);
        PlayerPrefs.SetInt("Relat2", Relat2);
        if (Cause1)
        {
            PlayerPrefs.SetInt("Cause1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Cause1", 0);
        }
        if (Cause2)
        {
            PlayerPrefs.SetInt("Cause2", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Cause2", 0);
        }
        if (Cause3)
        {
            PlayerPrefs.SetInt("Cause3", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Cause3", 0);
        }

        Debug.Log("Game Saved");
        Debug.Log(PlayerPrefs.GetInt("currentStage") + " Current Stage");
    }
}
