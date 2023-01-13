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
    public AudioClip seedsClip;
    AudioSource audioSource;
    SpriteRenderer seedslot;
    public Sprite Petunia, Althea, Tulip;
    public Tile None;
    Tilemap DropLayer;
    
    // Start is called before the first frame update
    void Start()
    {   grid = FindObjectOfType<Grid>();
        dirt = GameObject.FindGameObjectWithTag("Dirt").GetComponent<Tilemap>();
        inventory.Add("Petunia", 3);
        inventory.Add("Althea", 3);
        inventory.Add("Tulipe", 3);
        audioSource = GetComponent<AudioSource>();
        seedslot = GameObject.FindGameObjectWithTag("seedslot").GetComponent<SpriteRenderer>();
        seedslot.sprite = Petunia;
        Selected = "Petunia";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnPlant()
    {
        Vector3Int cellpos = posToGrid();
        TileBase tile = dirt.GetTile(cellpos);
        if (tile == null)
            return;
        if(tile.name != "farming-tileset_8")
            return;
        inventory.TryGetValue(Selected, out int number);
        if (number >= 3)
            Planting(cellpos);
        audioSource.PlayOneShot(seedsClip);
    }
    void OnSelectPlant(InputValue input) 
    {
        if(input.Get() == null)
            return;
        if ((float)input.Get() == 1)
        {
            Selected = "Petunia";
            seedslot.sprite = Petunia;
        }
        if ((float)input.Get() == 2)
        {
            Selected = "Althea";
            seedslot.sprite = Althea;
        }
        if ((float)input.Get() == 3)
        {
            Selected = "Tulipe";
            seedslot.sprite = Tulip;
        }
    }
    void Planting(Vector3Int cellpos)
    {
        dirt.SetTile(cellpos, grow);
        inventory[Selected] = inventory[Selected] - 3;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name) {
            case ("AthleaSeed(Clone)"):
                inventory["Althea"] += 1;
                break;
            case ("TulipeSeed(Clone)"):
                inventory["Tulipe"] += 1;
                break;
            case ("PetuniaSeed(Clone)"):
                inventory["Petunia"] += 1;
                break;
            default:
                return;
        }
        Destroy(collision.gameObject);
     }
    Vector3Int posToGrid()
    {
        Vector3 playerPos = new Vector3(transform.position.x, transform.position.y);
        return grid.WorldToCell(playerPos);
    }
}
