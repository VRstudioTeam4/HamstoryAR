using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void toRoomSelect()
  {
    SceneManager.LoadScene("RoomSelect");
  }

  public void toTutorial()
  {
    SceneManager.LoadScene("Tutorial");
  }

  public void toMain()
  {
    SceneManager.LoadScene("Main");
  }
}
