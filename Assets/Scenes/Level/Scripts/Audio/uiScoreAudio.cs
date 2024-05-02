using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiScoreAudio : MonoBehaviour
{

    [Header("UI Audio Source")]
    [SerializeField] AudioSource uiAudioSource;

    [Header("UI Audio Clips")]
    [SerializeField] AudioClip[] uiScoreUpAudio;
    [SerializeField] AudioClip[] uiScoreDownAudio;

    [Header("Monitor Clip Indexes")]
    [SerializeField] int curUpIdx;
    [SerializeField] int curDownIdx;
    [SerializeField] int prevUpIdx;
    [SerializeField] int prevDownIdx;

    // Start is called before the first frame update
    void Start()
    {
        uiAudioSource = GetComponent<AudioSource>();
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


    //public void changeScoreAudio(string score_dir)
    //{
    //    int currentDownIdx;
    //    int currentUpIdx;

    //    int PrevDownIdx;
    //    int PrevUpIdx;

    //    switch (score_dir)
    //    {
    //        case "down":
    //            currentDownIdx = randomIdx(uiScoreDownAudio);
    //            break;
    //        case "up":
    //            currentUpIdx = randomIdx(uiScoreUpAudio);
    //            if (currentUpIdx == PrevIdx)
    //                currentClip = uiScoreUpAudio[currentIdx + 1];
    //            else
    //                currentClip = uiScoreUpAudio[currentIdx];

    //            break;
    //    }


    //    Debug.Log("Current Index: " + currentIdx);
    //    Debug.Log("Prev Index: " + PrevIdx);

    //    uiAudioSource.PlayOneShot(currentClip);
    //    PrevIdx = currentIdx;

    //}

    public void scoreUpAudio()
    {
        //Create clip index number to play random sound
        curUpIdx = randomIdx(uiScoreUpAudio);
        AudioClip currentClip;

        // 5/2/24 disabled if statement. Resolved in randomIdx function.

        // if currentIdx eq PrevIdx, then re-randomize sound. Prevents 1 sound playing twice in a row.
       
        //if (curUpIdx == prevUpIdx)
        //    currentClip = uiScoreUpAudio[curUpIdx + 1];
        //else
        //    currentClip = uiScoreUpAudio[curUpIdx];

        currentClip = uiScoreUpAudio[curUpIdx];
        //Debug.Log("Current ScoreUp Index: " + curUpIdx);
        //Debug.Log("Prev ScoreUp Index: " + prevUpIdx);

        uiAudioSource.PlayOneShot(currentClip);
        prevUpIdx = curUpIdx;

    }

    public void scoreDownAudio()
    {
        //Create clip index number to play random sound
        curDownIdx = randomIdx(uiScoreDownAudio);
        AudioClip currentClip;

        // 5/2/24 disabled if statement. Resolved in randomIdx function.

        // if currentIdx eq PrevIdx, then re-randomize sound. Prevents 1 sound playing twice in a row.

        //if (curDownIdx == prevDownIdx)
        //    currentClip = uiScoreDownAudio[curDownIdx + 1];
        //else
        //    currentClip = uiScoreDownAudio[curDownIdx];

        currentClip = uiScoreDownAudio[curDownIdx];
        //Debug.Log("Current ScoreDwn Index: " + curDownIdx);
        //Debug.Log("Prev ScoreDwn Index: " + prevDownIdx);

        uiAudioSource.PlayOneShot(currentClip);
        prevUpIdx = curDownIdx;


    }
}