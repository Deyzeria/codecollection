using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SwitchLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
