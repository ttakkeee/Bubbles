using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Shop : MonoBehaviour
{
    public Tiles[] tiles;
    
    // armes
    public TileBase sarbacane;
    public TileBase arbalete;
    public TileBase magnum;
    public TileBase mitraillette;
    
    // armee
    public TileBase garde_arme;
    public TileBase garde_anti_emeute;
    public TileBase tourelle;
    public TileBase canon;
    public TileBase frappe_aerienne;
    public Tilemap tilemap;

    public NotorieteManager myNotoManager;
    
    private void IsEnoughMoney()
    {
        if (myNotoManager.money >= 10)
        {
            Debug.Log("We have enough money!");
        }
        else
        {
            Debug.Log("We don't have enough money!");
        }
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Tiles tile in tiles)
            {
                tilemap.GetTile(tile.tilePos);
                if (tile != null)
                {
                    Debug.Log("Tile " + tile.tilePos + " is not null");
                }
                else
                {
                    Debug.Log("Tile " + tile.tilePos + " is null");
                }
            }
        }
    }
}
