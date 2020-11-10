using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {

    private float length, startPosition;
    public GameObject camera;
    public float parallaxEffect;

	void Start () {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
	}
	
	void Update () {
        float distanceFromCamera = camera.transform.position.x * (1 - parallaxEffect);
        float dist = camera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if (distanceFromCamera > startPosition + length - 10)
        {
            startPosition += length;
        }
        else if (distanceFromCamera < startPosition - length)
        {
            startPosition -= length;
        }
	}
}
