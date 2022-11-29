using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewelry : MonoBehaviour
{
   
    public bool applesticker = false;
    public bool breadsticker = false;
    public bool cookiesticker = false;
    public bool donutsticker = false;
    public bool coffeesticker = false;
    public bool moneysticker = false;


    // Start is called before the first frame update
    void Start()
    {
        /*
        GameObject sticker1 = GameObject.Find("Canvas").transform.GetChild(1);
        var sticker2 = GameObject.Find("Canvas").transform.GetChild(2);
        */

    }

    private void Awake()
    {
        var obj = FindObjectsOfType<Jewelry>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
        
}
