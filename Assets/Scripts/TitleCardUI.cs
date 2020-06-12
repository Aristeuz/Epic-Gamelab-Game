using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//picture fade in, and fade out.

public class TitleCardUI : MonoBehaviour
{
    public Image titleCard;
    public GameObject playerCollider;
    public float fadeTime = 2;
    public float showTimeSeconds = 2;

    // Start is called before the first frame update
    void Start()
    {
        //Make title card invisible from the start.
        titleCard.canvasRenderer.SetAlpha(0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FadeImg());
        }
    }

    IEnumerator FadeImg()
    {
        //Fade in
        titleCard.CrossFadeAlpha(1, fadeTime, false);
        yield return new WaitForSeconds(fadeTime);
        //Wait a few secdons
        yield return new WaitForSeconds(showTimeSeconds);
        //fade out
        titleCard.CrossFadeAlpha(0, fadeTime, false);
    }
}
