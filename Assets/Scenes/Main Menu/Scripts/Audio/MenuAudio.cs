using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuAudio : MonoBehaviour
{
    [Header("Menu Audio Source")]
    [SerializeField] AudioSource audioSource;
    //[SerializeField] AudioClip uiSelectAudio;
    [SerializeField] AudioClip[] UISelectAudioList;
    [SerializeField] AudioClip uiHoverAudio;
    int PrevIdx;

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

    public void OnClick()
    {
        //Create clip index number to play random sound
        int currentIdx = randomIdx(UISelectAudioList);
        AudioClip currentClip = UISelectAudioList[currentIdx];
        // if currentIdx eq PrevIdx, then re-randomize sound. Prevents 1 sound playing twice in a row.
        //if (currentIdx == PrevIdx)
        //    currentClip = UISelectAudioList[currentIdx+1];
        //else
        //    currentClip = UISelectAudioList[currentIdx];
        //Debug.Log("Current Index: " + currentIdx);
        //Debug.Log("Prev Index: " + PrevIdx);

        audioSource.PlayOneShot(currentClip);
        PrevIdx = currentIdx; 

    }
    //public void OnClick()
    //{
    //    if (uiSelectAudio && audioSource) 
    //    audioSource.PlayOneShot(uiSelectAudio) ;

    //}
}
