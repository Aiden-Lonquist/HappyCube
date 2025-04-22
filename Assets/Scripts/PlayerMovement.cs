using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed, jumpForce;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GroundedCheck();

        if (!isGrounded)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.AddForce(new Vector2(0, jumpForce));
        }

        //Debug.Log("This is get axis:" + Input.GetAxis("Horizontal"));
        //Debug.Log("This is get axis raw" + Input.GetAxisRaw("Horizontal"));

        // maximum fall velocity
        if (rb.velocity.y < -50)
        {
            rb.velocity = new Vector2(rb.velocity.x, -50);
        }
    }

    private bool GroundedCheck()
    {
        //Debug.DrawRay(transform.position, -transform.up, Color.green, 1f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right/2, -transform.up, 1, layerMask: LayerMask.GetMask("Platforms"));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - transform.right / 2, -transform.up, 1, layerMask: LayerMask.GetMask("Platforms"));
        //Debug.Log("hit distance: " + hit.distance);
        // ensures raycast is less than 0.1f 
        if ((hit.distance < 0.52f && hit.distance > 0) || (hit2.distance < 0.52f && hit2.distance > 0))
        {
            return true;
        }
        return false;
    }
}
