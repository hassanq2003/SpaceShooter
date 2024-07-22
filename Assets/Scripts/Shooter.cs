using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float baseFiringRate = 0.2f;
    [Header("AI")]
    [SerializeField]private float firingRateVariance=0f;
    [SerializeField]private float minimumFiringRate=0.1f;
    [SerializeField] bool UseAi;

    [HideInInspector]public bool isFiring;


    private Coroutine firingCoroutine;

    AudioPlayer audioPlayer;


    void Awake()
    {
        audioPlayer=FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(UseAi)
        {
            isFiring=true;
        }

    }
    void Update()
    {
        HandleFiring();
    }

    void HandleFiring()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Destroy(instance, projectileLifetime);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if(UseAi)rb.velocity = transform.up * -projectileSpeed;
                else rb.velocity = transform.up * projectileSpeed;
                
            }
            float timeToNextProjectile=Random.Range(baseFiringRate-firingRateVariance,baseFiringRate+firingRateVariance);
            timeToNextProjectile=Mathf.Clamp(timeToNextProjectile,minimumFiringRate,float.MaxValue);
            audioPlayer.playShootingClip();
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
