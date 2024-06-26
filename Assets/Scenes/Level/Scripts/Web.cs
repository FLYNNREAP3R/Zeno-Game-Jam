using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerController playerController;
    Rigidbody2D rb;

    public WebAudio webAudio;
    Vector3 webPos;
    void Start()
    {
        webPos = gameObject.transform.position;
        webPos.z = -10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //webAudio.WebCollectAudio(playerController.transform.position);
            webAudio.PlayClipAt(webAudio.pickClip(), gameObject.transform.position);
            // This assigns the collision to knockback the player if they interact with the collision on an enemy by checking the tag.
            playerController.speed = playerController.speed / 5;
            playerController.jumpForce = playerController.jumpForce / 2;
            Invoke("ResetPlayerSpeedAndJumpForce", 6f);
        }
        gameObject.SetActive(false);
    }

    private void ResetPlayerSpeedAndJumpForce()
    {
        playerController.speed = 10;
        playerController.jumpForce = 10;
    }
}
