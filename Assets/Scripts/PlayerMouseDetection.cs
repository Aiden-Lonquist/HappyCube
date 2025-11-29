using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMouseDetection : MonoBehaviour
{
    public GameObject platformTimeMap, tilemap2, tilemap3, tilemap4;
    private bool isMouseOver, isPlayerColliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        // I don't know if I should use fixed update or normal update here...
        if (isMouseOver && !isPlayerColliding)
        {
            EnableTileMap(platformTimeMap);
            EnableTileMap(tilemap2);
            EnableTileMap(tilemap3);
            EnableTileMap(tilemap4);
        } else if (platformTimeMap.GetComponent<TilemapCollider2D>().enabled)
        {
            DisableTileMap(platformTimeMap);
            DisableTileMap(tilemap2);
            DisableTileMap(tilemap3);
            DisableTileMap(tilemap4);
        }
    }


    private void EnableTileMap(GameObject tm)
    {
        tm.GetComponent<TilemapCollider2D>().enabled = true;
        tm.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
    }

    private void DisableTileMap(GameObject tm)
    {
        tm.GetComponent<TilemapCollider2D>().enabled = false;
        tm.GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.3f);
    }

    public void SetIsPlayerColliding(bool playerColliding)
    {
        isPlayerColliding = playerColliding;
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
        //platformTimeMap.GetComponent<TilemapCollider2D>().enabled = true;
        //platformTimeMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
        //platformTimeMap.GetComponent<TilemapCollider2D>().enabled = false;
        //platformTimeMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.3f);
    }
}
