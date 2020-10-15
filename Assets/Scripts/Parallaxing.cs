using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public GameObject background;
    private Transform[] layers;
    private float[] parallaxScales;
    public float smoothing;

    private Vector3 prevPosition;

    private void Start()
    {
        prevPosition = transform.position;

        layers = GetComponentsInChildren<Transform>();
        parallaxScales = new float[layers.Length];
        for (int i = 0; i < parallaxScales.Length; i++)
        {
            parallaxScales[i] = layers[i].position.z * -1;
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            Vector3 parallax = (prevPosition - transform.position) * (parallaxScales[i] / smoothing);

            layers[i].position = new Vector3(layers[i].position.x + parallax.x, layers[i].position.y + parallax.y, layers[i].position.z);
        }

        prevPosition = transform.position;
    }
}
