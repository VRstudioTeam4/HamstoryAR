using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonSceneChange() {
        string currentButton;
        currentButton = EventSystem.current.currentSelectedGameObject.name;
        if(currentButton.Equals("StoreButton")){
            SceneManager.LoadScene("stroe");
        }
        else if(currentButton.Equals("ItemButton")){
            SceneManager.LoadScene("Jwerly");
        }
        else if(currentButton.Equals("DiaryButton")){
            
        }
        else if(currentButton.Equals("ARStickerButton")){
            SceneManager.LoadScene("ARStickerTracking");
        }
        else if(currentButton.Equals("ARCameraButton")){
            SceneManager.LoadScene("ARCamera");
        }else if (currentButton.Equals("DiaryButton")){
            SceneManager.LoadScene("Story");
        }
    }
}
