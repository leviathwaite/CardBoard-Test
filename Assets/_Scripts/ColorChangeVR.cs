using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeVR : MonoBehaviour
{

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Red()
    {
        Debug.Log("Red");
        _renderer.material.color = Color.red;
    }

    public void Blue()
    {
        Debug.Log("Blue");
        _renderer.material.color = Color.blue;
    }

    public void Black()
    {
        Debug.Log("Black");
        _renderer.material.color = Color.black;
    }
}
