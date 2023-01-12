using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearSpawnMap : MonoBehaviour
{
    public Vector2Int spawnMapLocation;
    public GameObject grid;

    private void Start()
    {
        grid = GameObject.Find("Grid");
        Debug.Log(grid.name);
    }
    private void OnDestroy()
    {
        if(grid != null)
            grid.GetComponent<WeedGeneration>().spawnMap.SetPixel(spawnMapLocation.x, spawnMapLocation.y, Color.black);
    }
}
