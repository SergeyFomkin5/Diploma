using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Скорость движения
    public float gravitation = 1f;

    public Transform cameraAxis; // Ссылка на объект камеры

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    private Rigidbody rb;

    private bool isOnStairs = false; // Флаг для проверки нахождения на лестнице

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Отключаем вращение Rigidbody
    }

    private void Update()
    {
        GetInput(); // Получаем ввод от игрока
        SpeedControl(); // Контроль скорости
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Двигаем игрока
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Получаем ввод по оси X
        verticalInput = Input.GetAxisRaw("Vertical"); // Получаем ввод по оси Z
    }

    private void MovePlayer()
    {
        moveDirection = cameraAxis.forward * verticalInput + cameraAxis.right * horizontalInput; // Рассчитываем направление движения

        if (isOnStairs)
        {
            rb.mass = gravitation - 0.5f; // Отключаем гравитацию на лестнице

            // Устанавливаем скорость игрока на лестнице
            Vector3 targetVelocity = moveDirection.normalized * moveSpeed;
            targetVelocity.y = verticalInput * moveSpeed; // Учитываем вертикальное движение

            rb.velocity = new Vector3(targetVelocity.x, targetVelocity.y, targetVelocity.z);
        }
        else
        {
            rb.mass = gravitation; // Отключаем гравитацию на лестнице
            rb.AddForce(moveDirection.normalized * moveSpeed * 2f, ForceMode.Force); // Применяем силу для движения
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Получаем скорость без учета вертикали

        if (flatVel.magnitude > moveSpeed) // Проверяем, не превышает ли скорость максимальную
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); // Ограничиваем скорость
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stairs")) // Проверяем тег "Stairs"
            isOnStairs = true; // Устанавливаем флаг нахождения на лестнице
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stairs"))
            isOnStairs = false; // Сбрасываем флаг при выходе с лестницы
    }
}
