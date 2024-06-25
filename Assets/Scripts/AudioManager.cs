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

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)   
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Destroy the new instance if one already exists
            return;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
        musicSource.volume = 0.4f;
        musicSource.playOnAwake = true;
    }



    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}
