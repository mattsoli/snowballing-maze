using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlateController : MonoBehaviour
{
    public float decrementSize = 0.01f;

    private Vector3 decrementer;
    // Start is called before the first frame update
    void Start()
    {
        this.decrementer = new Vector3(this.decrementSize, this.decrementSize, this.decrementSize);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // check to doesn't make PlayerBall's scale negative
            if (other.gameObject.transform.localScale.x > this.decrementSize || other.gameObject.transform.localScale.x == this.decrementSize)
            {
                other.gameObject.transform.localScale -= this.decrementer;
            } else {
                other.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
            }
        }
    }
}
