using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // This assigns the collision to knockback the player if they interact with the collision on an enemy by checking the tag.
            playerController.knockbackCounter = playerController.knockbackTime;
            // Checks if the player is interacting from the right to properly knock back in the correct direction.
            if (collision.transform.position.x <= transform.position.x)
            {
                playerController.knockFromRight = true;
            }
            // Checks if the palyer is interacting from the left to properly knock back in the correct direction.
            if (collision.transform.position.x >= transform.position.x)
            {
                playerController.knockFromRight = false;
            }
            

        }
    }

}
