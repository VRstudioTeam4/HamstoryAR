using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryButon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;

  
    // Get Like script
    LikeManager _Like;


    
    public void Tofirststory()
    {
        LikeManager _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
        Debug.Log(_Like.like);

        if (_Like.like >= 100)
        {
            Image1.SetActive(true);
        }

    }

    public void Tosecondstory()
    {
        LikeManager _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
        Debug.Log(_Like.like);

        if (_Like.like >= 200)
        {
            Image2.SetActive(true);
        }
    }

    public void Tothirdstory()
    {
        LikeManager _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
        Debug.Log(_Like.like);

        if (_Like.like >= 300)
        {
            Image3.SetActive(true);
        }
    }

}
