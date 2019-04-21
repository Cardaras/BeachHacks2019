using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusomCharacterController : MonoBehaviour
{

    public float Scalar = 1f;
    public float StrafingSpeed = 0.001f;
    public float JumpHeight = 2f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float x_force = 0;
        float y_force = 0;
        float z_force = 0;

        x_force = Input.GetAxis("Horizontal");
        z_force = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x_force, y_force, z_force) * StrafingSpeed;

        if (x_force != 0 || y_force != 0 || z_force != 0)
        {
            Debug.Log(movement);
        }

        Vector3 position = new Vector3(this.transform.position.x + movement.x, 
            this.transform.position.y + movement.y, 
            this.transform.position.z + movement.z);

        this.transform.position = Vector3.Lerp(this.transform.position, position, Time.deltaTime * Scalar);
        //rb.MovePosition(transform.position + movement * Time.deltaTime * Scalar);
        //rb.AddForce(movement * Time.deltaTime * Scalar);
    }
}
