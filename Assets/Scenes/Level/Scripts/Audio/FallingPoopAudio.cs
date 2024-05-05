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

    public float pitchMin = 0.5f;
    public float pitchMax = 1.8f;

    public float volMin = 0.3f;
    public float volMax = 0.7f;



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
        setClipParam();
        //Create clip index number to play random sound
        curIdx = randomIdx(fallPoopAudio);
        AudioClip currentClip;


        currentClip = fallPoopAudio[curIdx];

        //Debug.Log("Current ScoreUp Index: " + curIdx);
        //Debug.Log("Prev ScoreUp Index: " + prevIdx);

        fallPoopAudioSource.PlayOneShot(currentClip);
        prevIdx = curIdx;

    }

    void setClipParam()
    {

        float playVol = Random.Range(volMin, volMax);
        float playPitch = Random.Range(pitchMin, pitchMax);
        fallPoopAudioSource.volume = playVol;
        //Debug.Log("vol: " + playVol);
        fallPoopAudioSource.pitch = playPitch;
        //Debug.Log("pitch: " + playPitch);

    }

}