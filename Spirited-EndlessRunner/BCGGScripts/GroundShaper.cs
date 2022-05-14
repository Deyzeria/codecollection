using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShaper : MonoBehaviour
{
    public Renderer floorGrass;
    public float scrollSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        floorGrass = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float offset = Time.time * scrollSpeed;
        floorGrass.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        //if (floorGrass.material.GetTextureOffset("_MainTex") > new Vector2(5, 0)) { floorGrass.material.SetTextureOffset("_MainTex", new Vector2(0, 0)); }
    }
}

