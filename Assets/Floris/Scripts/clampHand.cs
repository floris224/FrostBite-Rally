using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clampHand : MonoBehaviour
{

    public float maxrotation = 70;
    // Update is called once per frame
    void Update()
    {
        float currentXRotation = NormalizeAngle(transform.localEulerAngles.x);
        float currentYRotation = NormalizeAngle(transform.localEulerAngles.y);
        float currentZRotation = NormalizeAngle(transform.localEulerAngles.z);

        float clampedRotationX = Mathf.Clamp(currentXRotation,-maxrotation,maxrotation);
        float clampedRotationY = Mathf.Clamp(currentYRotation,-maxrotation,maxrotation);
        float ClampedRotationZ = Mathf.Clamp(currentZRotation,-maxrotation,maxrotation);
        transform.localEulerAngles = new Vector3(clampedRotationX, clampedRotationY, ClampedRotationZ);
    }
    float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        if (angle < 0)
            angle += 360;
        return angle > 180 ? angle - 360 : angle;
    }
}
