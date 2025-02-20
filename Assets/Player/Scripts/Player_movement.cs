using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // �������� ��������
    public float gravitation = 1f;

    public Transform cameraAxis; // ������ �� ������ ������

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    private Rigidbody rb;

    private bool isOnStairs = false; // ���� ��� �������� ���������� �� ��������

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // ��������� �������� Rigidbody
    }

    private void Update()
    {
        GetInput(); // �������� ���� �� ������
        SpeedControl(); // �������� ��������
    }

    private void FixedUpdate()
    {
        MovePlayer(); // ������� ������
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // �������� ���� �� ��� X
        verticalInput = Input.GetAxisRaw("Vertical"); // �������� ���� �� ��� Z
    }

    private void MovePlayer()
    {
        moveDirection = cameraAxis.forward * verticalInput + cameraAxis.right * horizontalInput; // ������������ ����������� ��������

        if (isOnStairs)
        {
            rb.mass = gravitation - 0.5f; // ��������� ���������� �� ��������

            // ������������� �������� ������ �� ��������
            Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
            targetVelocity.y = verticalInput * moveSpeed; // ��������� ������������ ��������

            rb.velocity = new Vector3(targetVelocity.x, targetVelocity.y, targetVelocity.z);
        }
        else
        {
            rb.mass = gravitation; // ��������� ���������� �� ��������
            rb.AddForce(moveDirection.normalized * moveSpeed * 2f, ForceMode.Force); // ��������� ���� ��� ��������
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // �������� �������� ��� ����� ���������

        if (flatVel.magnitude > moveSpeed) // ���������, �� ��������� �� �������� ������������
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); // ������������ ��������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stairs")) // ��������� ��� "Stairs"
            isOnStairs = true; // ������������� ���� ���������� �� ��������
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stairs"))
            isOnStairs = false; // ���������� ���� ��� ������ � ��������
    }
}
