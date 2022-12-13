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
  }

  private IEnumerator Countdown()
  {
    _timer = 3.5f;
    toast.SetActive(false);
    GameObject.Find("Canvas").transform.Find("CameraButton").gameObject.SetActive(false);

    while (_timer > 0)
    {
      _timer -= Time.deltaTime;
      string minutes = Mathf.Floor(_timer / 60).ToString("00");
      string seconds = (_timer % 60).ToString("0");
    //   if(_timer <= 0)  _timerText.text = "";
      if (_timer>0.5) _timerText.text = string.Format(seconds);
      else _timerText.text = "";
      yield return null;

      if (_timer < 0)
      {
        StartCoroutine(Screenshot());
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
