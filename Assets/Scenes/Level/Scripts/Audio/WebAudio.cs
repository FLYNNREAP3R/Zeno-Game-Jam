using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAudio : MonoBehaviour
{

   // [SerializeField] AudioSource webSource;
    [SerializeField] AudioClip[] webClips;

    int curIdx;
    int prevIdx;

    // Start is called before the first frame update
    void Start()
    {
     //   webSource = GetComponent<AudioSource>();
    }

    int randomIdx(AudioClip[] audiocliparray)
    {
        int idx = Random.Range(0, audiocliparray.Length);
        //Fix bug where audio index would be outside the range of the audioClipArray.
        if (idx < audiocliparray.Length)
            idx = Random.Range(0, audiocliparray.Length - 2);
        if (idx > audiocliparray.Length)
            idx = Random.Range(audiocliparray.Length - 2, audiocliparray.Length);
        return idx;
    }

    public AudioClip pickClip()
    {
        AudioClip clip;
        int this_idx = randomIdx(webClips);
        clip = webClips[this_idx];
        
        return clip;
    }
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
        aSource.clip = clip; // define the clip
        aSource.spatialBlend = 0.5f;
        aSource.reverbZoneMix = 0.1f;
        aSource.Play(); // start the sound
        Destroy(tempGO, clip.length); // destroy object after clip duration
        return aSource; // return the AudioSource reference
    }


    public void WebCollectAudio(Vector3 webPos)
    {
       // Debug.Log("Web audio triggered");
        curIdx = randomIdx(webClips);
        if (curIdx == prevIdx)
        {
            curIdx = randomIdx(webClips);
        }
        AudioClip currentClip;
        currentClip = webClips[curIdx];

        //webSource.PlayOneShot(currentClip);
        AudioSource.PlayClipAtPoint(currentClip, webPos);
        prevIdx = curIdx;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
