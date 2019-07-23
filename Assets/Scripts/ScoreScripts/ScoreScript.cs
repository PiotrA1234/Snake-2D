using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public Text scoreText;                  //ui active text score

    // Start is called before the first frame update
    void Start()
    {
        SnakeCollider.Score = 0;                            // after restarting game we should reset the score to 0
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = SnakeCollider.Score.ToString();                                //increase UI Text depending on score achieved by player
 
    }
    void OnDisable()
    {
        PlayerPrefs.SetString("score",scoreText.text);                          //after losing the game, set score to playerprefs
    }
}
