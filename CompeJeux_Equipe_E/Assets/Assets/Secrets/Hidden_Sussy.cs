using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden_Sussy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.GetComponent<Sussy_Achievement>().SussyCount++;
        Destroy(gameObject);
    }
    public void CollectSussy()
    {
        transform.parent.GetComponent<Sussy_Achievement>().SussyCount++;
        Destroy(gameObject);
    }
}
