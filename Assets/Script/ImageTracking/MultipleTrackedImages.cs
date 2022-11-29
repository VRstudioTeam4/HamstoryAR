using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[System.Serializable]

public struct PlaceablePrefab
{
    public string name;
    public GameObject prefab;
}

public class MultipleTrackedImages : MonoBehaviour
{
    // Touch object
    public GameObject apple;
    public GameObject bread;
    public GameObject cookie;
    public GameObject donut;
    public GameObject coffee;
    public GameObject money;


    public GameObject Hiphop;
    public GameObject Idle;
  

    public GameObject objectToInstinate;
    [SerializeField]
    private PlaceablePrefab[] placeablePrefabs;

    private ARTrackedImageManager trackedImgManager;

    // used for keeping track of instantiated prefabs
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    
    bool act;

    public float xAngle, yAngle, zAngle;

    public AudioSource audio1;
    
    // Hit layer
    public LayerMask applehit;
    public LayerMask breadhit;
    public LayerMask cookiehit;
    public LayerMask donuthit;
    public LayerMask coffeehit;
    public LayerMask moneyhit;


    GameObject currenthit;

    // raycast hits
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public Transform target;

    void Update()
    {
        // Get Jewelry script
        Jewelry _Jewelry = GameObject.Find("Jewelry").GetComponent<Jewelry>();

        // Get Sunflower script
        Sunflower _Sunflower = GameObject.Find("PointManager").GetComponent<Sunflower>();


        //raycasting
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;


            //        Touch touch = Input.GetTouch(0);
                  Debug.Log(Input.GetTouch(0));

            // Halve the size of the cube.

            // when cat hit
            if (Input.touches[0].phase == TouchPhase.Began &&
                   Physics.Raycast(ray, out hit, Mathf.Infinity, applehit))
            {
                //   hit.collider.attachedRigidbody.AddForce(ray.direction * 100f);

                currenthit = hit.collider.gameObject;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(currenthit);
                Debug.Log("Apple is disappear");

                // get sticker number 1
                _Jewelry.applesticker = true;

                // get sunflower +10;
                _Sunflower.getsunflower();

                Debug.Log("Get apple Sticker & 10 sunflower");

                audio1.Play();
                Idle.SetActive(true);
                Invoke("activefunction", 3);

                
            }
            else if (Input.touches[0].phase == TouchPhase.Began &&
               Physics.Raycast(ray, out hit, Mathf.Infinity, breadhit))
            {
                currenthit = hit.collider.gameObject;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(currenthit);

                Debug.Log("bread is disappear");

                // get sticker 
                _Jewelry.breadsticker = true;
                // get sunflower +10;
                _Sunflower.getsunflower();
                Debug.Log("Get Bread Sticker & 10 sunflower");

                audio1.Play();
                
                Idle.SetActive(true);

                Invoke("activefunction", 3); 
            }
            else if (Input.touches[0].phase == TouchPhase.Began &&
              Physics.Raycast(ray, out hit, Mathf.Infinity, cookiehit))
            {
                currenthit = hit.collider.gameObject;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(currenthit);

                Debug.Log("bread is disappear");

                // get sticker 
                _Jewelry.cookiesticker = true;
                // get sunflower +10;
                _Sunflower.getsunflower();
                Debug.Log("Get Bread Sticker & 10 sunflower");

                audio1.Play();
                Hiphop.SetActive(true);

                Invoke("activefunction", 3);


            }
            else if (Input.touches[0].phase == TouchPhase.Began &&
             Physics.Raycast(ray, out hit, Mathf.Infinity, donuthit))
            {
                currenthit = hit.collider.gameObject;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(currenthit);

                Debug.Log("donut is disappear");

                // get sticker 
                _Jewelry.donutsticker = true;
                // get sunflower +10;
                _Sunflower.getsunflower();
                Debug.Log("Get Donut Sticker & 10 sunflower");

                audio1.Play();
                Hiphop.SetActive(true);

                Invoke("activefunction", 3);


            }
            else if (Input.touches[0].phase == TouchPhase.Began &&
             Physics.Raycast(ray, out hit, Mathf.Infinity, cookiehit))
            {
                currenthit = hit.collider.gameObject;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(currenthit);

                Debug.Log("cookie is disappear");

                // get sticker 
                _Jewelry.coffeesticker = true;
                // get sunflower +10;
                _Sunflower.getsunflower();
                Debug.Log("Get cookie Sticker & 10 sunflower");

                audio1.Play();
                Hiphop.SetActive(true);

                Invoke("activefunction", 3);


            }
            else if (Input.touches[0].phase == TouchPhase.Began &&
            Physics.Raycast(ray, out hit, Mathf.Infinity, coffeehit))
            {
                currenthit = hit.collider.gameObject;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(currenthit);

                Debug.Log("coffee is disappear");

                // get sticker 
                _Jewelry.moneysticker = true;
                // get sunflower +10;
                _Sunflower.getsunflower();
                Debug.Log("Get coffee Sticker & 10 sunflower");

                audio1.Play();
                Hiphop.SetActive(true);

                Invoke("activefunction", 3);


            }
            else if (Input.touches[0].phase == TouchPhase.Began &&
            Physics.Raycast(ray, out hit, Mathf.Infinity, moneyhit))
            {
                currenthit = hit.collider.gameObject;
                transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(currenthit);

                Debug.Log("money is disappear");

                // get sticker 
                _Jewelry.moneysticker = true;
                // get sunflower +10;
                _Sunflower.getsunflower();
                Debug.Log("Get money Sticker & 10 sunflower");

                audio1.Play();
                Hiphop.SetActive(true);

                Invoke("activefunction", 3);
            }

            transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.World);
        }
    }
            
           

            /* // Spin the object around the target at 20 degrees/second. // Rotation is done on the Y axis (up).
             transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
             // look at the target while rotating
             transform.LookAt(target.transform);
            */
        

    // instantiate all prefabs
    private void Awake()
    {
        
        trackedImgManager = FindObjectOfType<ARTrackedImageManager>();
        //      raycastManager = GetComponent<ARRaycastManager>();

        // instantiate prefabs
        foreach (PlaceablePrefab prefab in placeablePrefabs)
        {
            GameObject spawned = Instantiate(prefab.prefab, Vector3.zero, Quaternion.identity);
           
            spawned.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, spawned);
           
        }
    }

    
    private void OnEnable()
    {
        trackedImgManager.trackedImagesChanged += OnImageChanged;
    }

    //unsubscribe
    private void OnDisable()
    {
        trackedImgManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage img in args.added)
        {
            UpdateSpawned(img);
        }
        foreach (ARTrackedImage img in args.updated)
        {
            UpdateSpawned(img);
           
        }

        // when tracked img is removed, disable the gameobject.
        foreach (ARTrackedImage img in args.removed)
        {
            spawnedPrefabs[img.name].SetActive(false);
        }
    }

    private void UpdateSpawned(ARTrackedImage img)
    {
        string name = img.referenceImage.name;
        GameObject spawned = spawnedPrefabs[name];
        spawned.transform.position = img.transform.position;
        

        spawned.transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.World);
        
        //check the tracking status
        if (img.trackingState == TrackingState.Tracking)
        {
           
            // update position (or rotation), and enable gameobject
            spawned.transform.position = img.transform.position;
            //   spawned.transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.World);
         //   spawned.transform.LookAt(target);
            spawned.SetActive(true);

            if(name == "apple")
            {
                Idle.transform.position = img.transform.position;
            }
            else if(name == "bread")
            {
                Hiphop.transform.position = img.transform.position;
            }
            else if (name == "cookie")
            {
                Hiphop.transform.position = img.transform.position;
            }
            else if (name == "donut")
            {
                Hiphop.transform.position = img.transform.position;
            }
            else if (name == "coffee")
            {
                Hiphop.transform.position = img.transform.position;
            }
            else if (name == "money")
            {
                Hiphop.transform.position = img.transform.position;
            }

        }
        // poor or none tracking
        else
        {
            spawned.SetActive(false);
        }
    }

    void activefunction()
    {
        Hiphop.SetActive(false);
        Idle.SetActive(false);
    }


}
