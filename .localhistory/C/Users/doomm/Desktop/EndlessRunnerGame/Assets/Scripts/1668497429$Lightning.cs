using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {

    public float speed;
    private bool didHit = false;
    private Animator myAnimator;
    private AudioSource lazerSound;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        lazerSound = GameObject.Find("Lazer Sound").GetComponent<AudioSource>();
    }

    // move straight down until collision
    void Update () {

        if (!didHit)
        {
            transform.position -= new Vector3(0, speed, 0);
        }
    }

    // on collision, play the animation then disappear
    public IEnumerator OnHit()
    {

        if (!lazerSound.isPlaying)
        {
            lazerSound.Play();
        }

        setDidHit(true);

        myAnimator.SetBool("didHit", true);

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }

    public void setDidHit(bool hit)
    {
        didHit = hit;
    }

}
