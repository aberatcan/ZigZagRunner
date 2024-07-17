using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPositionController : MonoBehaviour
{
    private GroundSpawnController groudSpawnController;

    private Rigidbody rb;

    [SerializeField] private float endYValue;

    private int groundDirection;

    // Start is called before the first frame update
    void Start()
    {
        groudSpawnController = FindObjectOfType<GroundSpawnController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGroundVerticalPosition();
    }

    private void CheckGroundVerticalPosition()
    {
        if (transform.position.y <= endYValue)
        {

            SetRigidBodyValues();

            SetNewGroundPosition();

        }
    }

    private void SetNewGroundPosition()
    {
        groundDirection = Random.Range(0, 2);

        if (groundDirection == 0)
        {
            transform.position = new Vector3(
                groudSpawnController.lastGroundObject.transform.position.x - 1f,
                groudSpawnController.lastGroundObject.transform.position.y,
                groudSpawnController.lastGroundObject.transform.position.z
                );
        }
        else
        {
            transform.position = new Vector3(
                groudSpawnController.lastGroundObject.transform.position.x,
                groudSpawnController.lastGroundObject.transform.position.y,
                groudSpawnController.lastGroundObject.transform.position.z + 1f
                );
        }

        groudSpawnController.lastGroundObject = gameObject;
    }

    private void SetRigidBodyValues()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}
