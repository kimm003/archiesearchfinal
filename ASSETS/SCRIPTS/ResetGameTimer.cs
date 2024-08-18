using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject gameFailed;

    public float countdownDuration = 120f; // 2 minutes in seconds
    private float remainingTime;
    void Start()
    {
        remainingTime = countdownDuration;
        UpdateCountdownText();
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if(remainingTime == 0 && Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private System.Collections.IEnumerator Countdown()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
            UpdateCountdownText();
        }
        // When the countdown reaches 0, you can trigger any additional behavior here
        countdownText.text = "00:00";

        CountdownComplete();
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CountdownComplete()
    {
        gameFailed.SetActive(true);
    }
}
