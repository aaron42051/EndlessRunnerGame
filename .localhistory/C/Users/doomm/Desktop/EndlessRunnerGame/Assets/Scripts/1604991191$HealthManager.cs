using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    private List<SpriteRenderer> heartRenderers;

	// Use this for initialization
	void Start () {

        heartRenderers = new List<SpriteRenderer>();
		foreach (Transform child in transform)
        {
            heartRenderers.Add(child.gameObject.GetComponent<SpriteRenderer>());
        }

	}
	
    void LoseHeart(int index)
    {

    }
}
