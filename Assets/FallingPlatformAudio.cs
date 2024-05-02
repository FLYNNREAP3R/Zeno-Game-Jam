using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformAudio : MonoBehaviour
{
    [Header("Falling Platform Source")]
    [SerializeField] AudioSource fallPlatAudioSource;

    [Header("Falling PlatformClips")]
    [SerializeField] AudioClip[] fallPlatAudio;


     int curIdx;
     int prevIdx;


    void Start()
    {
        fallPlatAudioSource = GetComponent<AudioSource>();
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

    public void branchAudio()
    {
        //Create clip index number to play random sound
        curIdx = randomIdx(fallPlatAudio);
        AudioClip currentClip;

        currentClip = fallPlatAudio[curIdx];

        //Debug.Log("Current ScoreUp Index: " + curIdx);
        //Debug.Log("Prev ScoreUp Index: " + prevIdx);

        fallPlatAudioSource.PlayOneShot(currentClip);
        prevIdx = curIdx;

    }
}

