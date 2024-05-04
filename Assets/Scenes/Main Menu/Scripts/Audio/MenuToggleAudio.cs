using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuToggleAudio : MonoBehaviour
{

    [SerializeField] AudioMixer sfxMixer;
    [SerializeField] AudioMixer musMixer;
    [SerializeField] GameObject button;
    Toggle audioToggle;

    void Awake()
    {
        audioToggle = button.GetComponent<Toggle>();

        //Debug.Log(audioToggle.isOn);
    }


    public void ToggleAudio()
    {
        //Debug.Log(audioToggle.isOn);
        if (audioToggle.isOn == false)
        {
            // mute audio
            //Debug.Log("Mute");
            musMixer.SetFloat("volume", -80.0f);
            sfxMixer.SetFloat("volume", -80.0f);
            //AudioListener.pause = true;
        }
        else
        {
            // unmute audio

            //Debug.Log("Unmute");
            musMixer.SetFloat("volume", 0.0f);
            sfxMixer.SetFloat("volume", 0.0f);
            //AudioListener.pause = false;
        }
        
        
    }



}
