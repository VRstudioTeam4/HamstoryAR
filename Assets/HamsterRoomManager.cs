using System.Collections;
using System.Collections.Generic;
using System;
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

  float timer;
  int waitingTime;

  enum hamsterState
  {
    Idle,
    Sad,
    Happy,
    Angry,
    Fun,
    Love,
    Hungry,
    Bored
  }

  private Dictionary<hamsterState, int> m_hamsterStates = new Dictionary<hamsterState, int>();
  [SerializeField] private hamsterState m_hamsterState = hamsterState.Idle;
  [SerializeField] private hamsterState m_hamsterBeforeState = hamsterState.Idle;



  // Get Sunflower script
  Sunflower _Sunflower;

  // Get Like script
  LikeManager _Like;



  void Start()
  {

    hamsterObject = hamsterObject.transform.GetChild(0).gameObject;
    _Sunflower = GameObject.Find("PointManager").GetComponent<Sunflower>();
    _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
    malpoongsun.SetActive(false);

    timer = 0.0f;
    waitingTime = 3;

    // 각 상태에 따른 랜덤 가중치 부여
    m_hamsterStates.Add(hamsterState.Idle, 90);
    m_hamsterStates.Add(hamsterState.Sad, 5);
    m_hamsterStates.Add(hamsterState.Happy, 5);
    m_hamsterStates.Add(hamsterState.Angry, 5);
    m_hamsterStates.Add(hamsterState.Fun, 5);
    m_hamsterStates.Add(hamsterState.Love, 5);
    m_hamsterStates.Add(hamsterState.Hungry, 5);
    m_hamsterStates.Add(hamsterState.Bored, 5);

    // likeText = GameObject.Find("Canvas");
  }
  void Update()
  {


    // 3초에 한 번 랜덤으로 상태 값 업데이트

    timer += Time.deltaTime;

    if (timer > waitingTime && !(m_hamsterState == hamsterState.Love && hamsterStroke))
    {
      setHamsterState();
      Debug.Log("랜덤 상태: " + m_hamsterState.ToString());
      timer = 0;
    }


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

      if (touch.phase == TouchPhase.Moved && m_hamsterState == hamsterState.Love)  //쓰다듬기
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
          }
          //   Debug.Log("Move: ", hit.transform.gameObject);
          //         Debug.Log(hit.transform.gameObject);

          //         if(hit.transform.gameObject == hamsterObject) {

          //         }
          //     }
        }

      }

      if (touch.phase == TouchPhase.Ended)  // 터치
      {
        // 터치 실행
        if (hamsterTouch == true)
        {
          if (m_hamsterState == hamsterState.Idle || m_hamsterState == hamsterState.Sad || m_hamsterState == hamsterState.Happy || m_hamsterState == hamsterState.Angry || m_hamsterState == hamsterState.Fun)
          {
            Debug.Log("touch!!");
            _Like.like += 1;
            likeText.text = _Like.like.ToString();
            hamsterTouch = false;
            m_hamsterState = hamsterState.Idle;
          }
          else if (m_hamsterState == hamsterState.Hungry)
          {
            //배고픔 상태 처리
            if (_Sunflower.sunflowerseed > 0)
            {
              _Sunflower.sunflowerseed -= 1;
              _Like.like += 40;
            }
            hamsterTouch = false;
            m_hamsterState = hamsterState.Idle;
          }
          else if (m_hamsterState == hamsterState.Bored)
          {
            //심심 상태 처리
            _Like.like += 20;
            hamsterTouch = false;
            m_hamsterState = hamsterState.Idle;
          }

        }

        if (hamsterStroke == true) // 쓰다듬기
        {
          if (m_hamsterState == hamsterState.Love)
          {
            _Like.like += 30;
            likeText.text = _Like.like.ToString();
            hamsterStroke = false;
          }
        }


      }

    }

    // 말풍선
    if (m_hamsterState != hamsterState.Idle)
    {
      enableMalPoonSun();
      foreach (Transform child in malpoongsun.transform)
        {
          child.gameObject.SetActive(false);
        }
      malpoongsun.transform.Find(m_hamsterState.ToString()).gameObject.SetActive(true);
    }
    else
    {
      disableMalPoonSun();
    }


  }

  public void enableMalPoonSun()
  {
    Debug.Log("enable!!");
    malpoongsun.SetActive(true);

  }
  public void disableMalPoonSun()
  {
    foreach (Transform child in malpoongsun.transform)
    {
      child.gameObject.SetActive(false);
    }
    malpoongsun.SetActive(false);
  }

  // public void showMalPoongSun()
  // {
  //   enableMalPoonSun();
  //   if (status == "hungry")
  //   { //hungry
  //     malpoongsun_hungry.SetActive(true);
  //     malpoongsun_hungry.transform.Find("Request").gameObject.SetActive(true);
  //   }
  //   else
  //   {  //simsim
  //     malpoongsun_simsim.SetActive(true);
  //     malpoongsun_simsim.transform.Find("Request").gameObject.SetActive(true);
  //   }
  // }

  // public void interactHamster()
  // {
  //   isInteract = true;
  //   if (status == "hungry")
  //   {
  //     foreach (Transform child in malpoongsun_hungry.transform)
  //     {
  //       child.gameObject.SetActive(false);
  //     }
  //     if (_Sunflower.sunflowerseed > 0)
  //     {
  //       malpoongsun_hungry.transform.Find("Accept").gameObject.SetActive(true);
  //       _Sunflower.sunflowerseed -= 1;
  //       _Like.like += 40;
  //     }
  //     else
  //     {
  //       malpoongsun_hungry.transform.Find("Fail").gameObject.SetActive(true);
  //     }
  //     isInteract = false;
  //     Invoke("disableMalPoonSun", 5);
  //   }
  //   else if (status == "simsim")
  //   {
  //     _Like.like += 20;
  //     isInteract = false;
  //     disableMalPoonSun();
  //   }
  // }

  private void setHamsterState()
  {
    // Debug.Log(WeightedRandomizer.From(m_hamsterStates).TakeOne());
    m_hamsterBeforeState = m_hamsterState;
    m_hamsterState = WeightedRandomizer.From(m_hamsterStates).TakeOne();
  }

  public static T RandomEnum<T>()

  {
    Array values = Enum.GetValues(typeof(T));

    return (T)values.GetValue(new System.Random().Next(0, values.Length));
  }

  public static class WeightedRandomizer
  {
    public static WeightedRandomizer<R> From<R>(Dictionary<R, int> spawnRate)
    {
      return new WeightedRandomizer<R>(spawnRate);
    }
  }

  public class WeightedRandomizer<T>
  {
    private static System.Random _random = new System.Random();
    private Dictionary<T, int> _weights;

    public WeightedRandomizer(Dictionary<T, int> weights)
    {
      _weights = weights;
    }

    public T TakeOne()
    {
      var sortedSpawnRate = Sort(_weights);
      int sum = 0;
      foreach (var spawn in _weights)
      {
        sum += spawn.Value;
      }

      int roll = _random.Next(0, sum);

      T selected = sortedSpawnRate[sortedSpawnRate.Count - 1].Key;
      foreach (var spawn in sortedSpawnRate)
      {
        if (roll < spawn.Value)
        {
          selected = spawn.Key;
          break;
        }
        roll -= spawn.Value;
      }

      return selected;
    }

    private List<KeyValuePair<T, int>> Sort(Dictionary<T, int> weights)
    {
      var list = new List<KeyValuePair<T, int>>(weights);

      list.Sort(
          delegate (KeyValuePair<T, int> firstPair,
                      KeyValuePair<T, int> nextPair)
          {
            return firstPair.Value.CompareTo(nextPair.Value);
          }
          );

      return list;
    }
  }
}