using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Likemention : MonoBehaviour
{
    LikeManager _Like;

    // Like point 
    public TextMeshProUGUI likeText1;
    public TextMeshProUGUI likeText2;
    public TextMeshProUGUI likeText3;

    // Like mention
    public TextMeshProUGUI likemention1;
    public TextMeshProUGUI likemention2;
    public TextMeshProUGUI likemention3;

    // Lock Image
    public GameObject LockImage1;
    public GameObject LockImage2;
    public GameObject LockImage3;


    // Start is called before the first frame update
    void Start()
    {
        _Like = GameObject.Find("PointManager").GetComponent<LikeManager>();
        Debug.Log(_Like.like);
    }

    // Update is called once per frame
    void Update()
    {
        likeText1.text = _Like.like.ToString();
        likeText2.text = _Like.like.ToString();
        likeText3.text = _Like.like.ToString();

        if(_Like.like >= 100)
        {
            likemention1.text = "첫번째 이야기 보러가기";
            LockImage1.SetActive(false);
        }

        if (_Like.like >= 200)
        {
            likemention2.text = "두번째 이야기 보러가기 ";
            LockImage2.SetActive(false);
        }

        if (_Like.like >= 300)
        {
            likemention3.text = "세번째 이야기 보러가기 !";
            LockImage2.SetActive(false);
        }


    }

}
