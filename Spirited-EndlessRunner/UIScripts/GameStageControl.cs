using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageControl : MonoBehaviour
{
    public static GameStageControl Instance;
    public GameObject mainGround;
    public GameObject leftGround;
    public GameObject rightGround;

    public SpawnerTwo grassBiome;
    public SpawnerTwo factoryBiome;

    public Material grassMain;
    public Material grassBack;

    public Material factoryMain;
    public Material factoryBackL;
    public Material factoryBackR;

    public float left, middle, right;
    public float globalSpeed;

    string whichLevel;

    public byte levelP = 1;
    [HideInInspector]
    public GameObject flasher;



    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        ChangeSpeed(globalSpeed);
    }

    public void AllAboardTheSkipIsStarting()
    {
        grassBiome.gameOn = true;
        grassBiome.StartTheGame();
    }

    public void turnGame(bool turnGameBool)
    {
        if (turnGameBool)
        {
            mainGround.GetComponent<GroundShaper>().scrollSpeed = middle;
            leftGround.GetComponent<GroundShaper>().scrollSpeed = left;
            rightGround.GetComponent<GroundShaper>().scrollSpeed = right;
            if(levelP == 1)
            {
                grassBiome.gameOn = true;
                grassBiome.StartTheGame();
            } else
            {
                factoryBiome.gameOn = true;
                factoryBiome.StartTheGame();
            }
        } else
        {
            grassBiome.gameOn = false;
            factoryBiome.gameOn = false;
            grassBiome.StopAllCoroutines();
            factoryBiome.StopAllCoroutines();
            mainGround.GetComponent<GroundShaper>().scrollSpeed = 0;
            leftGround.GetComponent<GroundShaper>().scrollSpeed = 0;
            rightGround.GetComponent<GroundShaper>().scrollSpeed = 0;
        }

    }

    public void ChangeSpeed(float curGlSp)
    {
        grassBiome.objSpeed = curGlSp;
        factoryBiome.objSpeed = curGlSp;
    }

    public void DoTheSpawn()
    {
        grassBiome.gameOn = false;
        factoryBiome.gameOn = false;
        PipeSpawn.Instance.SpawnThePipe();
        PipeSpawn.Instance.speed += 5;

    }

    public IEnumerator PipeReached()
    {
        Debug.Log("Started");
        //flasher.GetComponent<Animator>().SetTrigger("Flash");
        GameObject[] objs2;
        objs2 = GameObject.FindGameObjectsWithTag("Backgrounds");
        foreach (GameObject Blockk in objs2)
        {
            Destroy(Blockk);
        }
        if (levelP == 1)
        {
            Settings.Instance.ChangeMusicClip(1);
            yield return new WaitForSeconds(2f);
            mainGround.GetComponent<MeshRenderer>().material = grassMain;
            leftGround.GetComponent<MeshRenderer>().material = grassBack;
            rightGround.GetComponent<MeshRenderer>().material = grassBack;
            grassBiome.gameOn = true;
            grassBiome.StartTheGame();

            BcgSpawner.instance.level = 1;
            BcgSpawnerRight.instance.level = 1;
        } else if(levelP == 2)
        {
            Settings.Instance.ChangeMusicClip(2);
            yield return new WaitForSeconds(2f);
            mainGround.GetComponent<MeshRenderer>().material = factoryMain;
            leftGround.GetComponent<MeshRenderer>().material = factoryBackL;
            rightGround.GetComponent<MeshRenderer>().material = factoryBackR;
            factoryBiome.gameOn = true;
            factoryBiome.StartTheGame();

            BcgSpawner.instance.level = 2;
            BcgSpawnerRight.instance.level = 2;
        }
    }

    public void SpeedIncrease()
    {
        globalSpeed += 5;
        ChangeSpeed(globalSpeed);
        left += 0.3f;
        middle += 1;
        right += 0.3f;
        mainGround.GetComponent<GroundShaper>().scrollSpeed = middle;
        leftGround.GetComponent<GroundShaper>().scrollSpeed = left;
        rightGround.GetComponent<GroundShaper>().scrollSpeed = right;
    }
}
