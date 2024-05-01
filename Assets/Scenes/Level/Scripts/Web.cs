using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSlowed;
    [SerializeField] float slowDelay = 0.5f;

    PlayerController playerController;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("SlowWebMovement");
        }
    }

    IEnumerator SlowWebMovement()
    {
        yield return new WaitForSeconds(slowDelay);
    }
}
