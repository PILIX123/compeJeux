using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFlowerColor : MonoBehaviour
{
    public Sprite Blue, Green, Purple;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.instance.colour == 0)
            GetComponent<SpriteRenderer>().sprite = Blue;
        if (gameManager.instance.colour == 1)
            GetComponent<SpriteRenderer>().sprite = Green;
        if (gameManager.instance.colour == 2)
            GetComponent<SpriteRenderer>().sprite = Purple;
    }
}
