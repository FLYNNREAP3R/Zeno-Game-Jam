using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAudio : MonoBehaviour
{

    [Header("Player Character Source")]
    [SerializeField] AudioSource playerCharAudioSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip[] jumpAudioarray;
    [SerializeField] AudioClip[] hurtAudioarray;


    [Header("Monitor Clip Indexes")]
    [SerializeField] int curJumpIdx;
    [SerializeField] int prevJumpIdx;
    [SerializeField] int curHurtIdx;
    [SerializeField] int prevHurtIdx;
    // Start is called before the first frame update
    void Start()
    {
        playerCharAudioSource = GetComponent<AudioSource>();
    }


    int randomIdx(AudioClip[] audiocliparray)
    {
        int idx = Random.Range(0, audiocliparray.Length);
        return idx;
    }

    public void jumpAudio()
    {
        //Create clip index number to play random sound
        curJumpIdx = randomIdx(jumpAudioarray);
        AudioClip currentClip;

        // if currentIdx eq PrevIdx, then re-randomize sound. Prevents 1 sound playing twice in a row.
        if (curJumpIdx == prevJumpIdx)
            currentClip = jumpAudioarray[curJumpIdx + 1];
        else
            currentClip = jumpAudioarray[curJumpIdx];
        //Debug.Log("Current jump Index: " + prevJumpIdx);
        //Debug.Log("Prev jump Index: " + prevJumpIdx);

        playerCharAudioSource.PlayOneShot(currentClip);
        prevJumpIdx = curJumpIdx;

    }

    // public void hurtAudio()
    // {
    //     //Create clip index number to play random sound
    //     curHurtIdx = randomIdx(hurtAudioarray);
    //     AudioClip currentClip;

    //     // if currentIdx eq PrevIdx, then re-randomize sound. Prevents 1 sound playing twice in a row.
    //     if (curHurtIdx == prevHurtIdx)
    //         currentClip = hurtAudioarray[curHurtIdx + 1];
    //     else
    //         currentClip = hurtAudioarray[curHurtIdx];
    //     //Debug.Log("Current hurt Index: " + prevHurtIdx);
    //     //Debug.Log("Prev hurt Index: " + prevHurtIdx);

    //     playerCharAudioSource.PlayOneShot(currentClip);
    //     prevHurtIdx = curHurtIdx;

    // }
}