using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    //Keeps track of the number of keys collected.
    public int keyNumber;

    //When the door is collided with by the player, if both keys have been collected, moves to the next scene.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && keyNumber == 2)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    //Used by KeyController to add to keyNumber.
    public void addKeys()
    {
        keyNumber++;
    }
}
