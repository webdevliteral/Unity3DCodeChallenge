using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float yawSpeed = 100f;
    public float yawInput = 0f;
    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float currentZoom = 10f;

    public float pitch = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        //Make the camera follow target and control zoom
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        //Make the camera rotate around player when horizontal axis is called
        transform.RotateAround(target.position, Vector3.up, yawInput);
    }

    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        yawInput -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
}
