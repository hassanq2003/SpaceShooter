using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health=50;
    [SerializeField] int score=50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    

    void Awake()
    {
        cameraShake=Camera.main.GetComponent<CameraShake>();
        audioPlayer=FindObjectOfType<AudioPlayer>();
        scoreKeeper=FindAnyObjectByType<ScoreKeeper>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer=other.GetComponent<DamageDealer>();

        if(damageDealer!=null)
        {
            TakeDamage(damageDealer.getDamage());
            playHitEffect();
            audioPlayer.playDamageClip();
            shakeCamera();
            damageDealer.Hit();
        }
    }

    public int getHealth()
    {
        return health;
    }
    private void shakeCamera()
    {
        if(cameraShake!=null&&applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    public void TakeDamage(int damage)
    {
        health-=damage;
        if(health<=0)
        {
            Die();
        }

    }

    private void Die()
    {
    Debug.Log("Player has died."); // Add this line to check if Die() is called
    if(!isPlayer)
    {
        scoreKeeper.modifyScore(score);
    }
    if(isPlayer)
    {   
        
        ScoreStorer.Instance.StoreScore(scoreKeeper.getScore());

        
    }
    
    Destroy(gameObject);

    }

    void playHitEffect()
    {
        if(hitEffect!=null)
        {
            ParticleSystem instance=Instantiate(hitEffect,transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration+instance.main.startLifetime.constantMax);
        }
    }
}
