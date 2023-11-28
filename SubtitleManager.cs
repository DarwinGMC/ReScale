using UnityEngine;
using TMPro;

[System.Serializable]
public class Subtitle
{
    public float timestamp;
    public string text;
}

public class SubtitleManager : MonoBehaviour
{
    public AudioClip audioClip;  // Add your audio clip in the Unity Editor
    public Subtitle[] subtitles;  // Add your subtitles and timestamps in the Unity Editor
    public TextMeshProUGUI subtitleText;

    private AudioSource audioSource;
    private int currentSubtitleIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        subtitleText.text = "";
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            // Check if there are more subtitles
            if (currentSubtitleIndex < subtitles.Length)
            {
                // Display the next subtitle at the specified timestamp
                float currentTime = audioSource.time;
                if (currentTime >= subtitles[currentSubtitleIndex].timestamp)
                {
                    subtitleText.text = subtitles[currentSubtitleIndex].text;
                    currentSubtitleIndex++;
                }
            }
            else
            {
                // All subtitles have been displayed
                subtitleText.text = "";
            }
        }
    }

    void PlayAudio()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
