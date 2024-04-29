using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] AudioClip uiSelectAudio;
    [SerializeField] AudioClip uiHoverAudio;
    [SerializeField] AudioSource audioSource;



    public void OnClick()
    {
        if (uiSelectAudio && audioSource) 
        audioSource.PlayOneShot(uiSelectAudio) ;

    }
}
