using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceableObject : MonoBehaviour 
{
    public List<Tile> disabledTiles;
    public Tilemap tilemap;

    public List<TileBase> collidedTileNames;

    private void Awake() {
        collidedTileNames = new List<TileBase>();
        tilemap = GameObject.Find("World").GetComponent<Tilemap>();
        
    }

    private void OnMouseDown() {
        collidedTileNames.Clear();
        float sizeX = this.GetComponent<Renderer>().bounds.size.x;
        float sizeY = this.GetComponent<Renderer>().bounds.size.y;
        Vector3 mousePosition = BuildingSystem.GetMouseWorldPosition();
        Vector3Int cellPos = tilemap.WorldToCell(mousePosition);

        Debug.Log("CellPos: " + cellPos);

        for (int x = 0; sizeX > x; x++) {
            for (int y = 0; sizeY > y; y++) {
                
                Vector3Int cellPos2 = new Vector3Int(cellPos.x + x, cellPos.y + y, cellPos.z);
                TileBase tile = tilemap.GetTile(cellPos2);
                if (tile != null) {
                    collidedTileNames.Add(tile);
                }
            }
        }
    }


    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     TileBase tile = tilemap.GetTile(Vector3Int.FloorToInt(BuildingSystem.GetMouseWorldPosition()));
    //     Debug.Log("Collided with: " + tile.name);
    //     collidedTileNames.Add(tile);
    // }

    // private void OnTriggerExit2D(Collider2D collision) {
    //     TileBase tile = tilemap.GetTile(Vector3Int.FloorToInt(BuildingSystem.GetMouseWorldPosition()));
    //     Debug.Log("Exited collision with: " + tile.name);
    //     collidedTileNames.Remove(tile);
    // }
}
