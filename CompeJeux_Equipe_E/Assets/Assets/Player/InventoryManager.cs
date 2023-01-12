using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string,int> inventory = new Dictionary<string,int>();
    string Selected = "";
    // Start is called before the first frame update
    void Start()
    {
        inventory.Add("Petunia", 0);
        inventory.Add("Jonquiere", 0);
        inventory.Add("Tulipe", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnPlant()
    {
        inventory.TryGetValue(Selected, out int number);
        if (number < 3)
            print("cant plant");
    }
    void OnSelectPlant(InputValue input) 
    {
        if(input == null)
            return;
        if ((int)input.Get() == 1)
            Selected = "Petunia";
        if ((int)input.Get() == 2)
            Selected = "Jonquiere";
        if ((int)input.Get() == 3)
            Selected = "Tulipe";
    }
}
