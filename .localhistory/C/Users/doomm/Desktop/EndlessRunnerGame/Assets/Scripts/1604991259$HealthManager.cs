using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    private List<Image> heartImages;

	// Use this for initialization
	void Start () {

        heartImages = new List<Image>();
		foreach (Transform child in transform)
        {
            heartImages.Add(child.gameObject.GetComponent<Image>());
        }

        Debug.Log(heartImages[0]);
        Debug.Log(heartImages[1]);

	}
	
    void LoseHeart(int index)
    {

    }
}
