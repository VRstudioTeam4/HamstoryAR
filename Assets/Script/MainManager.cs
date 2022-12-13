using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

  float timer;
  int waitingTime;
  // Start is called before the first frame update
  void Start()
  {
    timer = 0.0f;
    waitingTime = 3;
  }

  // Update is called once per frame
  void Update()
  {
    timer += Time.deltaTime;

    if (timer > waitingTime)
    {
      toRoomSelect();
      timer = 0.0f;
    }
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
