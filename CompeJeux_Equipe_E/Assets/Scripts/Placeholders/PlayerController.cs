using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float walkSpeed = 4f, speedLimit = 0.7f, inputH, inputV;
    public Collider2D hitPelle, hitFaux, hitCiseau;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeTool("p");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeTool("f");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeTool("c");
        }
    }
    private void FixedUpdate()
    {
        if(inputH != 0 || inputV != 0)
        {
            if(inputH != 0 && inputV != 0)
            {
                inputH *= speedLimit; 
                inputV *= speedLimit;
            }
            rb.velocity = new Vector2(inputH * walkSpeed, inputV * walkSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void changeTool(string t)
    {
        if (t == "p")
        {
            hitPelle.enabled = true;
            hitFaux.enabled = false;
            hitCiseau.enabled = false;
            print(t);
        }
        if (t == "f")
        {
            hitPelle.enabled = false;
            hitFaux.enabled = true;
            hitCiseau.enabled = false;
            print(t);
        }
        if (t == "c")
        {
            hitPelle.enabled = false;
            hitFaux.enabled = false;
            hitCiseau.enabled = true;
            print(t);
        }
    }
}
