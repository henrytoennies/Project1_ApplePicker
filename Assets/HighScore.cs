using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    static public int highScore = 1000;
    static public int round;
    static public int score;

    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI gt = this.GetComponent<TextMeshProUGUI>();
        gt.text = "High Score: " + highScore;

        if (highScore > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        
    }
}
