using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float force;
    [SerializeField] float pushForce;
    [SerializeField] GameObject focalPoint;
    [SerializeField] GameObject powerUpIndicator;
    [SerializeField] float powerUpDuration;
    float powerUpTimer = 0;
    bool powerUpActive = false;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(verticalInput * force * Time.deltaTime * focalPoint.transform.forward);
        powerUpTimer -= Time.deltaTime;
        if (powerUpTimer <= 0) {
            powerUpActive = false;
            powerUpIndicator.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Enemy":
                if (powerUpActive) {
                    other.gameObject.GetComponent<Rigidbody>().AddForce(
                        pushForce * (other.transform.position - transform.position));
                }
                break;
            case "PowerUp":
                powerUpIndicator.SetActive(true);
                powerUpActive = true;
                powerUpTimer = powerUpDuration;
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
    }
}
