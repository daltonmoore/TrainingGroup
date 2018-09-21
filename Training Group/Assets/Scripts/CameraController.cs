using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float turnSpeed = 5f;

    Quaternion cameraTargetRot;
    Quaternion charTargetRot;

    //Vector3 offset = new Vector3(0, .5f, -2);

	void Start ()
    {
        cameraTargetRot = Camera.main.transform.localRotation;
        charTargetRot = player.transform.localRotation;
	}

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -90, 90);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

	void Update ()
    {
        try
        {
            float yRot = Input.GetAxis("Mouse X") * turnSpeed;
            float xRot = Input.GetAxis("Mouse Y") * turnSpeed;

            transform.position = player.transform.position;

            charTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            cameraTargetRot = ClampRotationAroundXAxis(cameraTargetRot);

            player.transform.localRotation = charTargetRot;
            transform.localRotation = cameraTargetRot;
        }
        catch(Exception e)
        {
            UnityEditor.EditorUtility.DisplayDialog("Error in CameraController update", e.Message, "ok");
            Debug.Break();
        }
    }
}
