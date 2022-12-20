using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    public Material[] mat = new Material[2];


    public void Start()
    {
        Invoke("excited", 0.2f);
    }

    void excited()
    {
        Debug.Log("ex");
        // Change Material
        gameObject.GetComponent<Renderer>().material = mat[1];
        Invoke("normal", 3f);
    }

    void normal()
    {
        Debug.Log("normal");
        // Change Material
        gameObject.GetComponent<Renderer>().material = mat[0];
    }

}
