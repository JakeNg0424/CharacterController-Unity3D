using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera_1;
    public Camera camera_2;

    public void Clicked(){
        var transform = this.camera_1.GetComponent<Transform>();
        var position = transform.localPosition;
        position.z += 1.0f;
        transform.localPosition = position;
    }
}