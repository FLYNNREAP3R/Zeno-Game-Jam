using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed;
    private Rigidbody2D body;
    private int acornCount = 0;


    public TMP_Text counterText;


    public float knockbackForce;
    public float knockbackCounter;
    public float knockbackTime;

    public bool knockFromRight;
    uiScoreAudio ui_score;


   private void Awake()
   {
        body = GetComponent<Rigidbody2D>();

        // Get UI script for score audio triggers
        GameObject ui_obj = GameObject.Find("UI");
        ui_score = ui_obj.GetComponent<uiScoreAudio>();
    }

    // Start is called before the first frame update
   private void Update()
   {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Checks if the player is being knocked back and the direction they are being knocked back from so player is knocked back in right direction
        if (knockbackCounter <= 0)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
        else
        {
            // If player is hit from the right, the player will go left
            if (knockFromRight == true)
            {
                body.velocity = new Vector2(-knockbackForce, knockbackForce);
            }
            // If player is hit from the left, the player will go right
            if (knockFromRight == false)
            {
                body.velocity = new Vector2(knockbackForce, knockbackForce);
            }
        }

        // Checks if "d" is pressed to move right and flips the character facing right
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        // Checks if "a" is pressed to move left and flips the character facing left
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Checks to see if spacebar is pressed to initiate jump
        if(Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
        
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the player is interacting with the acorn via tag
        if (collision.CompareTag("acorn") && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            acornCount += 1;
            ui_score.scoreUpAudio();
            counterText.text = "Acorns: " + acornCount;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the player is running into the pinecone and if the player's collider is set to true
        if (collision.gameObject.tag == "pinecone" && collision.gameObject.activeSelf == true)
        {
            // Destroys pinecone actor when player collides with object. Knocks back the player and subtracts 2 from the acorn counter
            collision.gameObject.SetActive(false); 
            acornCount = acornCount - 2;
            ui_score.scoreDownAudio();
            counterText.text = "Acorns: " + acornCount;
        }
    }
}
