using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float moveDistance = 1.0f;
    public float moveTime = 1.0f;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float elapsedTime = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            startPosition = transform.position;
            endPosition = startPosition + new Vector3(moveDistance, 0, 0);
            isMoving = true;
            elapsedTime = 0.0f;
        }

        if (isMoving)
        {
            float t = Mathf.Clamp01(elapsedTime / moveTime);
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            elapsedTime += Time.deltaTime;
            if (t >= 1.0f)
            {
                isMoving = false;
            }
        }
    }
}
