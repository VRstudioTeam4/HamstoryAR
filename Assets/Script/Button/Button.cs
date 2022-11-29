using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    
    // To ImageTracking scene change button
    public void ToImageTracking()
    {
        SceneManager.LoadScene("ARStickerTracking");
    }

    // To ARCamera scene change button
    public void ToARCamera()
    {
        SceneManager.LoadScene("ARCamera");
    }

    // To Store scene change button
    public void ToStore()
    {
        SceneManager.LoadScene("store");
    }

    //To Main
    public void Tomain()
    {
        SceneManager.LoadScene("HamsterRoom");
    }

    //To Jwerly
    public void ToJewelry()
    {
        SceneManager.LoadScene("Jwerly");
    }

    //To Jwerly
    public void Tostory()
    {
        SceneManager.LoadScene("Story");
    }


}
