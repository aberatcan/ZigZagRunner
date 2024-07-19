using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private BallDataTransmitter ballDataTransmitter;
    [SerializeField] private float ballMoveSpeed;
    [SerializeField] private float fallBorderY = -3;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(UIElementsController.instance.UpdateScoreRoutine(ballMoveSpeed));
    }

    private void Update()
    {
        SetBallMovement();
        CheckBallIsFalling();
    }

    private void SetBallMovement()
    {
        transform.position += ballDataTransmitter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }

    private void CheckBallIsFalling()
    {
        float y = transform.position.y;

        if(y < fallBorderY)
        {
            UIElementsController.instance.isGameFinished = true;

            // Stop the ball
            rb.isKinematic = true;
            rb.useGravity = false;
            ballMoveSpeed = 0;
        }
    }
}
