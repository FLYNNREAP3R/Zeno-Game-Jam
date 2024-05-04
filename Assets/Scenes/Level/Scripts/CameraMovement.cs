using UnityEngine;
 using System.Collections;

 public class CameraMovement : MonoBehaviour {

     public float dampTime = 0.15f;
     private Vector3 velocity = Vector3.zero;
     public Transform target;

    public Camera cam;

    public GameObject envAudio;
    private float audioDamp = 0.05f;

    void Start() {
        cam = Camera.main;
        
    }


     // Update is called once per frame
     void Update ()
     {
         if (target)
         {
             Vector3 point = cam.WorldToViewportPoint(target.position);
             Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            envAudio.transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, audioDamp);
        }

     }
 }