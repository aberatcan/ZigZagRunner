using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFallController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    public IEnumerator SetRigidbodyValues()
    {
        yield return new WaitForSeconds(0.75f);
        rb.isKinematic = false;
        rb.useGravity = true;

    }
}
