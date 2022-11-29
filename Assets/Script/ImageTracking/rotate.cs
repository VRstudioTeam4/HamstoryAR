using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public GameObject target;
  

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position,
                                     Vector3.up, 20 * Time.deltaTime);

    }
}
