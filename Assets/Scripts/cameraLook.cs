using UnityEngine;
using System.Collections;

public class cameraLook : MonoBehaviour
{
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        gameObject.transform.Rotate(0, horizontal, 0);

        float desiredAngle = gameObject.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = gameObject.transform.position - (rotation * offset);
    }
}