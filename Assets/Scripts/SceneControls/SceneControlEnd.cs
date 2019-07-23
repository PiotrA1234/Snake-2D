using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneControlEnd : MonoBehaviour
{
    private Text text1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EntryMenu");                //on quit button clicked move to Main Menu
    }
   public void PlayGame()
    {
        PlayerPrefs.SetString("score", 0.ToString());
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");            //on restart button clicked move to Gameplay scene
    }
}
