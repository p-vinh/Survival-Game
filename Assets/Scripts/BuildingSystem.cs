using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;
    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField]
    private Tilemap MainTileMap;
    [SerializeField]
    private TileBase whiteTile;
    public GameObject prefab1;
    private PlaceableObject objectToPlace;
    private GameObject currentObject;

    public List<Tile> disabledTiles;
    public HashSet<TileBase> collidedTileNames;

    public bool canPlace = true;

    #region Unity methods

    private void Awake() {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
    }

    private void Update() {
       
        if(Input.GetKeyDown("1") && currentObject == null) {
            InitializeWithObject(prefab1);
        }

        if (objectToPlace != null) {
            Vector2 snappedPos = SnapCoordinateToGrid(GetMouseWorldPosition());
            objectToPlace.transform.position = snappedPos;

            if (Input.GetMouseButtonDown(0)) {
                FinalizePlacement();
            }
        }


    }
    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public Vector2 SnapCoordinateToGrid(Vector2 pos) {
        Vector3Int cellPos = gridLayout.WorldToCell(pos);
        pos = grid.GetCellCenterWorld(cellPos);
        return pos;
    }

    #endregion 

    #region Building Placement

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector2 snappedPosition = SnapCoordinateToGrid(mousePosition);
        Vector3 position = new Vector3(snappedPosition.x, snappedPosition.y, 0f);

        currentObject = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = currentObject.GetComponent<PlaceableObject>();
        currentObject.AddComponent<ObjectDrag>();
    }

    public void FinalizePlacement()
    {
        collidedTileNames = currentObject.GetComponent<PlaceableObject>().collidedTileNames;
        disabledTiles = currentObject.GetComponent<PlaceableObject>().disabledTiles;
        
        foreach (TileBase tileName in collidedTileNames) {
            foreach (TileBase disabledTileName in disabledTiles) {
                if (tileName.name == disabledTileName.name) {
                    canPlace = false;
                }
            }
        }
        
        ObjectDrag objectDrag = currentObject.GetComponent<ObjectDrag>();

        if (objectDrag != null && canPlace)
        {
            Destroy(objectDrag);
            objectToPlace = null;
            currentObject = null;
        }
    }
    #endregion
}
