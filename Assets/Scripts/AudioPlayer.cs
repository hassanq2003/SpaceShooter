using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField]AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume=1f;


    [Header("Damage")]
    [SerializeField]AudioClip DamageClip;
    [SerializeField] [Range(0f,1f)] float damageVolume=1f;

    public void playShootingClip()
    {
        if(shootingClip!=null)
        {
            AudioSource.PlayClipAtPoint(shootingClip,Camera.main.transform.position,shootingVolume);
        }
    }

    public void playDamageClip()
    {
        if(shootingClip!=null)
        {
            AudioSource.PlayClipAtPoint(DamageClip,Camera.main.transform.position,damageVolume);
        }
    }

}
