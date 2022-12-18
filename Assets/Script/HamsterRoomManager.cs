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
  float _danceTimer;
  int waitingTime;

  bool setting = false;

  public GameObject touchParticle;
  public GameObject seedObject;
  GameObject existSeed;
  bool seedExist = false;
  public Material[] myMaterials = new Material[6];


  float _eatTimer;
  enum hamsterState
  {
    Idle,
    Sad,
    Happy,
    Angry,
    Sleepy,
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

  public Animator m_Animator;

  AudioSource audioSource;
  public AudioClip clickAudio;
  public AudioClip strokeAudio;
  public AudioClip hungryAudio;
  public AudioClip eatAudio;

  void Start()
  {

    hamsterObject = hamsterObject.transform.GetChild(0).gameObject;
    _Sunflower = GameObject.Find("PointManager").GetComponent<Sunflower>();
    _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
    malpoongsun.SetActive(false);
    audioSource = transform.GetComponent<AudioSource>();

    timer = 0.0f;
    waitingTime = 3;

    // 각 상태에 따른 랜덤 가중치 부여
    m_hamsterStates.Add(hamsterState.Idle, 90);
    m_hamsterStates.Add(hamsterState.Sad, 5);
    m_hamsterStates.Add(hamsterState.Happy, 5);
    m_hamsterStates.Add(hamsterState.Angry, 5);
    m_hamsterStates.Add(hamsterState.Sleepy, 5);
    m_hamsterStates.Add(hamsterState.Love, 20);
    m_hamsterStates.Add(hamsterState.Hungry, 20);
    m_hamsterStates.Add(hamsterState.Bored, 20);

    setting = true;

    // likeText = GameObject.Find("Canvas");
  }
  void Update()
  {

    if (setting == false)
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
      m_hamsterStates.Add(hamsterState.Sleepy, 5);
      m_hamsterStates.Add(hamsterState.Love, 10);
      m_hamsterStates.Add(hamsterState.Hungry, 10);
      m_hamsterStates.Add(hamsterState.Bored, 10);

      setting = true;
    }


    // 3초에 한 번 랜덤으로 상태 값 업데이트

    timer += Time.deltaTime;

    if (timer > waitingTime && !(m_hamsterState == hamsterState.Love && hamsterStroke))
    {
      Debug.Log("안녕: " + m_hamsterStates.Count);
      setHamsterState();
      Debug.Log("랜덤 상태: " + m_hamsterState.ToString());
      timer = 0.0f;
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
            if (!hamsterStroke)
            {
              audioSource.clip = strokeAudio;
              audioSource.loop = true;
              audioSource.Play();
            }
            hamsterTouch = false;
            hamsterStroke = true;
            m_Animator.SetBool("Idle", false);
            m_Animator.SetBool("Love", false);
            m_Animator.SetBool("Hungry", false);
            m_Animator.SetBool("Bored", false);
            m_Animator.SetBool("Eat", false);
            m_Animator.SetBool("Sad", false);
            m_Animator.SetBool("Dance", false);
            m_Animator.SetBool("Stroke", true);
            Debug.Log("stroke true!!");
            if (hamsterObject.GetComponent<Renderer>().material != myMaterials[2])
            {
              hamsterObject.GetComponent<Renderer>().material = myMaterials[2];
            }
          }
        }

      }

      if (touch.phase == TouchPhase.Ended)  // 터치
      {
        // 터치 실행
        if (hamsterTouch == true)
        {
          Debug.Log("touoououdoch");
          if (m_hamsterState == hamsterState.Idle || m_hamsterState == hamsterState.Sad || m_hamsterState == hamsterState.Happy || m_hamsterState == hamsterState.Angry || m_hamsterState == hamsterState.Sleepy)
          {
            Debug.Log(touch.position);
            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log(pos);

            Vector3 pos1 = Camera.main.ScreenToViewportPoint(touch.position);
            Debug.Log("pos1 : " + pos1);

            Instantiate(touchParticle, new Vector3(pos1.x * 13 - 6.5f, pos1.y * 15 - 15.3f, 0), Quaternion.identity);


            Debug.Log("touch!!");
            StartCoroutine("ClickMaterial");
            audioSource.clip = clickAudio;
            audioSource.Play();
            _Like.like += 1;
            likeText.text = _Like.like.ToString();
            hamsterTouch = false;
            m_hamsterState = hamsterState.Idle;
          }
          else if (m_hamsterState == hamsterState.Hungry && !(m_Animator.GetBool("Eat") || m_Animator.GetBool("Sad")))
          {
            //배고픔 상태 처리
            if (_Sunflower.sunflowerseed > 0)
            {
              if (!m_Animator.GetBool("Eat"))
              {
                _Sunflower.sunflowerseed -= 1;
                SunflowerText.text = _Sunflower.sunflowerseed.ToString();
                audioSource.clip = eatAudio;
                audioSource.loop = false;
                audioSource.Play();
              }
              m_Animator.SetBool("Idle", false);
              m_Animator.SetBool("Love", false);
              m_Animator.SetBool("Hungry", false);
              m_Animator.SetBool("Bored", false);
              m_Animator.SetBool("Eat", true);
              m_Animator.SetBool("Sad", false);
              m_Animator.SetBool("Stroke", false);
              m_Animator.SetBool("Dance", false);
            }
            else
            {
              if (!m_Animator.GetBool("Sad"))
              {
                audioSource.clip = hungryAudio;
                audioSource.loop = false;
                audioSource.Play();
              }
              m_Animator.SetBool("Idle", false);
              m_Animator.SetBool("Love", false);
              m_Animator.SetBool("Hungry", false);
              m_Animator.SetBool("Bored", false);
              m_Animator.SetBool("Eat", false);
              m_Animator.SetBool("Sad", true);
              m_Animator.SetBool("Stroke", false);
              m_Animator.SetBool("Dance", false);
            }
            StartCoroutine(HamsterEat());
          }
          else if (m_hamsterState == hamsterState.Bored && !m_Animator.GetBool("Dance"))
          {
            //심심 상태 처리
            m_Animator.SetBool("Idle", false);
            m_Animator.SetBool("Love", false);
            m_Animator.SetBool("Hungry", false);
            m_Animator.SetBool("Bored", false);
            m_Animator.SetBool("Eat", false);
            m_Animator.SetBool("Sad", false);
            m_Animator.SetBool("Stroke", false);
            m_Animator.SetBool("Dance", true);
            StartCoroutine(HamsterDance());
          }

        }

        if (hamsterStroke == true) // 쓰다듬기
        {
          if (m_hamsterState == hamsterState.Love)
          {
            _Like.like += 30;
            likeText.text = _Like.like.ToString();
            hamsterStroke = false;
            hamsterObject.GetComponent<Renderer>().material = myMaterials[0];
            audioSource.loop = false;
            audioSource.Stop();
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
  IEnumerator HamsterDance()
  {
    _danceTimer = 2.50f;
    while (_danceTimer > 0)
    {
      _danceTimer -= Time.deltaTime;
      if (_danceTimer < 2.2f && hamsterObject.GetComponent<Renderer>().material != myMaterials[5])
      {
        hamsterObject.GetComponent<Renderer>().material = myMaterials[5];
      }
      yield return null;
      if (_danceTimer < 0)
      {
        _Like.like += 20;
        likeText.text = _Like.like.ToString();
        m_Animator.SetBool("Idle", true);
        m_Animator.SetBool("Love", false);
        m_Animator.SetBool("Hungry", false);
        m_Animator.SetBool("Bored", false);
        m_Animator.SetBool("Eat", false);
        m_Animator.SetBool("Sad", false);
        m_Animator.SetBool("Stroke", false);
        m_Animator.SetBool("Dance", false);
        hamsterTouch = false;
        m_hamsterState = hamsterState.Idle;
        hamsterObject.GetComponent<Renderer>().material = myMaterials[0];
      }
    }
  }


  IEnumerator HamsterEat()
  {
    _eatTimer = 2.09f;
    while (_eatTimer > 0)
    {
      _eatTimer -= Time.deltaTime;
      if (m_Animator.GetBool("Eat") && hamsterObject.GetComponent<Renderer>().material != myMaterials[3])
      {
        hamsterObject.GetComponent<Renderer>().material = myMaterials[3];
      }
      if (m_Animator.GetBool("Sad") && hamsterObject.GetComponent<Renderer>().material != myMaterials[4])
      {
        hamsterObject.GetComponent<Renderer>().material = myMaterials[4];
      }
      if (m_Animator.GetBool("Eat") && _eatTimer < 1.5f && existSeed == null)
      {
        Debug.Log("eat!!");
        existSeed = Instantiate(seedObject, seedObject.transform.position, seedObject.transform.rotation);
        Debug.Log(existSeed);
      }
      //   seedExist = true;
      //   // Instantiate(seedObject);
      // }
      if( _eatTimer < 0.3f) {
        Destroy(existSeed);
      }
      yield return null;
      if (_eatTimer < 0)
      {
        if (m_Animator.GetBool("Eat"))
        {
          _Like.like += 40;
          likeText.text = _Like.like.ToString();

        }
        m_Animator.SetBool("Idle", true);
        m_Animator.SetBool("Love", false);
        m_Animator.SetBool("Hungry", false);
        m_Animator.SetBool("Bored", false);
        m_Animator.SetBool("Eat", false);
        m_Animator.SetBool("Sad", false);
        m_Animator.SetBool("Stroke", false);
        m_Animator.SetBool("Dance", false);
        hamsterTouch = false;
        m_hamsterState = hamsterState.Idle;
        hamsterObject.GetComponent<Renderer>().material = myMaterials[0];
      }
    }
  }

  IEnumerator ClickMaterial()
  {
    if (hamsterObject.GetComponent<Renderer>().material != myMaterials[1])
    {
      hamsterObject.GetComponent<Renderer>().material = myMaterials[1];
      yield return new WaitForSeconds(0.5f);
      hamsterObject.GetComponent<Renderer>().material = myMaterials[0];
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

  private void setHamsterState()
  {
    Debug.Log(m_hamsterStates);
    Debug.Log(WeightedRandomizer.From(m_hamsterStates).TakeOne());
    m_hamsterBeforeState = m_hamsterState;
    Debug.Log(m_hamsterStates);
    m_hamsterState = WeightedRandomizer.From(m_hamsterStates).TakeOne();
    setHamsterAnimation();
  }

  private void setHamsterAnimation()
  {
    if (m_hamsterState == hamsterState.Idle || m_hamsterState == hamsterState.Sad || m_hamsterState == hamsterState.Happy || m_hamsterState == hamsterState.Angry || m_hamsterState == hamsterState.Sleepy)
    {
      m_Animator.SetBool("Idle", true);
      m_Animator.SetBool("Love", false);
      m_Animator.SetBool("Hungry", false);
      m_Animator.SetBool("Bored", false);
      m_Animator.SetBool("Eat", false);
      m_Animator.SetBool("Sad", false);
      m_Animator.SetBool("Stroke", false);
      m_Animator.SetBool("Dance", false);
    }
    else
    {
      m_Animator.SetBool("Idle", false);
      m_Animator.SetBool("Love", false);
      m_Animator.SetBool("Hungry", false);
      m_Animator.SetBool("Bored", false);
      m_Animator.SetBool("Eat", false);
      m_Animator.SetBool("Sad", false);
      m_Animator.SetBool("Stroke", false);
      m_Animator.SetBool("Dance", false);
      m_Animator.SetBool(m_hamsterState.ToString(), true);
    }
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
      Debug.Log(_weights);
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