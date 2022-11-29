using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager trackedImgManager;

    public GameObject objectToInstantiate;

    private GameObject spawned;

    // Start is called before the first frame update
    void Awake()
    {
        trackedImgManager = FindObjectOfType<ARTrackedImageManager>();
    }

    // subscribe to trackedImagesChanged event
    private void OnEnable()
    {
        trackedImgManager.trackedImagesChanged += OnImageChanged;
    }

    //unsubscribe
    private void OnDisable()
    {
        trackedImgManager.trackedImagesChanged -= OnImageChanged;
    }

    // This will be called when trackedImagesChanged event happens.
    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // process added images
        foreach (ARTrackedImage img in args.added)
        {
            // omly interested in Ari image
            if (img.referenceImage.name == "Ari")
            {
                if (spawned == null)
                {
                    // instantiate the prefab
                    spawned = Instantiate(objectToInstantiate, img.transform.position, img.transform.rotation);
                }
            }
        }

        // Updated
        foreach(ARTrackedImage img in args.updated)
        {
            Debug.Log("Updated: " + img.referenceImage.name);
            // only interested in ajou image
            if(img.referenceImage.name == "Ari")
            {
                UpdateSpawned(img);
            }
        }

        // removed
        foreach(ARTrackedImage img in args.removed)
        {
            Debug.Log("Removed: "+ img.referenceImage.name);
            spawned.SetActive(false);
        }

        
    }

    private void UpdateSpawned(ARTrackedImage img)
    {
        // tracking is good!
        if(img.trackingState == TrackingState.Tracking){
            spawned.transform.position = img.transform.position;
            spawned.SetActive(true);
        }
        else if(img.trackingState == TrackingState.Limited)
        {
            Debug.Log("Limited tracking!");
            spawned.SetActive(false);
        }else if(img.trackingState == TrackingState.None)
        {
            Debug.Log("No tracking");
            spawned.SetActive(false);
        }
    }
}
    

