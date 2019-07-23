
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void EndGame() {
        RestartMenu();
    }
    void RestartMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");                         //after colliding with an object, move to endgame menu
    }
}
