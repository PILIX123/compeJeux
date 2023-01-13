using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden_Sussy : MonoBehaviour
{
    bool hit = false;
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
        if (!hit)
        {
            hit = true;
            Trophy trophy = GetComponentInChildren<Trophy>();
            trophy.SetEnabled();
            transform.parent.GetComponent<Sussy_Achievement>().SussyCount++;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
