using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAudio : MonoBehaviour
{

    [Header("Player Character Source")]
    [SerializeField] AudioSource playerCharAudioSource;
    [SerializeField] AudioSource playerStepSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip[] jumpAudioarray;
    [SerializeField] AudioClip[] hurtAudioarray;
    [SerializeField] AudioClip[] ftStepArray;


    [Header("Monitor Clip Indexes")]
    [SerializeField] int curJumpIdx;
    [SerializeField] int prevJumpIdx;
    [SerializeField] int curHurtIdx;
    [SerializeField] int prevHurtIdx;

    int curStepIdx;
    int prevStepIdx;
    // Start is called before the first frame update
    void Start()
    {
        playerCharAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
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


    public void playStep()
    {

            StartCoroutine(stepWait());

    }

    public void stopStep()
    {
        playerStepSource.Stop();
    }
    public void ftstepClip()
    {
        
       
        curStepIdx = randomIdx(ftStepArray);
        AudioClip currentClip;
        currentClip = ftStepArray[curStepIdx];
        playerStepSource.PlayOneShot(currentClip);
        prevStepIdx = curStepIdx;

        

    }

    public void jumpAudio()
    {
        //Create clip index number to play random sound
        curJumpIdx = randomIdx(jumpAudioarray);
        AudioClip currentClip;
        currentClip = jumpAudioarray[curJumpIdx];
        //Debug.Log("Current jump Index: " + prevJumpIdx);
        //Debug.Log("Prev jump Index: " + prevJumpIdx);

        playerCharAudioSource.PlayOneShot(currentClip);
        prevJumpIdx = curJumpIdx;

    }

    public void hurtAudio()
    {
        //Create clip index number to play random sound
        curHurtIdx = randomIdx(hurtAudioarray);
        AudioClip currentClip;
        currentClip = hurtAudioarray[curHurtIdx];
        //Debug.Log("Current hurt Index: " + prevHurtIdx);
        //Debug.Log("Prev hurt Index: " + prevHurtIdx);

        playerCharAudioSource.PlayOneShot(currentClip);
        prevHurtIdx = curHurtIdx;

    }

    IEnumerator stepWait()
    {
        yield return new WaitUntil(() => playerStepSource.isPlaying == false);
        ftstepClip();
    }
}