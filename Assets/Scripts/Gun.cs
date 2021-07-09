using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzlePoint;
    public GameObject missilePrefab;
    public float shootForce;
    public float cooldown;

    float shotTime;
    // Start is called before the first frame update
    void Start()
    {
        shotTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(Time.time - shotTime >= cooldown)
            {
                Shoot();
                shotTime = Time.time;
                GameObject missile = Instantiate(missilePrefab, muzzlePoint.position, muzzlePoint.rotation);
                missile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * shootForce);
                missile.GetComponent<Missile>().remoteDet = true;
            }
        }
    }

    public void Shoot()
    {

    }
}
