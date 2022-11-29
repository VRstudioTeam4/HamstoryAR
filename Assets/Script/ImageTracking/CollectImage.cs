using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectImage : MonoBehaviour
{ 
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
