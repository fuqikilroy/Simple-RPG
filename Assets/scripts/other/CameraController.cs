using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 5;

    private Vector3 offset;
    private Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offset;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Camera.main.fieldOfView += scroll*zoomSpeed;

        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70);
    }
}
