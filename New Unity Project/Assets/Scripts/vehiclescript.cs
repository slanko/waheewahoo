using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehiclescript : MonoBehaviour
{
    //variablez
    public float accelerationForce;
    public float steeringSensitivity;
    private GameObject steeringThing;
    public float healthAmount;
    //inputz
    public KeyCode mvForward, mvBack, mvLeft, mvRight;
    public KeyCode hornKey;
    //other guff
    Rigidbody rb;
    Rigidbody strb;
    public GameObject debrisObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        steeringThing = GameObject.Find(transform.name + "/steeringpoint");
        strb = steeringThing.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(mvForward))
        {
            rb.AddForce(transform.forward * accelerationForce, ForceMode.Acceleration);
        }
        if (Input.GetKey(mvBack))
        {
            rb.AddForce(transform.forward * accelerationForce * -1, ForceMode.Acceleration);
        }
        if (Input.GetKey(mvLeft))
        {
            strb.AddForce(transform.right * steeringSensitivity * -1);
        }
        if (Input.GetKey(mvRight))
        {
            strb.AddForce(transform.right * steeringSensitivity);
        }
        if (Input.GetKey(hornKey))
        {
            mcSplode();
        }
    }

    void mcSplode()
    {
        Instantiate(debrisObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
