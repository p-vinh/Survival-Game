using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialMousePosition;
    private Vector3 offset;

    private void OnMouseDown()
    {        
        initialPosition = transform.position;
        initialMousePosition = BuildingSystem.GetMouseWorldPosition();
        offset = initialPosition - initialMousePosition;
    }


    private void OnMouseDrag()
    {
        Vector3 mousePosition = BuildingSystem.GetMouseWorldPosition();
        Vector3 newPosition = mousePosition + offset;
        transform.position = BuildingSystem.current.SnapCoordinateToGrid(newPosition);
    }


}
