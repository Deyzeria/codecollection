using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Circle;
    public GameObject Line;
    public GameObject Square;
    public GameObject Triangle;
    [Space]
    public List<GameObject> obj;
    [Space]
    public Gradient colorsForMain;
    public Gradient colorsForSupport;
    [Space]
    public GameObject Mark1;
    public GameObject Mark2;

    float rand, rand2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Circle
            SpawnFigures(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Square
            SpawnFigures(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Line
            SpawnFigures(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Triangle
            SpawnFigures(4);
        }
    }

    void SpawnFigures(int pressed)
    {
        if (obj[0]!= null)
        {
            for (int i= 0; i<5; i++)
            {
                Destroy(obj[i]);
            }
        }
        if (pressed == 1)
        {
            GameObject Circ = Instantiate(Circle, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(5f, 15f);
            Circ.transform.localScale = new Vector3(rand, 0.001f, rand);
            Circ.GetComponent<Renderer>().material.SetColor("_Color", colorsForMain.Evaluate(Random.value));
            obj[0] = Circ;

            GameObject Squar = Instantiate(Square, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.2f, 0.8f);
            Squar.transform.localScale = new Vector3(rand, 1, rand);
            Squar.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            Squar.transform.rotation= new Quaternion(Squar.transform.rotation.x, Random.Range(0, 90), Squar.transform.rotation.z, Random.Range(0, 360));
            obj[1] = Squar;

            GameObject Lin1 = Instantiate(Line, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.8f, 2f);
            rand2 = Random.Range(0.01f, 0.2f);
            Lin1.transform.localScale = new Vector3(rand2, 1, rand);
            Lin1.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            Lin1.transform.rotation = new Quaternion(Lin1.transform.rotation.x, Random.Range(0, 90), Lin1.transform.rotation.z, Random.Range(0, 360));
            obj[2] = Lin1;

            GameObject Lin2 = Instantiate(Line, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.8f, 2f);
            rand2 = Random.Range(0.01f, 0.2f);
            Lin2.transform.localScale = new Vector3(rand2, 1, rand);
            Lin2.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            Lin2.transform.rotation = new Quaternion(Lin2.transform.rotation.x, Random.Range(0, 90), Lin2.transform.rotation.z, Random.Range(0, 360));
            obj[3] = Lin2;

            GameObject Trian = Instantiate(Triangle, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.5f, 1f);
            Trian.transform.localScale = new Vector3(rand, 1, rand);
            Trian.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            Trian.transform.rotation = new Quaternion(Trian.transform.rotation.x, Random.Range(0, 90), Trian.transform.rotation.z, Random.Range(0, 360));
            obj[4] = Trian; 
        }

        if (pressed == 2)
        {
            GameObject Circ = Instantiate(Circle, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(1f, 2f);
            Circ.transform.localScale = new Vector3(rand, 0.001f, rand);
            Circ.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            obj[0] = Circ;

            GameObject Squar = Instantiate(Square, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.8f, 1.4f);
            Squar.transform.localScale = new Vector3(rand, 1, rand);
            Squar.GetComponent<Renderer>().material.SetColor("_Color", colorsForMain.Evaluate(Random.value));
            Squar.transform.rotation = new Quaternion(Squar.transform.rotation.x, Random.Range(0, 90), Squar.transform.rotation.z, Random.Range(0, 360));
            obj[1] = Squar;

            GameObject Lin1 = Instantiate(Line, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.8f, 2f);
            rand2 = Random.Range(0.01f, 0.2f);
            Lin1.transform.localScale = new Vector3(rand2, 1, rand);
            Lin1.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            Lin1.transform.rotation = new Quaternion(Lin1.transform.rotation.x, Random.Range(0, 90), Lin1.transform.rotation.z, Random.Range(0, 360));
            obj[2] = Lin1;

            GameObject Lin2 = Instantiate(Line, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.8f, 2f);
            rand2 = Random.Range(0.01f, 0.2f);
            Lin2.transform.localScale = new Vector3(rand2, 1, rand);
            Lin2.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            Lin2.transform.rotation = new Quaternion(Lin2.transform.rotation.x, Random.Range(0, 90), Lin2.transform.rotation.z, Random.Range(0, 360));
            obj[3] = Lin2;

            GameObject Trian = Instantiate(Triangle, new Vector3(Random.Range(Mark1.transform.position.x, Mark2.transform.position.x), Random.Range(Mark1.transform.position.y, Mark2.transform.position.y), Random.Range(Mark1.transform.position.z, Mark2.transform.position.z)), Quaternion.identity);
            rand = Random.Range(0.5f, 1f);
            Trian.transform.localScale = new Vector3(rand, 1, rand);
            Trian.GetComponent<Renderer>().material.SetColor("_Color", colorsForSupport.Evaluate(Random.value));
            Trian.transform.rotation = new Quaternion(Trian.transform.rotation.x, Random.Range(0, 90), Trian.transform.rotation.z, Random.Range(0, 360));
            obj[4] = Trian;
        }
    }
}
