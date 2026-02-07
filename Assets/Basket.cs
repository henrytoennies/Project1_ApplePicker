using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    
    public TextMeshProUGUI scoreGT;
    public TextMeshProUGUI roundGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        GameObject roundGO = GameObject.Find("RoundDisplay");
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        roundGT = roundGO.GetComponent<TextMeshProUGUI>();
        scoreGT.text = "0";
        roundGT.text = "Round " + HighScore.round.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        pos.z = 17;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            //int score = int.Parse(scoreGT.text);
            if (HighScore.score < 10000)
            {
                HighScore.score += 100;
            } else if (HighScore.score < 50000) 
            {
                HighScore.score += 50;
            } else
            {
                HighScore.score += 10;
            }
            
            scoreGT.text = HighScore.score.ToString();

            if (HighScore.score > HighScore.highScore)
            {
                HighScore.highScore = HighScore.score;
            }

            if ((HighScore.score % 1000) == 0)
            {
                HighScore.round++;
                AppleTree.speed += 2f;
            }
            if ((HighScore.score < 10000) && (HighScore.score % 2000) == 0)
            {
                AppleTree.secondsBetweenAppleDrops -= 0.1f;
            }
            if ((HighScore.score < 10000) && ((HighScore.score % 5000) == 0))
            {
                AppleTree.chanceToChangeDirections *= 2f;
            }

            roundGT.text = "Round " + HighScore.round.ToString();
        }

        if (collidedWith.tag == "Bomb")
        {
            Destroy(this.gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();
        }
    }
}
