using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;
    public float jumpForce;

    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D RB;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        
    }
    private void TouchPressed(InputAction.CallbackContext context)
    {
            RB.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
}
