using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    private List<Image> heartImages;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

	// Use this for initialization
	void Start () {

        heartImages = new List<Image>();
		foreach (Transform child in transform)
        {
            heartImages.Add(child.gameObject.GetComponent<Image>());
        }

	}
	
    public void LoseHeart(int index)
    {
        heartImages[index].sprite = emptyHeart;
    }

    public void GainHeart(int index)
    {
        heartImages[index].sprite = fullHeart;
    }

    public void ResetHearts()
    {
        foreach (Image heart in heartImages)
        {
            heart.sprite = fullHeart;
        }
    }
}
