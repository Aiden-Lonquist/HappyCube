using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject player;
    public float cameraFollowSpeed;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantFollow();
    }

    private void InstantFollow()
    {
            if (player.transform.position.y > 0)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
            } else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
            }
    }

    private void FollowByDist()
    {
        float camDist = Mathf.Abs(player.transform.position.y - gameObject.transform.position.y);

        if (camDist > 0.01)
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
        }
    }

    private void SmoothFollow()
    {
        Vector3 targetPOS = new Vector3(0, player.transform.position.y, -10);
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPOS, ref velocity, cameraFollowSpeed);
    }
}
