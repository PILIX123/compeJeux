using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public string Selected = "";
    Tilemap dirt;
    Grid grid;
    public Tile grow;
    
    // Start is called before the first frame update
    void Start()
    {   grid = FindObjectOfType<Grid>();
        dirt = GameObject.FindGameObjectWithTag("Dirt").GetComponent<Tilemap>();
        inventory.Add("Petunia", 3);
        inventory.Add("Jonquiere", 3);
        inventory.Add("Tulipe", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnPlant()
    {
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y);
        Vector3Int cellpos = grid.WorldToCell(playerPos);
        TileBase tile = dirt.GetTile(cellpos);
        if (tile == null)
            return;
        if(tile.name != "farming-tileset_8")
            return;
        inventory.TryGetValue(Selected, out int number);
        if (number >= 3)
            Planting(cellpos);        
    }
    void OnSelectPlant(InputValue input) 
    {
        if(input.Get() == null)
            return;
        if ((float)input.Get() == 1)
            Selected = "Petunia";
        if ((float)input.Get() == 2)
            Selected = "Jonquiere";
        if ((float)input.Get() == 3)
            Selected = "Tulipe";
    }
    void Planting(Vector3Int cellpos)
    {
        dirt.SetTile(cellpos, grow);
        inventory[Selected] = inventory[Selected] - 3;
    }
}
