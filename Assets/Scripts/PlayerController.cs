using System;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private InputAction move;
    private Vector3 playerMovement;
    private Vector2 moveDirection;
    [SerializeField] private float jumpValue;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Move");
      

        move.performed += MovePerformed;
        move.canceled += MoveCanceled;
        
    }


    
    /// <summary>
    /// Starts moving the player.
    /// </summary>
    /// <param name="obj"></param>
    private void MovePerformed(InputAction.CallbackContext obj)
    {
        playerMovement.x = obj.ReadValue<Vector2>().x * playerSpeed;
        playerMovement.z = obj.ReadValue<Vector2>().y * playerSpeed;
    }
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //Moves the player at a consistent speed.
        moveDirection = move.ReadValue<Vector2>();
        rb.linearVelocity = transform.TransformDirection(new Vector3(moveDirection.x * playerSpeed, rb.linearVelocity.y,
            moveDirection.y * playerSpeed));
    }




    //Prevents errors.
    private void OnDestroy()
    {
        move.performed -= MovePerformed;
        move.canceled -= MoveCanceled;
        
    }
}
