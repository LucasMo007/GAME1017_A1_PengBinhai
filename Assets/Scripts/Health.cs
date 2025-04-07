using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour

{

    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DanmageDealer damageDealer = other.gameObject.GetComponent<DanmageDealer>();
        if (damageDealer != null)


        {
            TakeDamage(damageDealer.GetDamage());
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
    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
         Destroy(gameObject);
    }
}
