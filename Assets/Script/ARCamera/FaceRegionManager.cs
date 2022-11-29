using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Collections;

public class FaceRegionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] regionPrefabs;
    public GameObject objectPrefab;
    private ARFaceManager faceManager;
    private ARSessionOrigin sessionOrigin;
    //store face region information from ARCore
    private NativeArray<ARCoreFaceRegionData> faceRegions;

    void Awake() {
        faceManager = FindObjectOfType<ARFaceManager>();
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();

        // instantiate each region of the face
        for (int i = 0; i<regionPrefabs.Length; i++) {
            regionPrefabs[i] = Instantiate(regionPrefabs[i], sessionOrigin.trackablesParent);
        }
        objectPrefab = Instantiate(objectPrefab, sessionOrigin.trackablesParent);
    }

    private void Update() {

        // if(faceManager.trackables == null) {
        //     Debug.Log("--------------------!!!!!!!!!!!!!!!!");
        // }
        // Debug.Log(ARFaceManager.OnTrackablesChanged)
        
        ARCoreFaceSubsystem subsystems = (ARCoreFaceSubsystem)faceManager.subsystem;

        // process each detected face
        foreach (ARFace face in faceManager.trackables) {
            //get all available face regions that ARCore detect
            subsystems.GetRegionPoses(face.trackableId, Allocator.Persistent, ref faceRegions);

            //process all detect regions
            foreach (ARCoreFaceRegionData data in faceRegions)
            {
                // region type (ARCore):
                // Notip = 0
                // ForeheadLeft = 1
                // ForeheadRight = 2
                ARCoreFaceRegion regionType = data.region;

                //apply position and rotation to the prefabs based on the face region data.
                regionPrefabs[(int)regionType].transform.localPosition = data.pose.position;
                regionPrefabs[(int)regionType].transform.localRotation = data.pose.rotation;
            }

            // positioning object on the head (based on position of foreheadleft&foreheadright and rotation of notip)
            objectPrefab.transform.localPosition = (regionPrefabs[1].transform.localPosition + regionPrefabs[2].transform.localPosition)/2 + new Vector3(0,0.04f,0);
            objectPrefab.transform.localRotation = regionPrefabs[0].transform.localRotation;

        }
    }
}
