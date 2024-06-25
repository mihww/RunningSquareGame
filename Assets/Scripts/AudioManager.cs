using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("---- Audio Source ----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

   [Header("---- Audio Clip ----")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip kill;





    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
        musicSource.volume = 0.4f;
        musicSource.playOnAwake = true;
    }



    public void PlaySFX (AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
