using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class randomAmbientOneShots : MonoBehaviour
{

    [Header("Player Character Source")]
    [SerializeField] AudioSource oneShotsAudioSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] oneShots;

    [Range(0.5f, 1.8f)]
    public float pitchMin = 0.5f;
    public float pitchMax = 1.8f;
    
    public float volMin = 0.3f;
    public float volMax = 0.7f;

    

    private int curIdx;
    //private int prevIdx;


    // Start is called before the first frame update
    void Start()
    {
        oneShotsAudioSource = GetComponent<AudioSource>();
        if (oneShotsAudioSource)
        {
            InvokeRepeating("oneShotAudio", 3, 10);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    int randomIdx(AudioClip[] audiocliparray)
    {
        int idx = Random.Range(0, audiocliparray.Length);
        //Fix bug where audio index would be outside the range of the audioClipArray.
        if (idx < audiocliparray.Length)
            idx = Random.Range(0, audiocliparray.Length - 2);
        if (idx > audiocliparray.Length)
            idx = Random.Range(audiocliparray.Length - 4, audiocliparray.Length);
        return idx;
    }


    void oneShotAudio()
    {

        setClipParam();
        curIdx = randomIdx(oneShots);
        AudioClip currentClip;
        currentClip = oneShots[curIdx];
        oneShotsAudioSource.clip = currentClip;
        oneShotsAudioSource.Play();
        //Debug.Log("Oneshot triggered.");
        //prevIdx = curIdx;

    }   
    
    void setClipParam()
    {
        
        float playVol = Random.Range(volMin, volMax);
        float playPitch = Random.Range(pitchMin, pitchMax); 
        oneShotsAudioSource.volume = playVol;
        //Debug.Log("vol: " + playVol);
        oneShotsAudioSource.pitch = playPitch;
        //Debug.Log("pitch: " + playPitch);

    }
}
