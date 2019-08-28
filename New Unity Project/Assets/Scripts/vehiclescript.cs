using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehiclescript : MonoBehaviour
{
    //variablez
    private GameObject steeringThing;
    public float steeringSensitivity, accelerationForce, healthAmount = 100, emissionDiv = 10, damageThreshold = 5;
    public string otherTag;
    ParticleSystem ps;
    public GameObject clooone, smokeParticle;
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
        ps = GetComponent<ParticleSystem>();
        var emission = ps.emission;
        emission.rateOverTime = 0;
        if (gameObject.tag == "team1vehicle")
        {
            otherTag = "team2vehicle";
        }
        else
        {
            otherTag = "team1vehicle";
        }
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
        
        if (Input.GetKeyDown(hornKey))
        {
            mcSplode();
        }
        
    }


    void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "resetter")
        {
            transform.position = new Vector3(Random.Range(-2, 2), Random.Range(50, 60), Random.Range(-2, 2));
        }
       if(other.gameObject.tag == otherTag)
        {
            print("collision magnitude " + other.relativeVelocity.magnitude);
            if (other.relativeVelocity.magnitude > damageThreshold)
            {
                healthAmount = healthAmount - other.relativeVelocity.magnitude;
                ps = GetComponent<ParticleSystem>();
                var emission = ps.emission;
                emission.rateOverTime = (100 - healthAmount) / emissionDiv;
                foreach(ContactPoint contact in other.contacts)
                {
                    Instantiate(smokeParticle, contact.point, other.transform.rotation);
                }
                print("above threshold, damage applied");
            }
            else
            {
                print("below threshold");
            }
        }
    }

    void mcSplode()
    {
        GameObject newCar = Instantiate(clooone, new Vector3(Random.Range(-2, 2), Random.Range(50, 60), Random.Range(-2, 2)), transform.rotation);
        vehiclescript newCarScript = newCar.GetComponent<vehiclescript>();
        newCarScript.healthAmount = 100;
        Instantiate(debrisObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
