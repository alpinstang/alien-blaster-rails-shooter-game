using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int scorePerHit = 225;
    {SerializeField] int healthPoints = 100;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        healthPoints -= 50;
        scoreBoard.ScoreHit(scorePerHit);

        if (healthPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
        deathFX.SetActive(true);
        Destroy(gameObject);
    }
}
