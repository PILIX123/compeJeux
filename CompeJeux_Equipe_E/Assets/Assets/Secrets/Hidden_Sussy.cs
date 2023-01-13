using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden_Sussy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<Sussy_Achievement>().SussyCount++;
        Destroy(gameObject);
    }
}
