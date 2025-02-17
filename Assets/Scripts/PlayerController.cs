using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    private Vector2 moveInput;
    private Rigidbody2D rb;
   
    private float jumpForce=4.5f;

    private void Awake()
    {
        playerControls=new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }
    private void OnEnable()
    {
        playerControls.Player.Enable();
        playerControls.Player.Jump.performed +=Jump;
    }
    private void OnDisable()
    {
        playerControls.Player.Disable();
    }
  

    private void Jump(InputAction.CallbackContext obj)
    {
    rb.linearVelocity=new Vector2(rb.linearVelocity.x,jumpForce); 
            
    }
    }
    
  
   
    

