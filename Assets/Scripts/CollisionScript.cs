using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public Text coinText;
    public int coin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);

            coin += 10;
            coinText.text = $"Coin : {coin}";
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
