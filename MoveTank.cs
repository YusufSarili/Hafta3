using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    public GameObject[] wheelsLeft;
    public GameObject[] wheelsRight;

    public float wheelRotationSpeed = 200.0f;

    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        RotateWheels(moveInput, rotationInput);
    }

    private void FixedUpdate()
    {
        MoveTank(moveInput);
        RotateTank(rotationInput);
    }

    void MoveTank(float input)
    {
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }

    void RotateTank(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void RotateWheels(float moveInput, float rotationInput)
    {
        float WheelRotation = moveInput * wheelRotationSpeed * Time.deltaTime;


        foreach (GameObject wheel in wheelsLeft)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(WheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }

        foreach (GameObject wheel in wheelsRight)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(WheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }
}
