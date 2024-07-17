using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInputController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 ballDirection;

    // Start is called before the first frame update
    void Start()
    {
        ballDirection = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeBallDirection();
        }
    }

    private void ChangeBallDirection()
    {
        if (ballDirection.x == -1)
        {
            ballDirection = Vector3.forward;
        }
        else
        {
            ballDirection = Vector3.left;
        }
    }
}
