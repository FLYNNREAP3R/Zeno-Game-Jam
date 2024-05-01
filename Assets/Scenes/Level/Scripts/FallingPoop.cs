using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoop : MonoBehaviour
{

    public int speed;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine( MakePoopFall() );
    }


    // Will update coroutine logic once level has been updated

    private IEnumerator MakePoopFall() {
        yield return new WaitForSeconds( 30.0f );
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        float distanceFromObjectToBorder = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)).x;
        var randomSpawnPointsForPoop = Random.Range(-distanceFromObjectToBorder,distanceFromObjectToBorder);


        if (transform.position.y < -4)
        {
            transform.position = new Vector3(randomSpawnPointsForPoop,5,0);
        }
    }
}
