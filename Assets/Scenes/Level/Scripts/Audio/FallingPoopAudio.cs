using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoopAudio : MonoBehaviour
{

    [Header("Falling Poop Source")]
    [SerializeField] AudioSource fallPoopAudioSource;

    [Header("Falling Poop Clips")]
    [SerializeField] AudioClip[] fallPoopAudio;
    

    [Header("Monitor Clip Indexes")]
    [SerializeField] int curIdx;
    [SerializeField] int prevIdx;

    // Start is called before the first frame update
    void Start()
    {
        fallPoopAudioSource = GetComponent<AudioSource>();
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

    public void poopAudio()
    {
        //Create clip index number to play random sound
        curIdx = randomIdx(fallPoopAudio);
        AudioClip currentClip;

        // 5/2/24 disabled if statement. Resolved in randomIdx function.
        // if currentIdx eq PrevIdx, then re-randomize sound. Prevents 1 sound playing twice in a row.

        //if (curIdx == prevIdx)
        //    currentClip = fallPoopAudio[curIdx + 1];
        //else
        //    currentClip = fallPoopAudio[curIdx];

        currentClip = fallPoopAudio[curIdx];

        //Debug.Log("Current ScoreUp Index: " + curIdx);
        //Debug.Log("Prev ScoreUp Index: " + prevIdx);

        fallPoopAudioSource.PlayOneShot(currentClip);
        prevIdx = curIdx;

    }
}