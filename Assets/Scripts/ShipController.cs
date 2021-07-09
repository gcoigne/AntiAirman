using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController: MonoBehaviour
{
    public GameObject ship;
    public GameObject shipEntry;
    public GameObject shipExit;
    public Ship shipScript;
    public Vector3 shipSpaceMin;
    public Vector3 shipSpaceMax;
    public float travelTime;
    public float downTime;
    public float minTravelDistance;
    float startTime;
    float endTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        ShipEnter();
        ship.transform.position = shipEntry.transform.position;
        ship.transform.rotation = shipEntry.transform.rotation;
        shipScript = ship.GetComponent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ship.activeSelf)
        {
            float dTime = Time.time - startTime;
            if (dTime < travelTime)
            {
                ship.transform.position = Vector3.Slerp(shipEntry.transform.position, shipExit.transform.position, dTime / travelTime);
                ship.transform.rotation = Quaternion.Slerp(shipEntry.transform.rotation, shipExit.transform.rotation, dTime / travelTime);
            }
            else
            {
                ShipExit();
                ship.SetActive(false);
            }
        }
        else
        {
            if(Time.time > startTime + travelTime)
            {
                ShipEnter();
                startTime += travelTime;
            }
        }
    }

    void ShipEnter()
    {
        ship.SetActive(true);
        shipEntry.SetActive(true);
        shipExit.SetActive(true);
        shipEntry.transform.position = RandomVector(shipSpaceMin, shipSpaceMax);
        shipExit.transform.position = shipEntry.transform.position;
        while(Vector3.Magnitude(shipExit.transform.position - shipEntry.transform.position) < minTravelDistance)
        {
            shipExit.transform.position = RandomVector(shipSpaceMin, shipSpaceMax);
        }
        shipEntry.transform.rotation = RandomQuaternion();
        shipExit.transform.rotation = RandomQuaternion();
        shipScript.shotTime = Time.time;
    }

    void ShipExit()
    {
        ship.SetActive(false);
        shipEntry.SetActive(true);
        shipExit.SetActive(true);
    }

    Vector3 RandomVector(Vector3 min, Vector3 max)
    {
        return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
    }

    Quaternion RandomQuaternion()
    {
        return Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
    }
}
