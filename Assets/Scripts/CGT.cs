using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGT : MonoBehaviour
{ 
   public float moveSpeed = 5f;
    public float gridSize = 1f;
    public float threshold = 0.1f; // Threshold for determining if the player has reached the target position

    private CharacterController characterController;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            // Get the input
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            // Calculate the target position based on input
            if (horizontal != 0)
            {
                targetPosition += new Vector3(horizontal * gridSize, 0, 0);
                isMoving = true;
            }
            else if (vertical != 0)
            {
                targetPosition += new Vector3(0, 0, vertical * gridSize);
                isMoving = true;
            }
        }
        else
        {
            // Move the player towards the target position
            Vector3 direction = (targetPosition - transform.position).normalized;
            Vector3 move = direction * moveSpeed * Time.deltaTime;
            
            // Ensure the player does not overshoot the target position
            if (move.magnitude > Vector3.Distance(transform.position, targetPosition))
            {
                move = targetPosition - transform.position;
            }

            characterController.Move(move);

            // Check if the player has reached the target position within the threshold
            if (Vector3.Distance(transform.position, targetPosition) < threshold)
            {
                transform.position = targetPosition; // Snap to the target position
                isMoving = false;
            }
        }
    }
}
