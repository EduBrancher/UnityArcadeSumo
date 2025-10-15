using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] float force;
    PlayerController player;
    Rigidbody rb;
    SphereCollider sphereCollider;
    bool isGrounded;

    float minHeight = -30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded) {
            if (transform.position.y < minHeight) {
                Destroy(gameObject);
            }
            return;
        }
        var vecToPlayer = player.transform.position - transform.position;
        rb.AddForce(force * Time.deltaTime * vecToPlayer.normalized);
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
