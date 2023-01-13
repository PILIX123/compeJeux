using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostFlowerPurple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Grow", 60);
    }
    void Grow()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().moveSpeed += 0.1f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().damage += 0.1f;
    }
}
