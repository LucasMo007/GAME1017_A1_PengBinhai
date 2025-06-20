using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour

{

    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] GameObject healthPickupPrefab; // Assign via Inspector


    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    [SerializeField] int score = 50;
    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DanmageDealer damageDealer = other.gameObject.GetComponent<DanmageDealer>();
        if (damageDealer != null)


        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
            audioPlayer.PlayDamageClip();
            

        }
    }
         public int GetHealth()
        {  return health; }
    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    /*void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {

            levelManager.LoadGameOver();
        }
         Destroy(gameObject);
    }*/
    void Die()
    {
        if (!isPlayer)
        {
            // 10–20% drop chance
            float dropChance = Random.Range(0f, 1f);
            if (dropChance < 0.15f) // e.g., 15% chance
            {
                Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);
            }

            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }

        Destroy(gameObject);
    }
    void PlayHitEffect()
    {
        if (hitEffect != null) 
        {ParticleSystem instance  =  Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
        } 
    
    }
    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }



    }
    public void Heal(int amount)
    {
        health += amount;
        // Optionally clamp to a max health value
        health = Mathf.Min(health, 100); // change 100 to your max value
    }
}
