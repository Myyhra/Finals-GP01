using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SimpleMove : MonoBehaviour
{
    CharacterController controller;
    public double speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public int rotationDeg;

    //MoveWhere
    public bool wantsLeft = true;
    bool hasPressedLeft = false;
    public bool wantsRight = true;
    bool hasPressedRight = false;
    bool isRotating = false;

    [SerializeField]float gridSize = 10f;
    float threshold = 0.1f;

    [SerializeField] GameManager gameManager;
    public float maxOrbCount;
    public double speedRatio;
    void Awake()
    {
        controller = GetComponent<CharacterController>();

    }
    void Start()
    {
        maxOrbCount = gameManager.OrbCount;
    }
    void Update()
    {
        if (!isRotating)
        {
        // Vector3 forward = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(transform.forward * (float)speed);
        }

        
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

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
    void SnapToGrid()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Round(position.x / gridSize) * gridSize;
        position.z = Mathf.Round(position.z / gridSize) * gridSize;
        transform.position = position;
    }


    void OnTriggerEnter(Collider hit)
    {
        if(hit.CompareTag("Orbs") ||hit.CompareTag("SpecialOrbs") || hit.CompareTag("SpecialChildOrbs") )
        {
          speed +=  0.05;

          Debug.Log("Speed up");
        }
    }
    

}
