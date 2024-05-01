using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoop : MonoBehaviour
{

    public int speed;
    public Camera cam;
    public PlayerController playerController;

    Vector2 defaultPos;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine( "MakePoopFall" );
    }

    IEnumerator MakePoopFall() {
        yield return new WaitForSeconds( 5.0f );
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        float distanceFromObjectToBorder = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).x;
        var randomSpawnPointsForPoop = Random.Range(-distanceFromObjectToBorder,distanceFromObjectToBorder);

        if (transform.position.y < -3)
        {
            transform.position = new Vector3(randomSpawnPointsForPoop,5,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // This assigns the collision to knockback the player if they interact with the collision on an enemy by checking the tag.
            playerController.speed = playerController.speed - 8;
            Invoke("ResetPlayerSpeed",6f);
        }
        gameObject.SetActive(false);
        Invoke("ResetPoop", 1f);
    }

    private void ResetPoop() {
        gameObject.SetActive(true);
        transform.position = defaultPos;
    }

    private void ResetPlayerSpeed() {
        playerController.speed = 10;
    }
}
