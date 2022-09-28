using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player Movement
    public PlayerAction playerAction;
    Vector2 move;
    Vector2 rotate;
    private float walkSpeed = 5f;
    public Camera playerCamera;
    Vector3 cameraRotation;

    // Player Jump
    Rigidbody rb;
    private float distanceFromGround;
    private bool isGrounded = true;
    public float jump = 5f;

    // Player Animation
    Animator playerAnimator;
    private bool isWalking = false;

    // Projectile Bullets
    public GameObject bullet;
    public Transform projectilePosition;

    private void OnEnable()
    {
        playerAction.Enable();
    }

    private void OnDisable()
    {
        playerAction.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        playerAction = new PlayerAction();
        playerAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        playerAction.Player.Move.canceled += cntxt => move = Vector2.zero;
        playerAction.Player.Jump.performed += cntxt => Jump();
        playerAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceFromGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }

    public void Shoot()
    {
        Rigidbody bulletRB = Instantiate(bullet, projectilePosition.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRB.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRB.AddForce(transform.up, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceFromGround + 2f);
    }
}
