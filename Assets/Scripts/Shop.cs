using System;
using System.Collections;
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

public class TextClickHandler : MonoBehaviour
{
    private System.Action onClick;

    public void Initialize(System.Action action)
    {
        onClick = action;
    }

    private void OnMouseDown()
    {
        onClick?.Invoke();
    }
}

public class Upgrade
{
    public string name;
    public int cost;
    public System.Action ApplyEffect;

    public Upgrade(string name, int cost, System.Action applyEffect)
    {
        this.name = name;
        this.cost = cost;
        this.ApplyEffect = applyEffect;
    }
}

public class NotorieteManagerShop : MonoBehaviour
{
    private int money = 1000;
    private int notoriety = 0;
    
    public bool CanAfford(int amount)
    {
        return money >= amount;
    }

    public void SpendMoney(int amount)
    {
        if (CanAfford(amount))
        {
            money -= amount;
        }
    }

    public void AddNotoriety(int amount)
    {
        notoriety += amount;
    }

    public IEnumerator AddPermanentNotoriety(int notorietyGain, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            notoriety += notorietyGain;
        }
    }

    public IEnumerator ActivateRiotGuards(float duration, float cooldown)
    {
        Debug.Log("Gardes anti-émeutes activés!");
        yield return new WaitForSeconds(duration);
        Debug.Log("Gardes anti-émeutes désactivés!");
        yield return new WaitForSeconds(cooldown);
    }

    public IEnumerator ActivateAirstrike(int notorietyGain, float cooldown)
    {
        notoriety += notorietyGain;
        Debug.Log("Frappe Aérienne utilisée!");
        yield return new WaitForSeconds(cooldown);
    }
}
