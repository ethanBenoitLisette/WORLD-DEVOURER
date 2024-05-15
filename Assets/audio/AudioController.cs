using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(0.1f, 2.5f)]
    public float pitch = 1f;

    private AudioSource source;

    void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = true;
    }

    void Start()
    {
        if (source.clip != null)
        {
            source.Play();
        }
        else
        {
            Debug.LogWarning("No audio clip assigned to AudioController on " + gameObject.name);
        }
    }

    void Update()
    {
        // Update the audio source parameters in case they are changed in the inspector during runtime
        source.volume = volume;
        source.pitch = pitch;
    }
}
