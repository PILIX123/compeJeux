using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSpawnMap : MonoBehaviour
{
    public Vector2Int spawnMapLocation;
    public Texture2D spawnMap;

    private void OnDestroy()
    {
        spawnMap.SetPixel(spawnMapLocation.x, spawnMapLocation.y, Color.black);
    }
}
