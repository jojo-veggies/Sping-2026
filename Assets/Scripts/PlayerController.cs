using System;
using Unity.Cinemachine;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private InputAction move;
    private InputAction carry;
    private Vector3 playerMovement;
    private Vector2 moveDirection;
    [SerializeField] private float jumpValue;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private GameObject player;
    public float sphereRadius;
    private Collider[] rampCollider;
    private bool isHolding;
    private bool canHold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isHolding = false;
        canHold = true;
        rb = GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Move");
        carry = InputSystem.actions.FindAction("Interact");

        move.performed += MovePerformed;
        move.canceled += MoveCanceled;
        carry.performed += InteractPerformed;
        carry.canceled += InteractCanceled;
        
    }

    //Picks up a ramp based on parameters: if there isn't one being held, and if the player isn't on it.
    private void InteractPerformed(InputAction.CallbackContext obj)
    {
        if (canHold == true)
        {
            if (isHolding == false)
            {
                rampCollider = Physics.OverlapSphere(transform.position, sphereRadius, LayerMask.GetMask("Ramps"));
                if (rampCollider.Length >= 1)
                {

                    rampCollider[0].transform.position = new Vector3(player.transform.position.x,
                        player.transform.position.y, player.transform.position.z + 2);
                    rampCollider[0].transform.SetParent(player.transform);
                    rampCollider[0].GetComponent<Rigidbody>().isKinematic = true;
                    rampCollider[0].GetComponent<MeshCollider>().isTrigger = true;

                    isHolding = true;
                }
            }
            else if (isHolding == true)
            {
                rampCollider[0].GetComponent<Rigidbody>().isKinematic = false;
                rampCollider[0].GetComponent<MeshCollider>().isTrigger = false;

                rampCollider[0].transform.SetParent(null);
                rampCollider = null;
                isHolding = false;
            }
        }
    }
    //Does nothing, but I don't actually know what'll happen if i delete it, so it stays.
    private void InteractCanceled(InputAction.CallbackContext obj)
    {
        


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


    //Makes it not possible to hold a ramp while standing on it.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ramp")
        {
            canHold = false;
        }

    }

    //Makes it possible to hold ramps again.
    void OnCollisionExit(Collision col)
    {
        canHold = true;
    }
    // Update is called once per frame
    void Update()
    {

        //Restarts.
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
        carry.performed -= InteractPerformed;
        carry.canceled -= InteractCanceled;
        
    }
}
