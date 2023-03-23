using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulldozeController : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.body.velocity = Vector3.back * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snow"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
