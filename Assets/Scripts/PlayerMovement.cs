using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    private Vector3 playerVelocity;

    public float Speed = 10.0f;
    float jumpHeight = 1.0f;
    float gravity = -9.81f;

    bool grounded;

    bool wantsRight = false;
    bool wantsLeft = false;
    bool isGoingRight;
    bool isGoingLeft;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            wantsRight = true;
            
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            wantsLeft = true;
            
        }

        

        characterController.Move(new Vector3(0,0,1) * Time.deltaTime * Speed);
        
    }
}
