using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject countDown;
    public float startTime;

    private void Awake()
    {
        remainingTime = startTime;
    }
    private void Update()
    {

        remainingTime -= Time.deltaTime;
        if (remainingTime > 0)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
        }
        else if (remainingTime <= 0)
        {
            Time.timeScale = 0;
            loseText.SetActive(true);
            countDown.SetActive(false);
        }

    }
}
