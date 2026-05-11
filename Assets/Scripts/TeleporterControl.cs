using UnityEngine;

public class TeleporterControl : MonoBehaviour
{
    //The point the teleporter will bring the player to.
    [SerializeField] private GameObject teleportPoint;

   

    private void OnCollisionEnter(Collision collision)
    {
        //When the player touches the object, teleports them to the previously set point.
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ramp")
        {
            collision.gameObject.transform.position = teleportPoint.transform.position;
        }
    }
}
