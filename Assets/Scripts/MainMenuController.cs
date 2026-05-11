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

    public void enterLevelSelect()
    {
        levelSelect.SetActive(true);
        normalScreen.SetActive(false);
    }

    public void exitLevelSelect()
    {

        levelSelect.SetActive(false);
        normalScreen.SetActive(true);

    }
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
