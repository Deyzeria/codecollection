using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseTheDeath : MonoBehaviour
{
    public static PauseTheDeath Instance;
    public Image DeadImage;
    public GameObject Menu;
    public GameObject DeathMenu;
    public GameObject PauseButton;
    public GameObject settingsMenu;
    bool settingsOn = false;
    public float musicAVolume = 1;
    public float soundAVolume = 1;
    public Slider musicASlider;
    public Slider soundASlider;

    public GameObject scoreText;
    public GameObject PButton;

    public GameObject Tutorial;

    public Text DeathText, DeathTextBack;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        Tutorial.SetActive(true);
        scoreText.SetActive(true);
        PButton.SetActive(true);
        if (Settings.Instance != null)
        {
            Settings.Instance.TurnOnSound();
        }
        
        Menu.SetActive(false);
        DeathMenu.SetActive(false);

        if (Settings.Instance != null)
        {
            musicAVolume = Settings.Instance.musicVolume;
            soundAVolume = Settings.Instance.soundVolume;

            musicASlider.GetComponent<Slider>().value = musicAVolume;
            soundASlider.GetComponent<Slider>().value = soundAVolume;
        }
    }

    public void StartTheGame()
    {
        Tutorial.SetActive(false);
        GameStageControl.Instance.AllAboardTheSkipIsStarting();
        ScoreSystem.Instance.startcor();
    }

    public void FindAllAndFreeze()
    {
        scoreText.SetActive(false);
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Blocks");
        foreach (GameObject Blockk in objs)
        {
            Blockk.GetComponent<ObjectMovement>().speed = 0;
        }

        GameObject[] objs2;
        objs2 = GameObject.FindGameObjectsWithTag("Backgrounds");
        foreach (GameObject Blockk in objs2)
        {
            Blockk.GetComponent<BCGmove>().speed = 0;
        }

        GameStageControl.Instance.turnGame(false);
        ScoreSystem.Instance.stopCor();
        BcgSpawner.instance.StopAllCoroutines();
        BcgSpawnerRight.instance.StopAllCoroutines();

        PauseButton.SetActive(false);
        //DeadImage.GetComponent<Animator>().SetTrigger("Dead");

        DeathMenu.SetActive(true);
        DeathText.GetComponent<Text>().text = ScoreSystem.Instance.finalscore.ToString();
        DeathTextBack.GetComponent<Text>().text = ScoreSystem.Instance.finalscore.ToString();

    }

    public void ChangeMusic()
    {
        musicAVolume = musicASlider.GetComponent<Slider>().value;
        Settings.Instance.GetComponent<AudioSource>().volume = musicAVolume;
    }

    public void ChangeSound()
    {
        soundAVolume = soundASlider.GetComponent<Slider>().value;
    }

    private IEnumerator SwitchToLevel(int scenen)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scenen);
    }

    public void SettingsMenu()
    {
        if (settingsOn == false)
        {
            settingsMenu.SetActive(true);
            Menu.SetActive(false);
            settingsOn = true;
        }
        else
        {
            settingsMenu.SetActive(false);
            Menu.SetActive(true);
            settingsOn = false;
        }
    }

    public void StartGame()
    {
        //DeadImage.GetComponent<Animator>().SetTrigger("NewGamePlus");
        Settings.Instance.ChangeMusicClip(1);
        DeathMenu.SetActive(false);
        StartCoroutine(SwitchToLevel(1));
    }

    public void StopWaitAMinute()
    {
        GameStageControl.Instance.turnGame(false);

        scoreText.SetActive(false);
        Settings.Instance.Jump.enabled = false;
        Settings.Instance.Sound.enabled = false;

        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Blocks");
        foreach (GameObject Blockk in objs)
        {
            Blockk.GetComponent<ObjectMovement>().speed = 0;
        }

        GameObject[] objs2;
        objs2 = GameObject.FindGameObjectsWithTag("Backgrounds");
        foreach (GameObject Blockk in objs2)
        {
            Blockk.GetComponent<BCGmove>().speed = 0;
        }
        ScoreSystem.Instance.stopCor();
        BcgSpawner.instance.StopAllCoroutines();
        BcgSpawnerRight.instance.StopAllCoroutines();

        PauseButton.SetActive(false);
        //DeadImage.GetComponent<Animator>().SetTrigger("Paused");
        //DeadImage.GetComponent<Animator>().SetBool("Paus", true);
        Movement.Instance.pauseAnim(0);
        Menu.SetActive(true);
    }

    public void resumeDatShit()
    {
        GameStageControl.Instance.turnGame(true);

        scoreText.SetActive(true);
        Settings.Instance.Jump.enabled = true;
        Settings.Instance.Sound.enabled = true;
        GameObject[] objs;
        objs = GameObject.FindGameObjectsWithTag("Blocks");
        foreach (GameObject Blockk in objs)
        {
            Blockk.GetComponent<ObjectMovement>().speed = GameStageControl.Instance.globalSpeed;
        }

        GameObject[] objs2;
        objs2 = GameObject.FindGameObjectsWithTag("Backgrounds");
        foreach (GameObject Blockk in objs2)
        {
            Blockk.GetComponent<BCGmove>().speed = GameStageControl.Instance.globalSpeed;
        }

        ScoreSystem.Instance.startcor();
        BcgSpawner.instance.startcor();
        BcgSpawnerRight.instance.startcor();


        PauseButton.SetActive(true);
        //DeadImage.GetComponent<Animator>().ResetTrigger("Paused");
        //DeadImage.GetComponent<Animator>().SetBool("Paus", false);
        Movement.Instance.pauseAnim(1);
        Menu.SetActive(false);
    }

    public void Quit()
    {
        Settings.Instance.ChangeMusicClip(3);
        StartCoroutine(SwitchToLevel(0));
    }
}
