using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBG : MonoBehaviour
{
    private AudioSource src;
    public AudioClip bgm;


    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        src.clip = bgm;
        src.loop = true;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (src.isPlaying)
                src.Pause();

            else

                src.UnPause();


        }
    }
}
