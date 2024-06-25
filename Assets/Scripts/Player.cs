using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{

    private SpriteRenderer rend;
    private Animator anim;

    public Color[] colors;
    public string playerColor;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChangePlayerState(0, "r");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            ChangePlayerState(1, "g");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePlayerState(2, "b");
        }
    }

    private void ChangePlayerState(int colorIndex, string colorName)
    {
        anim.SetTrigger("change");
        rend.color = colors[colorIndex];
        playerColor = colorName;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called");
        if (other.GetComponent<Enemy>().enemyColor == playerColor)
        {
            Score.scoreValue++;
            audioManager.PlaySFX(audioManager.kill);
            other.GetComponent<Enemy>().Destruction();
            Debug.Log("Playing success clip");
        }
        else
        {
            audioManager.PlaySFX(audioManager.death);
            other.GetComponent<Enemy>().Restart();
            Destroy(gameObject);
            Debug.Log("Playing failure clip");
        }
    }
}