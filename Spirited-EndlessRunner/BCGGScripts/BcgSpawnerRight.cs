using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BcgSpawnerRight : MonoBehaviour
{
    public static BcgSpawnerRight instance;
    public List<GameObject> objForest;
    public List<GameObject> objFactory;
    public int level = 1;
    public List<Transform> pos;
    int speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startcor();
    }

    public void startcor()
    {
        StartCoroutine(ObjSpawning());
    }

    IEnumerator ObjSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int rnd = Random.Range(0, pos.Count);
            if (level == 1)
            {
                GameObject obj = Instantiate(objForest[Random.Range(0, objForest.Count)], new Vector3(pos[rnd].position.x, pos[rnd].position.y, pos[rnd].position.z), Quaternion.identity);
                obj.GetComponent<BCGmove>().speed = speed;
            }
            else
            {
                GameObject obj2 = Instantiate(objFactory[Random.Range(0, objFactory.Count)], new Vector3(pos[rnd].position.x, pos[rnd].position.y, pos[rnd].position.z), Quaternion.identity);
                obj2.GetComponent<BCGmove>().speed = speed;
            }
        }
    }
}
