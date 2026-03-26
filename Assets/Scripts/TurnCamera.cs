using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnCamera : MonoBehaviour
{
    /// <summary>
    /// Variety of objects needed to set up the camera turn. turn is the camera itself, player is the player, and 
    /// camera transform is there to set the player's direction.
    /// </summary>
    [SerializeField] private GameObject turn;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform cameraTransform;
    private InputAction rightClick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rightClick = InputSystem.actions.FindAction("CameraMove");
        rightClick.performed += CameraMovePerformed;
        rightClick.canceled += CameraMoveCanceled;
    }
    /// <summary>
    /// Enables or disables the part of the camera that follows the cursor, allowing for a hold right click to turn
    /// camera style, like in most game.
    /// </summary>
    /// <param name="obj"></param>
    private void CameraMovePerformed(InputAction.CallbackContext obj)
    {
        turn.GetComponent<CinemachineInputAxisController>().enabled = true;

    }
    private void CameraMoveCanceled(InputAction.CallbackContext obj)
    {
        turn.GetComponent<CinemachineInputAxisController>().enabled = false;

    }


    /// <summary>
    /// Makes the player face the direction of the camera, allowing for easy movement.
    /// </summary>
    private void Update()
    {
        player.transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

    }
    public void OnDestroy()
    {
        rightClick.performed -= CameraMovePerformed;
        rightClick.canceled -= CameraMoveCanceled;
    }
}
