using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public  GameObject savedDataHolder;
    public GameObject OverLayLoading;
    public GameObject gameTitle;
    public GameObject settingTable;
    public GameObject questionIfFirst;

    public bool firstPlaythrough;
    public bool startGame;

    private void Start()
    {
        settingTable.SetActive(false);
    }
    public void StartGame()
    {
        OverLayLoading.GetComponent<Animator>().SetTrigger("doit");
    }

    public void contQuCheckmark()
    {
        firstPlaythrough = !firstPlaythrough;
    }

    public void contAnim1()
    {
        if (startGame)
        {
            contAnim15();
        } else { questionIfFirst.SetActive(true); }

    }

    public void contAnim15()
    {
        if (!startGame)
        {
            questionIfFirst.SetActive(false);
            GameObject tempobj = Instantiate(savedDataHolder, new Vector2(0, 0), Quaternion.identity);
            tempobj.GetComponent<SavedData>().continuequ = false;
            tempobj.GetComponent<SavedData>().newGame = firstPlaythrough;
            tempobj.GetComponent<SavedData>().TemptStart();
        }
        
        gameTitle.GetComponent<Animator>().SetTrigger("doit");
    }

    public void contAnim2()
    {
        SceneManager.LoadScene(1);
    }

    public void EnableSettings(bool turnOnOff)
    {
        settingTable.SetActive(turnOnOff);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DemoVersion()
    {
        Application.OpenURL("https://sinantrarion.itch.io/the-lonely-souls");
    }

    public void LoadGame()
    {
        GameObject tempobj =  Instantiate(savedDataHolder, new Vector2(0, 0), Quaternion.identity);
        tempobj.GetComponent<SavedData>().continuequ = true;
        tempobj.GetComponent<SavedData>().TemptStart();
        startGame = true;
        StartGame();
    }
}
