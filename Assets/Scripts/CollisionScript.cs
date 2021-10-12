using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public Text coinText, timerText;
    public int coins;

    public float timeLeft;
    public int timeRemaining;

    private float timerValue;

    void Start()
    {
        
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeLeft % 60);

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
        }

        timerText.text = "Timer : " + timeRemaining.ToString();

        if (coins >= 60)
        {
            if (timeLeft <= timerValue)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }
        else if (timeLeft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);

            coins += 10;
            coinText.text = $"Coin : {coins}";
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
