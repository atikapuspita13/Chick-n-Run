using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    
    // Movement parameter
    [SerializeField] private float moveTime;
    [SerializeField] private float moveDistance;

    private Vector3 startPos;
    private Vector3 newPos;
    private bool isMoving = false;
    private float elapsedTime = 0.0f;

    // Raycast parameter
    [SerializeField] private Transform raycastPos;
    [SerializeField] private LayerMask rigidObject;
    [SerializeField] private LayerMask movingPlatform;
    [SerializeField] private LayerMask waterPlatform;

    private float raycastDistance = 5;
    private bool objectBlockDirection = false;

    // Visual parameter
    [SerializeField] private Transform playerVisual;

    private float rotationDir;

    // ScoreCounter
    private float scorePos;
    private static int score;

    private void Awake()
    {
        // I made raycastDistance depends on moveDistance to make it 'game-designer's friendly' code
        raycastDistance = moveDistance * 140 / 100;

        // Just in case nilainya sedikit keubah karna pake rigidbody, jadinya aku lakukan pembulatan
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        transform.localRotation = Quaternion.Euler(Mathf.RoundToInt(transform.localRotation.x), Mathf.RoundToInt(transform.localRotation.y), Mathf.RoundToInt(transform.localRotation.z));
    }

    private void Start()
    {
        scorePos = 0;
        score = 0;
    }

    void Update()
    {
        HandleMovement();
        HandleScoreAddition();
    }

    private void HandleMovement()
    {
        if (!isMoving)
        {
            // Just in case nilainya sedikit keubah karna pake rigidbody, jadinya aku lakukan pembulatan


            // Move Input
            if (Input.GetKey(KeyCode.W))
            {
                rotationDir = 0;

                objectBlockDirection = Physics.Raycast(raycastPos.position, raycastPos.forward, raycastDistance, rigidObject);
                if (objectBlockDirection) return;

                startPos = transform.position;
                newPos = startPos + new Vector3(0, 0, moveDistance);
                elapsedTime = 0.0f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                rotationDir = 180;

                objectBlockDirection = Physics.Raycast(raycastPos.position, -raycastPos.forward, raycastDistance, rigidObject);
                if (objectBlockDirection) return;

                startPos = transform.position;
                newPos = startPos + new Vector3(0, 0, -moveDistance);
                elapsedTime = 0.0f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.A))
            {
                rotationDir = -90;

                objectBlockDirection = Physics.Raycast(raycastPos.position, -raycastPos.right, raycastDistance, rigidObject);
                if (objectBlockDirection) return;

                startPos = transform.position;
                newPos = startPos + new Vector3(-moveDistance, 0, 0);
                elapsedTime = 0.0f;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                rotationDir = 90;

                objectBlockDirection = Physics.Raycast(raycastPos.position, raycastPos.right, raycastDistance, rigidObject);
                if (objectBlockDirection) return;

                startPos = transform.position;
                newPos = startPos + new Vector3(moveDistance, 0, 0);
                elapsedTime = 0.0f;
                isMoving = true;
            }

            bool detectWater = Physics.Raycast(this.transform.position, -this.transform.up, raycastDistance, waterPlatform);
            if (detectWater)
            {
                bool detectPlatform = Physics.Raycast(this.transform.position, -this.transform.up, out RaycastHit hitObject, raycastDistance, movingPlatform);
                if (detectPlatform)
                {
                    transform.parent = hitObject.transform;
                }
                else
                {
                    print("DIE");
                    PlayerLife.instance.Die();
                    PlayerLife.instance.deathByDrown = true;
                }
            }
            else
            {
                transform.parent = null;
            }
        }


        // Move Execution
        if (isMoving)
        {
            print(rotationDir);
            playerVisual.localRotation = Quaternion.Euler(0, rotationDir, 0);
            print("Move");
            float t = Mathf.Clamp01(elapsedTime / moveTime);
            Vector3 newPosRounded = new Vector3(Mathf.Round(newPos.x / 5) * 5, newPos.y, newPos.z);
            transform.position = Vector3.Lerp(startPos, newPosRounded, t);
            elapsedTime += Time.deltaTime;
            if (t >= 1.0f)
            {
                //transform.position = new Vector3(Mathf.Round(transform.position.x / 5) * 5, Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
                isMoving = false;
            }
        }
        

    }

    private void HandleScoreAddition()
    {
        if (Mathf.Round(transform.position.z / 5) * 5 == scorePos)
        {
            score += 10;
            scorePos = Mathf.Round(transform.position.z / 5) * 5 + 5;
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public Transform GetRaycastPosition()
    {
        return raycastPos;
    }

    public float GetRaycastDistance()
    {
        return raycastDistance;
    }

    public int GetScore()
    {
        return score;
    }
}
