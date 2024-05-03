using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeOnAwake : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float duration;
    [SerializeField] float targetVol;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(fadeAudio(audioSource, duration, targetVol));
    }

    public IEnumerator fadeAudio(AudioSource audioSource, float duration, float targetVol)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVol, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}


