using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class screenshot_test : MonoBehaviour
{
  private byte[] imageByte;
  string albumName = "HamStoryAR";
  private float _timer;
  private float _toastTimer;
  public Text _timerText;

  public GameObject toast;
  private Text toastTxt;
  private Image toastImg;
  private float fadeInOutTime = 0.3f;
  AudioSource cameraSound;

  public Animator m_Animator;

  public GameObject ARSessionOrigin;

  // Start is called before the first frame update
  void Start()
  {
    toast.SetActive(false);
    cameraSound = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void testScreenShot()
  {
    StartCoroutine(Countdown());
    m_Animator = ARSessionOrigin.GetComponent<FaceRegionManager>().objectPrefab.GetComponent<Animator>();
    Debug.Log(m_Animator);
    m_Animator.SetBool("Idle", false);
    m_Animator.SetBool("Pose", true);
  }

  private IEnumerator Countdown()
  {
    _timer = 4.5f;
    toast.SetActive(false);
    GameObject.Find("Canvas").transform.Find("CameraButton").gameObject.SetActive(false);

    while (_timer > 0)
    {
      _timer -= Time.deltaTime;
      if (_timer < 4.0f)
      {
        string minutes = Mathf.Floor(_timer / 60).ToString("00");
        string seconds = (_timer % 60).ToString("0");
        //   if(_timer <= 0)  _timerText.text = "";
        if (_timer > 0.5 && _timer < 3.5f) _timerText.text = string.Format(seconds);
        else _timerText.text = "";
        yield return null;

        if (_timer < 0)
        {
          StartCoroutine(Screenshot());
        }
      }
    }
  }

  IEnumerator Screenshot()
  {

    yield return null;
    cameraSound.Play();
    GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

    yield return new WaitForEndOfFrame();

    Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
    tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
    tex.Apply();
    // imageByte = tex.EncodeToPNG();
    // DestroyImmediate(tex);
    NativeGallery.SaveImageToGallery(tex, albumName,
        "Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + "{0}.png");
    Destroy(tex);

    GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
    GameObject.Find("Canvas").transform.Find("CameraButton").gameObject.SetActive(true);
    m_Animator.SetBool("Idle", true);
    m_Animator.SetBool("Pose", false);
    StartCoroutine(ShowToastMessage());
  }

  private IEnumerator ShowToastMessage()
  {
    _toastTimer = 3;
    toast.SetActive(true);

    while (_toastTimer > 0)
    {
      _toastTimer -= Time.deltaTime;
      yield return null;

      if (_toastTimer < 0)
      {
        toast.SetActive(false);
      }
    }
  }
}
