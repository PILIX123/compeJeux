using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string,int> inventory = new Dictionary<string,int>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnPlant()
    {

    }
    void OnSelectPlant(InputValue input)
    {
        object Tets = input.Get();
    }
}
