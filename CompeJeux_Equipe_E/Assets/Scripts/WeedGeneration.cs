using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeedGeneration : MonoBehaviour
{
    public Texture2D heatMap;
    public Texture2D spawnMap;
    public GameObject[] weedAssets = new GameObject[3];
    public float secondsTilNewWeed = 5;
    public float secondsTilAdjacent = 1;
    public float difficultyModifier = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        Color[] colors= new Color[spawnMap.width * spawnMap.height];
        for (int i =0; i < spawnMap.width * spawnMap.height; i++)
            colors[i] = Color.black;

        spawnMap.SetPixels(colors);
        InvokeRepeating("GenerateNewWeed", 1f, secondsTilNewWeed);
        InvokeRepeating("GenerateAdjacentWeed", 1f, secondsTilAdjacent);
        InvokeRepeating("UpdateDifficulty", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsTilNewWeed <= 20)
            CancelInvoke("UpdateDifficulty");
    }

    void GenerateNewWeed()
    {
        while (true)
        {
            Vector2Int pos = new Vector2Int(Random.Range(0, 59), Random.Range(0, 59));
            if (heatMap.GetPixel(pos.x, pos.y).r > Random.Range(0, 1))
            {
                int index = Random.Range(0, 3);
                GameObject weed = Instantiate(weedAssets[index], new Vector3(pos.x * 0.32f - 9.44f, pos.y * 0.32f - 9.44f, 0f), Quaternion.identity);
                weed.GetComponent<ClearSpawnMap>().spawnMapLocation = pos;
                if (index == 0)
                    spawnMap.SetPixel(pos.x, pos.y, Color.red);
                if (index == 1)
                    spawnMap.SetPixel(pos.x, pos.y, Color.green);
                if (index == 2)
                    spawnMap.SetPixel(pos.x, pos.y, Color.blue);
                break;
            }             
        }
    }

    void GenerateAdjacentWeed()
    {
        int cap = 0;
        while(true) 
        {
            cap++;
            if (cap >= 500)
                break;

            Vector2Int pos = new Vector2Int(Random.Range(1, 58), Random.Range(1, 58));
            Color[] colors = spawnMap.GetPixels(pos.x, pos.y, 3, 3);
            if (spawnMap.GetPixel(pos.x, pos.y) == Color.black && heatMap.GetPixel(pos.x, pos.y).r != 0)
            {
                foreach (Color color in colors)
                {
                    if (color == Color.red)
                    {
                        GameObject weed = Instantiate(weedAssets[0], new Vector3(pos.x * 0.32f - 9.44f, pos.y * 0.32f - 9.44f, 0f), Quaternion.identity);
                        weed.GetComponent<ClearSpawnMap>().spawnMapLocation = pos;
                        spawnMap.SetPixel(pos.x, pos.y, Color.red);
                        cap = 499;
                        break;
                    }
                    if (color == Color.green)
                    {
                        GameObject weed = Instantiate(weedAssets[1], new Vector3(pos.x * 0.32f - 9.44f, pos.y * 0.32f - 9.44f, 0f), Quaternion.identity);
                        weed.GetComponent<ClearSpawnMap>().spawnMapLocation = pos;
                        spawnMap.SetPixel(pos.x, pos.y, Color.green);
                        cap = 499;
                        break;
                    }
                    if (color == Color.blue)
                    {
                        GameObject weed = Instantiate(weedAssets[2], new Vector3(pos.x * 0.32f - 9.44f, pos.y * 0.32f - 9.44f, 0f), Quaternion.identity);
                        weed.GetComponent<ClearSpawnMap>().spawnMapLocation = pos;
                        spawnMap.SetPixel(pos.x, pos.y, Color.blue);
                        cap = 499;
                        break;
                    }
                }
            }
        }
    }

    void UpdateDifficulty()
    {
        secondsTilNewWeed += difficultyModifier;
        secondsTilAdjacent += difficultyModifier;
    }
}
