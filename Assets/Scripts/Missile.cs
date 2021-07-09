using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject explosion;
    public float lifetime;
    public bool remoteDet;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= lifetime)
        {
            Explode();
        }
        else if(remoteDet && Input.GetMouseButton(1))
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
        Explode();
    }

    private void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
