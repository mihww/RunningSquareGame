using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangePlayerState(0, "r");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ChangePlayerState(1, "g");
        }
        else if (Input.GetKeyDown(KeyCode.E))
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
            
            other.GetComponent<Enemy>().Restart();
            Destroy(gameObject);
            Debug.Log("Playing failure clip");
            SceneManager.LoadScene(1);
            StartCoroutine(DelayedSceneLoad(1, audioManager.death.length)); // Assuming audioManager.death is an AudioClip
        }
    }


    IEnumerator DelayedSceneLoad(int sceneIndex, float delay)
    {
        audioManager.PlaySFX(audioManager.death); // Play the death sound
        yield return new WaitForSeconds(delay); // Wait for the length of the clip
        SceneManager.LoadScene(sceneIndex); // Load the game over scene
    }

}