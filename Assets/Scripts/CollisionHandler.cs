using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", 5f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }
}
