using UnityEngine;

public class TeleporterControl : MonoBehaviour
{
    //The point the teleporter will bring the palyer to.
    [SerializeField] private GameObject teleportPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

   

    private void OnCollisionEnter(Collision collision)
    {
        //When the player touches the object, teleports them to the previously set point.
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = teleportPoint.transform.position;
        }
    }
}
