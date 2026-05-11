using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject levelSelect;
    [SerializeField] private GameObject normalScreen;
    [SerializeField] private SettingsControl SC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SC.forStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Opens the level select screen.
    public void enterLevelSelect()
    {
        levelSelect.SetActive(true);
        normalScreen.SetActive(false);
    }
    //Exits the level select screen.
    public void exitLevelSelect()
    {

        levelSelect.SetActive(false);
        normalScreen.SetActive(true);

    }
    //Loads levels. For levels 1,2, and 3, checks HowMany to see if the level has already been reached.
    public void LoadTutorial() { SceneManager.LoadSceneAsync("SampleScene"); }

    public void LoadLvl1() { 
        if(PlayerController.HowMany() >=  1)
        {
            SceneManager.LoadSceneAsync("Level 1");
        }
        }

    public void LoadLvl2()
    {
        if (PlayerController.HowMany() >= 2)
        {
            SceneManager.LoadSceneAsync("Level 2");
        }
    }

    public void LoadLvl3()
    {
        if (PlayerController.HowMany() >= 3)
        {
            SceneManager.LoadSceneAsync("Level 3");
        }
    }

}
