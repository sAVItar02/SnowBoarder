using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Invoke("ReloadScene", levelLoadDelay);
            GetComponent<AudioSource>().Play();
            finishEffect.Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
