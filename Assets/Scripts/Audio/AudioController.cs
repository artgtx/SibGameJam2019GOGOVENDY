using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
   public AudioMixer _mixer;
   public AudioSource audioSourse;
   public AudioSource effectSource;
   public AudioClip mainTheme;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSourse.clip = mainTheme;
        audioSourse.Play();
    }
    public void PlaySelectedMusic(AudioClip clipToPlay)
    {
        audioSourse.clip = clipToPlay;
        audioSourse.Play ();
    }

    public void PlaySelectedEffect(AudioClip clipToPlay)
    {
        effectSource.clip = clipToPlay;
        effectSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
