using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class Klawiatura : MonoBehaviour
{
    private float gravity = -9.8f*2.5f;
    public float baseSpeed = 10.0f;
    public float speed;
    private CharacterController _charController;
    public float pushForce = 3.0f;
    

    public float jumpHeight = 5.0f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    private bool isGrounded = true;
    public Vector3 velocity;
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        speed = baseSpeed+(1*Managers.Player.SPEED_UPGRADES);
    }
    void Update()
    {
        speed = baseSpeed + (1 * Managers.Player.SPEED_UPGRADES);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * deltaX + transform.forward * deltaZ;
        _charController.Move(movement*speed*Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        _charController.Move(velocity *Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Wyłączanie aplikacji");
            Application.Quit();
        }
    }
    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

}
