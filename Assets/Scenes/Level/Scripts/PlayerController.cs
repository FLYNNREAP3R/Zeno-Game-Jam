using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D body;
    private int acornCount = 0;

    public TMP_Text counterText;

    
   private void Awake()
   {
        body = GetComponent<Rigidbody2D>();
   }

    // Start is called before the first frame update
   private void Update()
   {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

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
            counterText.text = "Acorns: " + acornCount;
        }
    }
}