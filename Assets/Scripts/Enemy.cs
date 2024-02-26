using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosinVFX;
    [SerializeField] Transform parent;
    [SerializeField] int amountIncreaseScore;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        KillEnemy();
        ProcessHit();

    }

    void KillEnemy()
    {
        Destroy(gameObject);
        GameObject vfx = Instantiate(enemyExplosinVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
    }

    void ProcessHit()
    {
        scoreBoard.IncreaseScore(amountIncreaseScore);
    }
}
