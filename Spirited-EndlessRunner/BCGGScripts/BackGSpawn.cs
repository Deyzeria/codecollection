using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGSpawn : MonoBehaviour
{
    public List<GameObject> elementsLeft;
    public List<GameObject> ekementsRight;
    public List<Transform> points;
    public bool Left;
    public void DoIt()
    {
        if (Left)
        {
            GameObject box = Instantiate(elementsLeft[Random.Range(0, elementsLeft.Count)], new Vector3(points[0].transform.position.x, points[Random.Range(0, 2)].transform.position.y, points[0].transform.position.z), Quaternion.identity);
            BackgroundLeft bc = box.AddComponent(typeof(BackgroundLeft)) as BackgroundLeft;
            BoxCollider bxc = box.AddComponent(typeof(BoxCollider)) as BoxCollider;
            bc.speed = 10;
        }
        else
        {
            GameObject box = Instantiate(ekementsRight[Random.Range(0, ekementsRight.Count)], new Vector3(points[0].transform.position.x, points[Random.Range(0, 2)].transform.position.y, points[0].transform.position.z), Quaternion.identity);
            BackgroundLeft bc = box.AddComponent(typeof(BackgroundLeft)) as BackgroundLeft;
            BoxCollider bxc = box.AddComponent(typeof(BoxCollider)) as BoxCollider;
            bc.speed = 10;
        }
    }
}
