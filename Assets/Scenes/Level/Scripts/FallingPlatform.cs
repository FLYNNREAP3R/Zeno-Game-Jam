using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float fallDelay, respawnTime;

    GameObject platOjb;
    FallingPlatformAudio platAudio;
    private bool clipPlayed = false;

    Rigidbody2D rb;
    Vector2 defaultPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultPos = transform.position;

        platOjb = GameObject.Find("Falling Platform");
        platAudio = platOjb.GetComponent<FallingPlatformAudio>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine("Fall");
            while (clipPlayed == false)
            {
                platAudio.branchAudio();
                clipPlayed = true;
            }
            
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(respawnTime);
        Reset();
    }

    private void Reset()
    {
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = defaultPos;
        clipPlayed = false;
    }
}
