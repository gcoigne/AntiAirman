using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject missile;
    public GameObject target;
    public float shotForce;
    public float shotCooldown;
    public float shotOffsetMag;
    public float shotTime;
    public int hitCount;

    void Start()
    {
        shotTime = 0;
        hitCount = 0;
    }

    void Update()
    {
        if(Time.time - shotTime > shotCooldown)
        {
            Shoot();
            shotTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        hitCount++;
    }

    void Shoot()
    {
        Vector3 targetOffset = target.transform.position - transform.position;
        Vector3 shotPosition = transform.position + (targetOffset).normalized * shotOffsetMag;
        Quaternion shotRotation = Quaternion.LookRotation(targetOffset);
        GameObject newMissile = Instantiate(missile, shotPosition, shotRotation);
        Rigidbody missileRB;
        if(missileRB = newMissile.GetComponent<Rigidbody>())
        {
            missileRB.AddForce(targetOffset.normalized * shotForce);
        }
    }
}
