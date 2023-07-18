using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float zoomSpeed = 10000f;
    [SerializeField] private float minZoomDistance = 5f;
    [SerializeField] private float maxZoomDistance = 100f;
    [SerializeField] private float edgeDeadzone = 5f;
    [SerializeField] private float deadzonePercentage = 0.1f;

    private Camera cam;
    private float screenWidth;
    private float screenHeight;
    private float deadzoneWidth;
    private float deadzoneHeight;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        UpdateDeadzone();
    }

    private void Update()
    {
        // Camera movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // Calculate camera's new position
        Vector3 newPosition = transform.position + movement;
        float halfWidth = screenWidth / 2f;
        float halfHeight = screenHeight / 2f;
        float minPosX = -halfWidth + deadzoneWidth + cam.orthographicSize;
        float maxPosX = halfWidth - deadzoneWidth - cam.orthographicSize;
        float minPosY = -halfHeight + deadzoneHeight + cam.orthographicSize;
        float maxPosY = halfHeight - deadzoneHeight - cam.orthographicSize;
        newPosition.x = Mathf.Clamp(newPosition.x, minPosX, maxPosX);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosY, maxPosY);

        // Update camera's position
        transform.position = newPosition;

        // Camera zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float zoomAmount = scroll * zoomSpeed * Time.deltaTime;
        float newZoomDistance = cam.orthographicSize - zoomAmount;
        cam.orthographicSize = Mathf.Clamp(newZoomDistance, minZoomDistance, maxZoomDistance);


        UpdateDeadzone();
    }

    private void UpdateDeadzone()
    {
        deadzoneWidth = screenWidth * deadzonePercentage / 2f;
        deadzoneHeight = screenHeight * deadzonePercentage / 2f;
    }
}

