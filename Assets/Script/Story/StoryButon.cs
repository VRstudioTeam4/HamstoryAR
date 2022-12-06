using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryButon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Image1;
    public GameObject Image1_1;
    public GameObject Image1_2;
    public GameObject Image1_3;
    public GameObject Image1_4;
    public GameObject Image1_5;
    public GameObject Image1_6;


    public GameObject Image2;
    public GameObject Image3;

    public GameObject ButtonManager;
    // Get Like script
    LikeManager _Like;


    public void Tofirststory()
    {
        LikeManager _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
        Debug.Log(_Like.like);

        if (_Like.like >= 100)
        {
            ButtonManager.SetActive(false);
            Image1.SetActive(true);
            Image1_1.SetActive(true);
            Invoke("StoryImage2", 5);
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

    void StoryImage2()
    {
        Image1_1.SetActive(false);
        Image1_2.SetActive(true);
        Invoke("StoryImage3", 5);
    }

    void StoryImage3()
    {
        Image1_2.SetActive(false);
        Image1_3.SetActive(true);
        Invoke("StoryImage4", 5);
    }

    void StoryImage4()
    {
        Image1_3.SetActive(false);
        Image1_4.SetActive(true);
        Invoke("StoryImage5", 5);
    }

    void StoryImage5()
    {
        Image1_4.SetActive(false);
        Image1_5.SetActive(true);
        Invoke("StoryImage6", 5);
    }

    void StoryImage6()
    {
        Image1_5.SetActive(false);
        Image1_6.SetActive(true);
        Invoke("Storyfinish", 5);
    }

    void Storyfinish()
    {
        Image1_6.SetActive(false);
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
        ButtonManager.SetActive(true);

    }



}
