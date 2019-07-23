using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSceneToGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");                //on play button click move to Gameplay scene
    }
}
