using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject player;
    public float cameraFollowSpeed;
    private float smoothTime = 0.05f;
    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //InstantFollow(1);
        FollowByDist();
        //SmoothFollow();
    }

/*    void FixedUpdate()
    {
        SmoothFollow();
    }*/

    private void InstantFollow(float offset)
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y + offset, gameObject.transform.position.z);

/*        if (player.transform.position.y > 0) // set int to 0 to ground out camera
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y + offset, gameObject.transform.position.z);
        } else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        }*/
    }

    private void FollowByDist()
    {
        float camDist = Mathf.Abs((player.transform.position.y) - gameObject.transform.position.y);

        if (camDist >= 3)
        {
            if (player.transform.position.y > gameObject.transform.position.y)
            {
                InstantFollow(-3);
            } else
            {
                InstantFollow(3);
            }
        }

       /* else if (camDist > 0.01)
        {
            if (player.transform.position.y > gameObject.transform.position.y)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + cameraFollowSpeed * camDist * Time.deltaTime, gameObject.transform.position.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - cameraFollowSpeed * camDist * Time.deltaTime, gameObject.transform.position.z);
            }
        } else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
        }*/
    }

    private void SmoothFollow()
    {
        Vector3 targetPOS = new Vector3(0, player.transform.position.y, -10);
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPOS, ref velocity, smoothTime);
    }
}
