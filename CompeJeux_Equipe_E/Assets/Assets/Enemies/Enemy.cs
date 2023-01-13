using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    public Grid grid;
    public Tilemap droplayer;
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
        health = Random.Range(5, 16);
    }
}
