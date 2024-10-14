using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Katana : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Katana")]
    public float damage = 1f;
    public float knockback = 750f;
    private CapsuleCollider attackTrigger;
    [Header("VFX")]
    public ParticleSystem katanaTrailVFX;
    [Header("SFX")]
    private AudioSource katanaAudioSource;

    void Start()
    {
        attackTrigger = GetComponentInChildren<CapsuleCollider>();
        katanaAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyAI>(out var enemy))
        {
            // handle the blood effect
            ParticleSystem enemyPS = enemy.gameObject.GetComponentInChildren<ParticleSystem>();
            //set the position of the blood to the position of the impact
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            enemyPS.gameObject.transform.position = collisionPoint;
            //set the rotation of the blood towards the katana
            enemyPS.transform.rotation = Quaternion.LookRotation(transform.position - enemy.gameObject.transform.position);
            
            enemyPS.Play();
            
            enemy.TakeDamage(damage);

            // knockback the enemy
            Vector3 knockbackDirection = (enemy.gameObject.transform.position - transform.position).normalized;
            enemy.gameObject.GetComponent<Rigidbody>().AddForce(knockbackDirection * knockback);
        }
    }

    public void EnableTriggerSphere()
    {
        attackTrigger.enabled = true;
    }

    public void DisableTriggerSphere()
    {
        attackTrigger.enabled = false;
    }

    public void EnableTrail()
    {
        katanaTrailVFX.Play();
    }

    public void DisableTrail()
    {
        katanaTrailVFX.Stop();
    }

    public void PlaySoundEffect()
    {
        katanaAudioSource.Play();
    }
}
