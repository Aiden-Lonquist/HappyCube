using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject spriteShell;
    public float speed, jumpForce;
    public bool isGrounded;
    public bool useForceMovement;
    // Start is called before the first frame update
    void Start()
    {
        if (useForceMovement)
        {
            speed *= 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool tempGrounded = isGrounded;
        isGrounded = GroundedCheck();
        if (tempGrounded == false && isGrounded == true)
        {
            Debug.Log("Just landed");
            spriteShell.GetComponent<SquashAndStretchEffect>().LandingAnimation(rb.velocity.y);
        }

        //HorizontalMovement();
        HorizontalMovementNoGroundedCheck();
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            // using jump force of 825 with gravity scale 3 for most testing (can use 750 and 2.5 for easier game)
            rb.AddForce(new Vector2(0, jumpForce));
            spriteShell.GetComponent<SquashAndStretchEffect>().LandingAnimation(isJumping: true);
        }

        //Debug.Log("This is get axis:" + Input.GetAxis("Horizontal"));
        //Debug.Log("This is get axis raw" + Input.GetAxisRaw("Horizontal"));

        // maximum fall velocity
        if (rb.velocity.y < -25)
        {
            rb.velocity = new Vector2(rb.velocity.x, -25);
        }
    }

    //depricated. Using friction instead of grounded check so that ice tiles work
    private void HorizontalMovement()
    {
        if (!isGrounded)
        {
            if (!useForceMovement)
            {
                // constant movement
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            }
            else
            {
                // force dependant movement
                float horizontal = Input.GetAxisRaw("Horizontal");
                rb.AddForce(new Vector2(horizontal * speed * Time.deltaTime, 0));
            }
        }
    }

    private void HorizontalMovementNoGroundedCheck()
    {
        if (!useForceMovement)
        {
            // constant movement
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        }
        else
        {
            // force dependant movement
            float horizontal = Input.GetAxisRaw("Horizontal");
            rb.AddForce(new Vector2(horizontal * speed * Time.deltaTime, 0));
        } 
    }

    private bool GroundedCheck()
    {
        //Debug.DrawRay(transform.position, -transform.up, Color.green, 1f);
        //Two raycasts on the bottom left and right corners of the player so that it can still jump even if just the edge is on a platform.
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
