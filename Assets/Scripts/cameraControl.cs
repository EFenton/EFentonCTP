using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
    Camera camera1;
    public Camera camera2;
    bool useFirstCam = true;
    // Use this for initialization
    void Start () {
        camera1 = GameObject.Find("FPSController").GetComponentInChildren<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
      
        if (Input.GetKeyDown("return"))
        {
            if (useFirstCam)
            {
                camera1.enabled = false;
                camera2.enabled = true;
                useFirstCam = false;
            }
            else
            {
                camera2.enabled = false;
                camera1.enabled = true;
                useFirstCam = true;
            }
        }
	}

}
