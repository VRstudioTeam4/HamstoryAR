using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterRoomManager : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject hamsterObject;
  private bool hamsterTouch = false;
  private bool hamsterStroke = false;
 // public int like = 0;
  public Text likeText;
  public Text SunflowerText;


    // Get Sunflower script
    Sunflower _Sunflower;

    // Get Like script
    LikeManager _Like;
    

   
    void Start()
  {
        
        hamsterObject = hamsterObject.transform.GetChild(0).gameObject;
        _Sunflower = GameObject.Find("PointManager").GetComponent<Sunflower>();
        _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
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
}