using UnityEngine;

public class SimpleRotator : MonoBehaviour {

    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 axis;
    
    void Update()
    {
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }
}
