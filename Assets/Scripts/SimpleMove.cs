using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    CharacterController controller;
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public int rotationDeg;

    //MoveWhere
    public bool wantsLeft = true;
    bool hasPressedLeft = false;
    public bool wantsRight = true;
    bool hasPressedRight = false;
    bool isRotating = false;

    [SerializeField]float gridSize = 10f;
    float threshold = 0.15f;
    void Awake()
    {
        controller = GetComponent<CharacterController>();

    }
    void Update()
    {
        if (!isRotating)
        {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed;
        controller.SimpleMove(forward * curSpeed);
        }
        // Move forward / backward

        PlayerRotate();
    } 

    void PlayerRotate()
    {

        if(Input.GetKeyDown(KeyCode.RightArrow) && !isRotating && wantsRight && !hasPressedRight)
        {
            StartCoroutine("TurnRight");
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && !isRotating && wantsLeft && !hasPressedLeft)
        {
            StartCoroutine("TurnLeft");
        }
    }

     IEnumerator TurnRight()
    {
        hasPressedRight = true;
        wantsLeft = false;
        yield return new WaitUntil(() => IsOnGrid(transform.position.x, gridSize, threshold) && IsOnGrid(transform.position.z, gridSize, threshold));
        isRotating = true;
        yield return new WaitForSeconds(0.1f);
        rotationDeg += 90;
        transform.rotation = Quaternion.Euler(0, rotationDeg, 0);
        isRotating = false;
        wantsLeft = true;
        hasPressedRight = false;
    }
    IEnumerator TurnLeft()
    {
        hasPressedLeft = true;
        wantsRight = false;
        yield return new WaitUntil(() => IsOnGrid(transform.position.x, gridSize, threshold) && IsOnGrid(transform.position.z, gridSize, threshold));
        isRotating = true;
        yield return new WaitForSeconds(0.1f);
        rotationDeg -= 90;
        transform.rotation = Quaternion.Euler(0, rotationDeg, 0);
        isRotating = false;
        wantsRight = true;
        hasPressedLeft = false;
    }

    bool IsOnGrid(float position, float gridSize, float threshold)
    {
        float nearestGridPoint = Mathf.Round(position / gridSize) * gridSize;
        return Mathf.Abs(position - nearestGridPoint) <= threshold;
    }
    

}
