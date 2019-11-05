using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera cam;
    
    private float camSize = 5f;
    [Range(1f,5f)]
    [SerializeField] float zoomSpeed = 3f;
    [SerializeField] float minZoom = 2f;
    [SerializeField] float maxZoom = 5f;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {     
        camSize += -(Input.GetAxis("Mouse ScrollWheel")) * zoomSpeed; //Zoom in zoom out
        camSize = Mathf.Clamp(camSize, minZoom, maxZoom);
        cam.orthographicSize = camSize;
    }
}
