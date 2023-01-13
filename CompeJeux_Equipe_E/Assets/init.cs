using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    prefs p = new prefs();
    // Start is called before the first frame update
    void Start()
    {
        p.skip = false;
        p.colour = false;
    }
}
