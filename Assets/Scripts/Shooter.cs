using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float health;
    public float healthRegen;
    public float explosionDamage;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        health += healthRegen * Time.deltaTime;
        health = Mathf.Clamp01(health);
    }

    private void OnTriggerStay(Collider other)
    {
        health -= explosionDamage * Time.fixedDeltaTime;
    }
}
