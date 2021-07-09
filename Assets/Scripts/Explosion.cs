using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip bang;
    public float lifetime;
    public float minScale;
    public float maxScale;
    AudioSource audio;
    float startTime;
    float startVolume;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startTime = Time.time;
        startVolume = audio.volume;
        transform.localScale = new Vector3(minScale, minScale, minScale);
        audio.clip = bang;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float dTime = Time.time - startTime;
        if (dTime < lifetime)
        {
            float lerpScale = Mathf.Lerp(minScale, maxScale, dTime / lifetime);
            transform.localScale = new Vector3(lerpScale, lerpScale, lerpScale);
            audio.volume = startVolume * (1 - dTime / lifetime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
