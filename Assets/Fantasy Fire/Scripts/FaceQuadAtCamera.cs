using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceQuadAtCamera : MonoBehaviour
{
    [Tooltip("Turn this bool on to face the gameobject towards the camera")]
    public bool faceCamera;
    [Tooltip("Drag your Camera into this field if you want to override using Camera.main")]
    public Camera overrideMainCamera;

    Quaternion newRotation;

    Transform camTransform;

    void Start()
    {
        if (overrideMainCamera)
            camTransform = overrideMainCamera.transform;
        else
            camTransform = Camera.main.transform;
    }

    void Update()
    {
        if (faceCamera)
        {
            if(camTransform == null)
            {
                Debug.LogError("[FantasyFire]: Could Not find Camera.main, and no Camera was supplied in the Override Main Camera variable. Please supply a camera, or tag your main camera with the \"MainCamera\" tag.");
                return;
            }
            Vector3 targetPos = new Vector3(camTransform.position.x, transform.position.y, camTransform.position.z);

            newRotation = Quaternion.LookRotation(transform.position - targetPos, Vector3.up);

            newRotation.eulerAngles = new Vector3(newRotation.eulerAngles.x, RotationMath(newRotation.eulerAngles.y), newRotation.eulerAngles.z);

            transform.localRotation = newRotation;

        }
    }

    float RotationMath(float y)
    {
        if (transform.parent.transform.localEulerAngles.z > 170f && transform.parent.transform.localEulerAngles.z < 190f)
            return -y;

        return y;
    }
}
