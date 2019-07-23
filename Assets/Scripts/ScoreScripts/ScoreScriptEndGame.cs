using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScriptEndGame : MonoBehaviour
{
    public Text scoreText;
   // public GameObject abc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        scoreText.text = PlayerPrefs.GetString("score");                // at the gameEnd get actual score from PlayerPrefs set from Gameplay scene
    }
  
}
