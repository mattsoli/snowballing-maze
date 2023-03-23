using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float incrementSize = 0.01f;
    public float maxSize;
    public bool hasArrived = false;
    public bool isDead = false;
    public int score = 0;

    private Rigidbody body;
    private float movementX;
    private float movementY;
    private Vector3 incrementer;

    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody>();
        this.incrementer = new Vector3(this.incrementSize, this.incrementSize, this.incrementSize);
    }

    void Update()
    {
        if (this.body.transform.localScale.x < (this.maxSize / 2))
        {
            this.score = 1;
        }
        else if (this.body.transform.localScale.x > (this.maxSize / 2) && this.body.transform.localScale.x < this.maxSize)
        {
            this.score = 2;
        }
        else
        {
            this.score = 3;
        }
    }

    private void FixedUpdate()
    {
        // Movement
        Vector3 movement = new Vector3(this.movementX, 0.0f, this.movementY);
        this.body.AddForce(movement * this.speed);

        if (transform.localScale == Vector3.zero)
        {
            this.isDead = true;
        }
    }

    // Class methods

    private void OnMove(InputValue movementValue)
    {
        Vector2 vector = movementValue.Get<Vector2>();

        this.movementX = vector.x;
        this.movementY = vector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Snow")) // Trigger with snow
        {
            if (this.body.transform.localScale.x < this.maxSize)
            {
                // Snow being absorbed
                other.gameObject.SetActive(false);

                // Snow Ball increments its size
                transform.localScale += this.incrementer;
            }
        }

        if (other.gameObject.CompareTag("FinishLine"))
        {
            this.hasArrived = true;
        }

        if (other.gameObject.CompareTag("FallCollider"))
        {
            this.isDead = true;
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.isDead = true;
        }
    }
}
