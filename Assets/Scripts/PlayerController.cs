using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float force;
    [SerializeField] GameObject focalPoint;
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
        //rb.AddTorque(verticalInput * force * Time.deltaTime * Vector3.right);
    }
}
