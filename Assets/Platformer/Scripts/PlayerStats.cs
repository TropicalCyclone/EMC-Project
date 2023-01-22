using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Score;
    public Text ScoreText;

    private void Awake()
    {
        loadData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.DeleteKey("PlayerX");
            PlayerPrefs.DeleteKey("PlayerCoins");
        }
    }

    public void loadData()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
            Score = PlayerPrefs.GetInt("PlayerCoins");
            ScoreText.text = Score.ToString("000,000,000");
        }
    }

    public void EditScore(int amount)
    {
        
        Score += amount;
       
        ScoreText.text = Score.ToString("000,000,000");
    }

}
