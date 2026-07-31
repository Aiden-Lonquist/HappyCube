using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalPlayerCollisionScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Internal collision detected");
        player.transform.position += new Vector3(0, -0.5f, 0);
        //rb.AddForce(new Vector2(0, -100));
    }
}
