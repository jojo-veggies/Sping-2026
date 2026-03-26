using UnityEngine;

public class KeyController : MonoBehaviour

{
    //Allows the ability to access DoorController, and thus the addKeys() method.
    [SerializeField] private DoorController DC;
     private void OnCollisionEnter(Collision collision)
    {
        //If the player collides with a key, adds it to the total and then removes itself.
        if(collision.gameObject.tag == "Player")
        {
            DC.addKeys();
            Destroy(gameObject);
        }
    }

    
}
