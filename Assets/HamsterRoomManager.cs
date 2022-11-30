using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HamsterRoomManager : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject hamsterObject;
  private bool hamsterTouch = false;
  private bool hamsterStroke = false;
  private bool isHungry = false;

  private bool shutdownMalpoonsung = false;
  private bool isInteract = false;
  private string status;
  // public int like = 0;
  public Text likeText;
  public Text SunflowerText;

  public GameObject malpoongsun;
  public GameObject malpoongsun_hungry;
  public GameObject malpoongsun_simsim;


  // Get Sunflower script
  Sunflower _Sunflower;

  // Get Like script
  LikeManager _Like;



  void Start()
  {

    hamsterObject = hamsterObject.transform.GetChild(0).gameObject;
    _Sunflower = GameObject.Find("PointManager").GetComponent<Sunflower>();
    _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
    malpoongsun_hungry = malpoongsun.transform.Find("Hungry").gameObject;
    malpoongsun_simsim = malpoongsun.transform.Find("Simsim").gameObject;
    malpoongsun.SetActive(false);
    // likeText = GameObject.Find("Canvas");
  }
  void Update()
  {
    // if(Input.GetMouseButtonDown(0)) {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;

    //     if(Physics.Raycast(ray, out hit)){
    //         Debug.Log(hit.transform.gameObject);

    //         if(hit.transform.gameObject == hamsterObject) {

    //         }
    //     }

    //     Debug.Log(Input.touches);

    // Get Sunflower script

    SunflowerText.text = _Sunflower.sunflowerseed.ToString();
    likeText.text = _Like.like.ToString();

    foreach (var touch in Input.touches)
    {
      if (touch.phase == TouchPhase.Began)
      {
        // Construct a ray from the current touch coordinates
        var ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

          if (hit.transform.gameObject == hamsterObject)
          {
            hamsterTouch = true;
          }
        }

      }

      if (touch.phase == TouchPhase.Moved)
      {
        // Construct a ray from the current touch coordinates
        var ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
          if (hit.transform.gameObject == hamsterObject)
          {
            hamsterTouch = false;
            hamsterStroke = true;
            Debug.Log("hamster is cute!");
          }
          //   Debug.Log("Move: ", hit.transform.gameObject);
          //         Debug.Log(hit.transform.gameObject);

          //         if(hit.transform.gameObject == hamsterObject) {

          //         }
          //     }
        }

      }

      if (touch.phase == TouchPhase.Ended)
      {
        // 터치 실행
        if (hamsterTouch == true)
        {
          Debug.Log("touch!!");
          _Like.like += 1;
          likeText.text = _Like.like.ToString();
          hamsterTouch = false;
        }

        if (hamsterStroke == true)
        {
          _Like.like += 30;
          likeText.text = _Like.like.ToString();
          hamsterStroke = false;
        }


      }

    }

    int interactTiming = Random.Range(0, 1000);
    Debug.Log(interactTiming);
    Debug.Log(malpoongsun.activeSelf);

    if (interactTiming < 10 && malpoongsun.activeSelf == false)
    {
      Debug.Log("hello!");
      if (Random.Range(0, 10) > 5)
      { //hungry
        Debug.Log("hungry");
        status = "hungry";
      }
      else
      {  //simsim
        status = "simsim";
      }
      showMalPoongSun();
      Invoke("disableMalPoonSun", 5);
    }

    if (malpoongsun.activeSelf == true && shutdownMalpoonsung == true)
    {
      foreach (Transform child in malpoongsun_hungry.transform)
      {
        child.gameObject.SetActive(false);
      }
      foreach (Transform child in malpoongsun_simsim.transform)
      {
        child.gameObject.SetActive(false);
      }
      foreach (Transform child in malpoongsun.transform)
      {
        child.gameObject.SetActive(false);
      }
      malpoongsun.SetActive(false);
      shutdownMalpoonsung = false;
    }
    // Debug.Log("터치카운트 : " + Input.touchCount);

    // if (Input.touchCount == 1)
    // {
    //   Touch touch = Input.GetTouch(0);
    //   if (touch.phase == TouchPhase.Began)
    //   {
    //     prePos = touch.position - touch.deltaPosition;
    //   }
    //   else if (touch.phase == TouchPhase.Moved)
    //   {
    //     nowPos = touch.position - touch.deltaPosition;
    //     movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
    //     player.transform.Translate(movePos);
    //     prePos = touch.position - touch.deltaPosition;
    //   }
    // }
  }

  public void enableMalPoonSun()
  {
    Debug.Log("enable!!");
    malpoongsun.SetActive(true);
  }
  public void disableMalPoonSun()
  {
    if (isInteract == false)
    {
      shutdownMalpoonsung = true;
    }

    // malpoongsun.SetActive(false);
  }

  public void showMalPoongSun()
  {
    enableMalPoonSun();
    if (status == "hungry")
    { //hungry
      malpoongsun_hungry.SetActive(true);
      malpoongsun_hungry.transform.Find("Request").gameObject.SetActive(true);
    }
    else
    {  //simsim
      malpoongsun_simsim.SetActive(true);
      malpoongsun_simsim.transform.Find("Request").gameObject.SetActive(true);
    }
  }

  public void interactHamster()
  {
    isInteract = true;
    if (status == "hungry")
    {
      foreach (Transform child in malpoongsun_hungry.transform)
      {
        child.gameObject.SetActive(false);
      }
      if (_Sunflower.sunflowerseed > 0)
      {
        malpoongsun_hungry.transform.Find("Accept").gameObject.SetActive(true);
        _Sunflower.sunflowerseed -= 1;
        _Like.like += 40;
      }
      else
      {
        malpoongsun_hungry.transform.Find("Fail").gameObject.SetActive(true);
      }
      isInteract = false;
      Invoke("disableMalPoonSun", 5);
    }
    else if (status == "simsim")
    {
      _Like.like += 20;
      isInteract = false;
      disableMalPoonSun();
    }
  }
}