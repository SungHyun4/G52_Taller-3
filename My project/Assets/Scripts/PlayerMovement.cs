using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    [Header("Física")]
    public float gravity = -9.81f;
    public float fallYLimit = 0f; // Altura a la que se considera una caída

    [Header("Referencia de cámara")]
    public Camera mouseOrbitCamera;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform currentCheckpoint; // Último checkpoint activado

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MoveAndRotate();
        ApplyGravity();
        CheckFall();
    }

    private void MoveAndRotate()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        float vertical = 0f;
        float horizontal = 0f;

        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
            vertical = 1f;
        else if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
            vertical = -1f;

        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            horizontal = -1f;
        else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            horizontal = 1f;

        Vector3 moveDirection = Vector3.zero;

        // Movimiento según cámara o personaje
        if (mouseOrbitCamera != null && mouseOrbitCamera.gameObject.activeSelf)
        {
            Vector3 forward = mouseOrbitCamera.transform.forward;
            forward.y = 0;
            forward.Normalize();
            moveDirection = forward * vertical;
        }
        else
        {
            moveDirection = transform.forward * vertical;

            if (horizontal != 0)
            {
                float rotation = horizontal * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, rotation, 0);
            }
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    // ======================
    //  DETECCIÓN DE CAÍDA
    // ======================
    private void CheckFall()
    {
        if (transform.position.y < fallYLimit)
        {
            RespawnAtCheckpoint();
        }
    }

    // ==========================
    //  CHECKPOINT / RESPAWN
    // ==========================
    public void SetCheckpoint(Transform newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }

    private void RespawnAtCheckpoint()
    {
        controller.enabled = false;

        Vector3 respawnPos = currentCheckpoint != null
            ? currentCheckpoint.position + Vector3.up * 1f
            : new Vector3(0, 2f, 0); // Si no hay checkpoint, reaparece en el inicio

        transform.position = respawnPos;
        velocity = Vector3.zero;

        controller.enabled = true;

        if (GameManager.Instance != null)
            GameManager.Instance.AddFall();
    }
}
