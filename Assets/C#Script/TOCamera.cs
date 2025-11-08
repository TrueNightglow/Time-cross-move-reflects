using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOCamera : MonoBehaviour
{
    public new Camera camera;

    private void LateUpdate()
    {
        Vector3 direction = transform.position - camera.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
    }
}
