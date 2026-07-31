using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// this script is for the trigger colliders of the platforms not the actual rendered platforms!
// this script is not responsible for anything other than discrete collision detection and "player-in-block" prevention.
public class GamePlatformsScript : MonoBehaviour
{
    public GameObject player;
    private bool isPlayerColliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "CoreCollider")
        {
            isPlayerColliding = true;
            Debug.Log("Core Collider Hit");
            player.GetComponent<PlayerMouseDetection>().SetIsPlayerColliding(isPlayerColliding);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.name == "CoreCollider")
        {
            isPlayerColliding = false;
            Debug.Log("Core Collider Out");
            player.GetComponent<PlayerMouseDetection>().SetIsPlayerColliding(isPlayerColliding);
        }
    }

    public bool GetPlayerColliding()
    {
        return isPlayerColliding;
    }

}
