using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFallController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    public GameObject mainGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DestroyMainGround());
    }


    public IEnumerator SetRigidbodyValues()
    {
        yield return new WaitForSeconds(0.75f);
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    IEnumerator DestroyMainGround()
    {
        yield return new WaitForSeconds(10f);
        Destroy(mainGround);
    }
}
