using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Tilemap theMap;
    public float zoomSize = 5;
    public bool shouldZoomIn = true;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    private float halfHeight;
    private float halfWidth;

    public static CameraController instance;

    void Start()
    {
        target = FindObjectOfType<Player>().transform;

        //refers to the camera in the scene or the camera that this script is attached to
        halfHeight = Camera.main.orthographicSize;
        //aspect refers to the Aspect ratio
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        FindObjectOfType<PlayerMovement>().SetBounds(theMap.localBounds.min, theMap.localBounds.max);

        instance = this;
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //keep the camera inside the bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void ZoomIn()
    {
        GetComponent<Camera>().orthographicSize = zoomSize + 1f;
    }

    public void ZoomOut()
    {
        GetComponent<Camera>().orthographicSize = zoomSize;
    }
}
