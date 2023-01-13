using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{
    public GameObject PetuniaSeed;
    public GameObject TulipSeed;
    public GameObject AltheaSeed;

    LevelManager levelManager;
    public float Health
    {
        set
        {
            health = value;
            if(health <= 0)
                Defeated();
        }
        get { return health; }
    }
    public float health;
    public void Defeated()
    {
        levelManager.weedsKilled++;
        Vector3 pos = transform.position;
        float random = Random.Range(0, 100);
        if (random < 40)
            Instantiate(AltheaSeed, pos, new Quaternion());
        if (40 < random && random < 85)
            Instantiate(TulipSeed, pos, new Quaternion());
        if (85 < random)
            Instantiate(PetuniaSeed, pos,new Quaternion());
        Destroy(gameObject);
    }
    public void Start()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        health = Random.Range(5, 16);
    }
}
