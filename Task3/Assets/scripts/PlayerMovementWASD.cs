using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovementWASD : MonoBehaviour
{

    public float speed = 15f;
    public float angularSpeed = 1000f;

    public float raycastDistance = 1.0f;
    public Color rayColor = Color.red;

    public float maxSlopeAngle = 60.0f;
    public float playerHeight = 2.0f;
    private RaycastHit slopeHit;
    private Vector3 moveDirection;
    public LayerMask slopeLayer;

    public Vector3 input;
    public bool isMoving;
    

    void Start()
    {
       
        Application.targetFrameRate = 90;
    }

    void Update()
    {
        movingChecker();


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        input = new Vector3(horizontal, 0f, vertical).normalized;



        if (input.magnitude > 0)
        {
            CheckGround();


            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0;
            moveDirection = Quaternion.LookRotation(cameraForward) * input;

            // to check for obstacles in front of the player
            RaycastHit hit;
            Vector3 raycastDirection = moveDirection.normalized;
            Debug.DrawRay(transform.position, raycastDirection * raycastDistance, rayColor);
            

            if (!Physics.Raycast(transform.position, raycastDirection, out hit, raycastDistance) && isMoving)
            {
                // move the player
                rb.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime * speed);

                // rotate the player
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Time.fixedDeltaTime);
            }
        }

        if (OnSlope() && isMoving)
        {
            moveDirection = GetSlopeMoveDir();
            rb.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime * speed); // move the player on the slope
        }
    }

    private void movingChecker()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    //slope check
    private bool OnSlope()  //* (playerHeight * 0.5f + 0.3f)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            Debug.DrawRay(transform.position, Vector3.down * 1f, Color.blue);

            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDir()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    private void CheckGround()
    {
        // raycast to check the ground
        RaycastHit groundHit;

        if (Physics.Raycast(transform.position, Vector3.down, out groundHit, Mathf.Infinity))
        {
            Debug.Log(groundHit.distance);

            // if not on the slope
            if (!OnSlope() && groundHit.collider.gameObject.layer != slopeLayer)
            {
                if (groundHit.distance > 1.01f)
                {
                    // Reset the position
                    Vector3 newPosition = transform.position;
                    newPosition.y = 1.13f;
                    transform.position = newPosition;
                }
            }
        }
    }

}

