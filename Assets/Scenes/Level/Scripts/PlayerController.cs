using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private int acornCount = 0;
    public float speed;  // Movement speed
    public float jumpForce;
    private bool grounded;
    private float jumpDelay;
    private float moveDelay;
    private float jumpCounter;

    private GameObject ui_scoreObj;
    private uiScoreAudio uiScoreScript;

   //private GameObject pineconeObj;
    private PineconeAudio pineconeAudio;

    private GameObject playerAudioObj;
    private PlayerCharacterAudio playerAudioScript;
    private PlayerFootStepAudio playerFtstp;
    private Coroutine ftstpRoutine;
    
    public TMP_Text counterText;
    public TMP_Text winText;

    public float knockbackForce;
    public float knockbackCounter = 0;
    public float knockbackTime;
    public bool knockFromRight;

    private Vector3 thisScale;

    public bool canMove = true;

    private void Start()
    {
        ResetJump();
    }
    
   private void Awake()
   {
        thisScale = gameObject.transform.localScale;
        ui_scoreObj = GameObject.Find("UI");
        uiScoreScript = ui_scoreObj.GetComponent<uiScoreAudio>();
        playerAudioObj = GameObject.Find("Player");
        playerAudioScript = playerAudioObj.GetComponent<PlayerCharacterAudio>();
        body = GetComponent<Rigidbody2D>();
        StartCoroutine("Delay");
   }

    // Start is called before the first frame update
   private void Update()
   {
        
        if (canMove)
        {
            Movement();
            if (grounded && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)))
            {
               //  Debug.Log("Key Down");
                if (ftstpRoutine == null)
                //playerAudioScript.ftstepClip();
                    ftstpRoutine = StartCoroutine(playerAudioScript.stepWait());
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || !grounded)
            {

                //Debug.Log("Key Up");
                if (ftstpRoutine != null)
                {
                    //playerAudioScript.stopStep();

                    StopCoroutine(ftstpRoutine);
                    ftstpRoutine = null;
                }
            }

            Jump();
        }
        
   }

    private void Movement()
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
                body.velocity = new Vector2(-knockbackForce, -knockbackForce);
                
            }
            // If player is hit from the left, the player will go right
            if (knockFromRight == false)
            {
                body.velocity = new Vector2(knockbackForce, -knockbackForce);
                
            }
        }

        // Checks if "d" is pressed to move right and flips the character facing right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = thisScale;
            //transform.localScale = Vector3.one;
        }

        // Checks if "a" is pressed to move left and flips the character facing left
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-thisScale.x, thisScale.y, thisScale.z);
            //transform.localScale = new Vector3(-1, 1, 1);


    }

    private void Jump()
    {
        // Checks to see if spacebar is pressed to initiate jump and is grounded
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            playerAudioScript.jumpAudio();
            grounded = false;
            //StartCoroutine("Delay");
        }
    }

    private void ResetJump()
    {
        grounded = true;
        jumpDelay = 0;
    }

    IEnumerator Delay()
    {
        jumpDelay++;
        yield return new WaitForSeconds(jumpDelay);
        grounded = true;
        moveDelay++;
        yield return new WaitForSeconds(moveDelay);
        moveDelay = 0;
        knockbackCounter = 0;
        canMove = true;


    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks if the player is interacting with the acorn via tag
        if (collision.CompareTag("acorn") && collision.gameObject.activeSelf)
        {
            collision.gameObject.SetActive(false);
            uiScoreScript.scoreUpAudio(); // trigger score up audio
            acornCount += 1;
            counterText.text = "Acorns: " + acornCount;
        }

        if (collision.CompareTag("Win") && collision.gameObject.activeSelf)
        {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetJump();
        }
        if (collision.gameObject.tag == "poop")
        {
            ReduceAcorn();
            playerAudioScript.hurtAudio();
        }
        // Checks if the player is running into the pinecone or poop and if the player's collider is set to true
        if (collision.gameObject.tag == "pinecone" && collision.gameObject.activeSelf)
        {
            // play pinecone explode audio
            pineconeAudio = collision.gameObject.GetComponent<PineconeAudio>();
            pineconeAudio.PlayClipAt(pineconeAudio.pickClip(), collision.gameObject.transform.position);
            //pineconeAudio.pineconeCollectAudio(collision.gameObject.transform.position);
            
            // Destroys pinecone actor when player collides with object. Knocks back the player and subtracts 2 from the acorn counter
            collision.gameObject.SetActive(false);
            
            // play character hurt audio
            playerAudioScript.hurtAudio();
            ReduceAcorn();
            Stunned();
        }
    }
    private void Stunned()
    {
        // Sets move to false adds 1 to knockback counter then sets a delay to reset movement
        canMove = false;
        knockbackCounter++;
        StartCoroutine("Delay");
    }

   



    void ReduceAcorn() {
        if (acornCount > 2)
            {
                uiScoreScript.scoreDownAudio(); // trigger score down audio
                acornCount = acornCount - 2;
            }
            counterText.text = "Acorns: " + acornCount;
    }

    

    

}
