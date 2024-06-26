using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoop : MonoBehaviour
{
    public int speed;
    public Camera cam;
    public PlayerController playerController;

    private Vector3 defaultPos;
    private bool crossedPlayer;

    private GameObject poopObject;
    private FallingPoopAudio poopPlayScript;
    private bool playedAudio;

    private void Awake()
    {
        poopObject = GameObject.Find("Falling Poop");
        poopPlayScript = poopObject.GetComponent<FallingPoopAudio>();

    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        defaultPos = CalculateDefaultPosition();
        playedAudio = false;
        StartCoroutine(MakePoopFall());
        // Plays audio for first poop to fall on wake
        StartCoroutine(DelayAudio());



    }

    // Calculate the default position based on the player's position relative to the camera
    private Vector3 CalculateDefaultPosition()
    {   
    // Get the position of the player relative to the camera viewport
    Vector3 playerViewportPos = cam.WorldToViewportPoint(playerController.transform.position);
    
    // Calculate the height of the camera viewport
    float camHeight = 2f * cam.orthographicSize;

    // Calculate the vertical position of the player within the camera viewport
    float playerCamPosY = playerViewportPos.y * camHeight;
    
    // Calculate the offset from the initial position of the poop
    float yPos = transform.position.y + (transform.position.y - playerController.transform.position.y);
    
    return new Vector3(transform.position.x, yPos, transform.position.z);
    }

    // TODO: Allow audio to be re-triggered once if poop does not hit player.
    IEnumerator MakePoopFall()
    {

        yield return new WaitForSeconds(2.0f);
        while (true)
        {

            transform.Translate(Vector3.down * Time.deltaTime * speed);

            if (!crossedPlayer && transform.position.y < playerController.transform.position.y)
            {
                crossedPlayer = true;
            }

            if (crossedPlayer && transform.position.y < defaultPos.y)
            {
                float randomSpawnPointsForPoop = Random.Range(-cam.orthographicSize, cam.orthographicSize); // Randomize the horizontal position within the camera's view
                transform.position = new Vector3(transform.position.x, defaultPos.y, 0); // Reset vertically
                crossedPlayer = false; // Reset the flag
                // Check played audio bool
                // Prevents clip from being played more than once
                while (!playedAudio)
                {
                    StartCoroutine(DelayAudio());
                    
                    playedAudio = true;
                }
            }
            // Resets played audio bool when object is reset but did not hit player
            playedAudio = false;
            yield return null;
        }
    }

    IEnumerator DelayAudio()
    {
    
        yield return new WaitForSeconds(2.0f);
        poopPlayScript.poopAudio();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // This assigns the collision to knockback the player if they interact with the collision on an enemy by checking the tag.
            playerController.speed = playerController.speed / 5;
            playerController.jumpForce = playerController.jumpForce / 2;
            Invoke("ResetPlayerSpeedAndJumpForce", 6f);
        }
        gameObject.SetActive(false);
        Invoke("ResetPoop", 1f);
    }

    private void ResetPoop()
    {
        gameObject.SetActive(true);
        defaultPos = CalculateDefaultPosition();
        transform.position = defaultPos;

        // Resets play audio bool for when object does hit player
        playedAudio = false;
    }

    private void ResetPlayerSpeedAndJumpForce()
    {
        playerController.speed = 10;
        playerController.jumpForce = 10;
    }
}
