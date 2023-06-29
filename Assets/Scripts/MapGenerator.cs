using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{

    public int mapWidth;
    public int mapHeight;
    public float noiseScale;
    public int octaves;

    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;
    public Tilemap tilemap;
    public TerrainType[] regions;
    float[,] falloffMap;

    void Awake() {
        falloffMap = FallOffGenerator.GenerateFalloffMap(mapHeight, mapWidth);
    }
    public void GenerateMap()
    {
        float[,] noiseMap = NoiseGenerator.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        

        for(int y = 0; y < mapWidth; y++)
        {
            for(int x = 0; x < mapHeight; x++)
            {
                noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y] - falloffMap[x, y]);
                float currentHeight = noiseMap[x, y];
                for(int i = 0; i < regions.Length; i++)
                {
                    if(currentHeight <= regions[i].height)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), regions[i].tile);
                        break;
                    }
                }

            }
        }   


    }

    private void OnValidate()
    {
        if (mapWidth < 1)
            mapWidth = 1;
        if (mapHeight < 1)
            mapHeight = 1;
        if (octaves < 0)
            octaves = 0;
        if (lacunarity < 1)
            lacunarity = 1;

        falloffMap = FallOffGenerator.GenerateFalloffMap(mapHeight, mapWidth);
    }

    [System.Serializable]
    public struct TerrainType
    {
        public string name;
        public float height;
        public Tile tile; // Change to Tile Prefab later
    }
}
