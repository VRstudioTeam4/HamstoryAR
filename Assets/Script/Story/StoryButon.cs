using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryButon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;

    public void Tofirststory()
    {
        // Get Sunflower script
        Sunflower _Sunflower = GameObject.Find("Sunflower").GetComponent<Sunflower>();

        if (_Sunflower.sunflowerseed >= 10)
        {
            Image1.SetActive(true);
        }

    }

    public void Tosecondstory()
    {
        // Get Sunflower script
        Sunflower _Sunflower = GameObject.Find("Sunflower").GetComponent<Sunflower>();

        if (_Sunflower.sunflowerseed >= 20)
        {
            Image2.SetActive(true);
        }
    }

    public void Tothirdstory()
    {
        // Get Sunflower script
        Sunflower _Sunflower = GameObject.Find("Sunflower").GetComponent<Sunflower>();

        if (_Sunflower.sunflowerseed >= 30)
        {
            Image3.SetActive(true);
        }
    }


}
