using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            if(!hasCrashed)
            {
                hasCrashed = true;
                FindObjectOfType<PlayerController>().DisableControls();
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Invoke("ReloadScene", levelLoadDelay);
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
