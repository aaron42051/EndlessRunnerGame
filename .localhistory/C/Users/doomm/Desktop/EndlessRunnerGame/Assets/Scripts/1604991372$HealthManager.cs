using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    private List<Image> heartImages;

    public Image fullHeart;
    public Image halfHeart;
    public Image emptyHeart;

	// Use this for initialization
	void Start () {

        heartImages = new List<Image>();
		foreach (Transform child in transform)
        {
            heartImages.Add(child.gameObject.GetComponent<Image>());
        }

	}
	
    void LoseHeart(int index)
    {

    }
}
