using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedGeneration : MonoBehaviour
{
    public Texture2D heatMap;
    public GameObject weedAsset;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateNewWeed", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateNewWeed()
    {
        while (true)
        {
            Vector2Int pos = new Vector2Int(Random.Range(0, 56), Random.Range(0, 56));
            if (heatMap.GetPixel(pos.x, pos.y).r > Random.Range(0, 100))
            {
                Instantiate(weedAsset, new Vector3(pos.x * 0.32f - 9.6f, pos.y * 0.32f - 9.6f, 0f), Quaternion.identity);
            }
            if (heatMap.GetPixel(pos.x, pos.y).r == 0)
                break;
        }
    }

    void GenerateAdjacentWeed()
    {

    }
}
