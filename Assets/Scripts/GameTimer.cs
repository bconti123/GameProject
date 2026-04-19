using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeLeft = 30f;
    public TMP_Text timerText;
    public GameObject winText;
    public GameObject loseText;

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            timerText.text = "Time: 0";
            winText.SetActive(true);
            gameEnded = true;
            Time.timeScale = 0f;
        }
    }

    public void LoseGame()
    {
        if (gameEnded) return;

        loseText.SetActive(true);
        gameEnded = true;
        Time.timeScale = 0f;
    }
}