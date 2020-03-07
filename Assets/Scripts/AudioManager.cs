using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update

    private static AudioManager instance;

    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
           s.SetupSource(gameObject.AddComponent<AudioSource>());
        }
       
    }

    // Update is called once per frame
    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
            s.Play();
    }
}
