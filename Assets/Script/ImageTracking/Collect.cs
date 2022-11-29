using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    GameObject _renderder;

    Image applerenerder;
    public Sprite newapple;


    Image breadrenerder;
    public Sprite newbread;

    Image cookierenerder;
    public Sprite newcookie;

    Image donutrenerder;
    public Sprite newdonut;

    Image coffeerenerder;
    public Sprite newcoffee;

    Image moneyrenerder;
    public Sprite newmoney;

    GameObject _jewelry;
    // Start is called before the first frame update

    void Start()
    {
        
        _renderder = GameObject.Find("Sticker");

        // Change Image
        applerenerder = _renderder.transform.GetChild(0).GetComponent<Image>();
        breadrenerder = _renderder.transform.GetChild(1).GetComponent<Image>();
        cookierenerder = _renderder.transform.GetChild(2).GetComponent<Image>();
        donutrenerder = _renderder.transform.GetChild(3).GetComponent<Image>();
        coffeerenerder = _renderder.transform.GetChild(4).GetComponent<Image>();
        moneyrenerder = _renderder.transform.GetChild(5).GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        Jewelry _Jewelry = GameObject.Find("Jewelry").GetComponent<Jewelry>();

        if (_Jewelry.applesticker == true)
        {
            Debug.Log("apple sitkcer active");
            applerenerder.sprite = newapple;
        }
        if (_Jewelry.breadsticker == true)
        {
            Debug.Log("bread sitkcer active");
            breadrenerder.sprite = newbread;
        }
        if (_Jewelry.cookiesticker == true)
        {
            Debug.Log("cookie sitkcer active");
            cookierenerder.sprite = newcookie;
        }
        if (_Jewelry.donutsticker == true)
        {
            Debug.Log("donut sitkcer active");
            donutrenerder.sprite = newdonut;
        }
        if (_Jewelry.coffeesticker == true)
        {
            Debug.Log("coffee sitkcer active");
            coffeerenerder.sprite = newcoffee;
        }
        if (_Jewelry.moneysticker == true)
        {
            Debug.Log("money sitkcer active");
            moneyrenerder.sprite = newmoney;
        }
    }
}
