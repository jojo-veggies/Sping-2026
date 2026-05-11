using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    //Loads the first level. Used to reset on clear and to start the game.
    public void Restart()
    {
        SceneManager.LoadSceneAsync("GameStart");
    }

    //Quits.
    public void Quit()
    {
        Application.Quit();
    }

  
}
