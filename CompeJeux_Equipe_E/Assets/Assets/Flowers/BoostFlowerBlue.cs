using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostFlowerBlue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Grow", 5);
    }
    void Grow()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().moveSpeed += 0.1f;
    }
}
