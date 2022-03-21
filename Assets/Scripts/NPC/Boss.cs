using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Vector3 directionVector;
    private Transform transform;

    private float speed;
    private Rigidbody2D rigidbody;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        directionVector = Vector3.left;
        
        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (rigidbody.bodyType != RigidbodyType2D.Static)
        {
            rigidbody.MovePosition(transform.position + directionVector * speed * Time.deltaTime);
        }
    }

    public void TriggerRunLeft()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("TriggerRun", true);
        speed = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("DisappearPoint")) {
            gameObject.SetActive(false);
        }
    }
}
