using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMouseDetection : MonoBehaviour
{
    public GameObject platformTimeMap;
    private bool isMouseOver, isPlayerColliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseOver && !isPlayerColliding)
        {
            platformTimeMap.GetComponent<TilemapCollider2D>().enabled = true;
            platformTimeMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
        } else if (platformTimeMap.GetComponent<TilemapCollider2D>().enabled)
        {
            platformTimeMap.GetComponent<TilemapCollider2D>().enabled = false;
            platformTimeMap.GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.3f);
        }
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
