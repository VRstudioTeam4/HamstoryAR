using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikeManager : MonoBehaviour
{
    public int like;

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

    private void Start()
    {
        like = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
