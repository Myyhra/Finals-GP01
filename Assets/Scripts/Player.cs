using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float playerBaseSpeed = 2.0f;
    public float playerSpeedMultiplier = 10.0f;
    public bool isDashing;
    public float dashTimer = 3.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * playerSpeed);

        if(isDashing ==true)
        {
            StartCoroutine(DashCountdown());
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    IEnumerator DashCountdown()
    {
        playerSpeed *= playerSpeedMultiplier;
        isDashing = false;
        yield return new WaitForSeconds(dashTimer);
        playerSpeed = playerBaseSpeed;
    }
}
