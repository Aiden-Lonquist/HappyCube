using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speed;
    public bool pointingLeft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            if (pointingLeft)
            {
                collision.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            } else
            {
                collision.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Player")
        {
            collision.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
    }*/

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.name == "CoreCollider")
        {
            isPlayerColliding = false;
            Debug.Log("Core Collider Out");
            player.GetComponent<PlayerMouseDetection>().SetIsPlayerColliding(isPlayerColliding);
        }
    }*/
}
