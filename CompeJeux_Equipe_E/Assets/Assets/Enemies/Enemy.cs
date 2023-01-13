using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    public Grid grid;
    public Tilemap droplayer;
    public Tile Seed1;
    public Tile Seed2;
    public Tile Seed3;
    public float Health
    {
        set
        {
            health = value;
            if(health <= 0)
            {
                Defeated();
            }
        }
        get { return health; }
    }
    public float health;
    public void Defeated()
    {
        Destroy(gameObject);
    }
    public void Start()
    {
        grid = FindObjectOfType<Grid>();
        droplayer = GameObject.FindGameObjectWithTag("DropLayer").GetComponent<Tilemap>();
        Vector3 pos = transform.position;
        Vector3Int cellPos = grid.WorldToCell(pos);
        float random = Random.Range(0, 100);
        if (random < 40)
            droplayer.SetTile(cellPos, Seed1);
        if(40<random && random<85)
            droplayer.SetTile(cellPos, Seed2);
        if(85< random)
            droplayer.SetTile(cellPos, Seed3);
        health = Random.Range(5, 16);
    }
}
