using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance;
    public Text texter;
    [HideInInspector]
    public long finalscore;
    int counter;
    byte level = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void startcor()
    {
        StartCoroutine("scorSystem");
    }

    public void stopCor()
    {
        StopCoroutine("scorSystem");
    }

    IEnumerator scorSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            finalscore++;
            counter++;
            texter.GetComponent<Text>().text = finalscore.ToString();

            if (finalscore == 50)
            {
                level = 2;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.DoTheSpawn();
                GameStageControl.Instance.SpeedIncrease();
            }

            if (finalscore == 100)
            {
                level = 1;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.DoTheSpawn();
                GameStageControl.Instance.SpeedIncrease();
            }

            if(counter == 200)
            {
                level = 2;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.DoTheSpawn();
                GameStageControl.Instance.SpeedIncrease();
            }

            if(counter == 300)
            {
                level = 1;
                GameStageControl.Instance.levelP = level;
                GameStageControl.Instance.DoTheSpawn();
                GameStageControl.Instance.SpeedIncrease();
                counter = 100;
            }

        }
    }
}
