using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceableObject : MonoBehaviour 
{
    public List<Tile> disabledTiles;
    public Tilemap tilemap;

    public HashSet<TileBase> collidedTileNames;

    private void Awake() {
        collidedTileNames = new HashSet<TileBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TileBase tile = tilemap.GetTile(Vector3Int.FloorToInt(BuildingSystem.GetMouseWorldPosition()));
        Debug.Log("Collided with: " + tile.name);
        collidedTileNames.Add(tile);
    }
}
