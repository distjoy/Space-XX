
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound 
{

    public string name;

    public AudioClip clip;
    
    [Range(0.1f,3f)]
    public float pitch;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    private AudioSource source;

    public void SetupSource(AudioSource source)
    {
        this.source = source;
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;
        source.pitch = pitch;
    }

    public void Play()
    {
        source.Play();
    }
}
