using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosinFX;
    [SerializeField] GameObject enemyHitExplosionVFX;

    [SerializeField] int amountIncreaseScore;
    [SerializeField] int hp = 3;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;



    void Start()
    {
        parentGameObject = GameObject.FindWithTag("Spawn At Runtime");
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {


        ProcessHit();
        if(hp < 1)
        {

            KillEnemy();
        }
    }

    void KillEnemy()
    {
        scoreBoard.IncreaseScore(amountIncreaseScore);

        GameObject vfx = Instantiate(enemyExplosinFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform; 
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hp--;

        GameObject vfx = Instantiate(enemyHitExplosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
}
