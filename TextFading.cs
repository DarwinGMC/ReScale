using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFading : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rareText;
    [SerializeField] PhysicsPickup physicsPickup;
    public float fadeDuration = 2.0f; // Duration of the fade effect in seconds

    private float fadeTimer = 0.0f;
    private Color originalColor; // Store the original color here
    private bool isFadingOut = false; // Indicates if the text is currently fading out

    void Start()
    {
        originalColor = rareText.color;
    }

    void Update()
    {
        if (physicsPickup.isFading && !isFadingOut)
        {
            if (fadeTimer < fadeDuration)
            {
                fadeTimer += Time.deltaTime;

                float newAlpha = Mathf.Lerp(1.0f, 0.0f, fadeTimer / fadeDuration);

                Color newTextColor = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);

                rareText.color = newTextColor;
            }
            else
            {
                isFadingOut = true;
                rareText.gameObject.SetActive(false);
                rareText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1.0f);
                fadeTimer = 0.0f; // Reset the fadeTimer
                physicsPickup.isFading = false;
            }
        }
        else if (!physicsPickup.isFading)
        {
            isFadingOut = false;
            fadeDuration = 2.0f;
        }
    }
}
