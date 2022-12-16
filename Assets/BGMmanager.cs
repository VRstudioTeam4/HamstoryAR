using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMmanager : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;
    Scene thisScene;

    void Awake()
    {
        thisScene = SceneManager.GetActiveScene();
        // BackgroundMusic = GameObject.Find("BackgroundMusic");
        Debug.Log("call!");
        backmusic = transform.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (backmusic.isPlaying) return; //배경음악이 재생되고 있다면 패스
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(gameObject); //배경음악 계속 재생하게(이후 버튼매니저에서 조작)
        }
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if(scene.name.Equals("ARStickerTracking") || scene.name.Equals("ARCamera")){
            if(backmusic.isPlaying) backmusic.Stop();
        }
        else {
            if(!backmusic.isPlaying) backmusic.Play();
        }
    }

    // called third
    void Start()
    {
        Debug.Log("Start");
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

//     vo

    // void Update() {

    //     if(backmusic.isPlaying && thisScene != SceneManager.GetActiveScene()){
    //         thisScene = SceneManager.GetActiveScene();

    //     }
    // }
// }
}