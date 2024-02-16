using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    private Transform objTransform;
    public Camera DebugCam;    // debugcam is the name of our camera right now

    // Start is called before the first frame update
    void Start()
    {
        DebugCam = GetComponentInParent<Camera>();  // get the camera from our parent class
        objTransform = DebugCam.transform;      // get the transform component
    }

    // Update is called once per frame
    void Update()
    {
        if (DebugCam != null) {     // Make sure theres a camera
            transform.position = objTransform.position;     // update gun with camera position
            transform.rotation = objTransform.rotation;     // update gun with camera rotation
        } else {
            Debug.Log("Parent camera not found");
        }

    
    }
}
