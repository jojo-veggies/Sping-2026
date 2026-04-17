using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    //Keeps track of the number of keys collected.
    public int keyNumber;
    [SerializeField] private Renderer doorRenderer;
    [SerializeField] private GameObject playerView;
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject player;

    //When the door is collided with by the player, if both keys have been collected, moves to the next scene.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && keyNumber == 1)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    //Used by KeyController to add to keyNumber.
    public void addKeys()
    {
        keyNumber++;
        StartCoroutine(lookAtDoor());
        
    }

    //Plays a small cutscene when unlocking a door.
    private IEnumerator lookAtDoor()
    {
        playerCamera.Follow = door.transform;
        yield return new WaitForSeconds(.5f);
        doorRenderer.material.color = Color.green;
        yield return new WaitForSeconds(1);
        playerCamera.Follow = player.transform;

    }
}
