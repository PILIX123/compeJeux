using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLifeSystem : MonoBehaviour
{
    public GameObject grid;
    public GameObject gameOverScreen;
    public int fatalEnemyCount = 100;
    public float life;
    private WeedGeneration generationSystem;

    // Start is called before the first frame update
    void Start()
    {
        generationSystem = grid.GetComponent<WeedGeneration>();
        InvokeRepeating("UpdateLife", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
            GameOver();
    }

    void UpdateLife()
    {
        float enemyCount = 0;
        Color[] colors = new Color[generationSystem.spawnMap.width * generationSystem.spawnMap.height];
        colors = generationSystem.spawnMap.GetPixels();
        foreach (Color color in colors)
        {
            enemyCount += color.r + color.g + color.b;
        }

        life = -(100 / fatalEnemyCount) * enemyCount + 100;

        transform.localScale = new Vector3(0.0082f*life + 0.6f, 0.0082f * life + 0.6f, 0.0082f * life + 0.6f);
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
