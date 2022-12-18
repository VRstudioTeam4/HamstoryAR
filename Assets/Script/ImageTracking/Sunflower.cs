using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public int sunflowerseed;
    // Start is called before the first frame update
    void Start()
    {
        // sunflowerseed = 0;
        sunflowerseed = 1;
        
    }

    private void Awake()
    {
        var obj = FindObjectsOfType<Sunflower>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getsunflower()
    {
        sunflowerseed += 10;
        Debug.Log("sunflowerseed : " + sunflowerseed);
    }

}
