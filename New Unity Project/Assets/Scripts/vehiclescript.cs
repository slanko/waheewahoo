using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehiclescript : MonoBehaviour
{
    //variablez
    private GameObject steeringThing;
    public float steeringSensitivity, accelerationForce, healthAmount = 100, emissionDiv = 10;
    public string otherTag;
    ParticleSystem ps;
    public GameObject clooone;
    //inputz
    public KeyCode mvForward, mvBack, mvLeft, mvRight, hornKey;
    //other guff
    Rigidbody rb, strb;
    public GameObject debrisObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        steeringThing = GameObject.Find(transform.name + "/steeringpoint");
        strb = steeringThing.GetComponent<Rigidbody>();
        if(gameObject.tag == "team1vehicle")
        {
            otherTag = "team2vehicle";
        }
        else
        {
            otherTag = "team1vehicle";
        }
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        if(healthAmount <= 0)
        {
            mcSplode();
        }
        /*
        if (Input.GetKey(hornKey))
        {
            mcSplode();
        }
        */
    }


    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "resetter")
        {
            transform.position = new Vector3(0, 50, 0);
        }
       if(other.gameObject.tag == otherTag)
        {
            healthAmount = healthAmount - other.relativeVelocity.magnitude;
            var emission = ps.emission;
            emission.rateOverTime = (100 - healthAmount) / emissionDiv;
        }
    }

    void mcSplode()
    {
        Instantiate(clooone, new Vector3(0, 50, 0), transform.rotation);
        Instantiate(debrisObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
