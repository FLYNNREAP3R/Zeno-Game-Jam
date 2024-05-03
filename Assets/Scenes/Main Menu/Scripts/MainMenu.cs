using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource musSource;
    public void PlayGame()
    {
        StartCoroutine(fadeAudio(musSource, 2.0f, -80.0f));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public IEnumerator fadeAudio(AudioSource audioSource, float duration, float targetVol)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while( currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVol, currentTime / duration);
            yield return null;
        }
        yield break;
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
