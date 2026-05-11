using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private int timer;
    [SerializeField] private TMP_Text howLong;
    [SerializeField] private PlayerController PC;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BeginClock());
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Starts ticking the timer.
    private IEnumerator BeginClock()
    {
        yield return new WaitForSeconds(1);
        timer++;
        howLong.SetText("Time: " + timer);
        StartCoroutine(BeginClock());

    }

    //Goes back to the menu. Put here to save me time when attatching scripts.
    public void BackToMenu()
    {
       
        PC.unpause();
        SceneManager.LoadSceneAsync("GameStart");
    }
}
