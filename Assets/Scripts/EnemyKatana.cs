using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKatana : MonoBehaviour
{
    [Header("Other")]
    public float knockback = 750f;
    private CapsuleCollider attackTrigger;
    private Rigidbody rb;
    private Animator animator;
    [Header("VFX")]
    public ParticleSystem katanaTrailVFX;
    [Header("SFX")]
    private AudioSource katanaAudioSource;

    void Start()
    {
        attackTrigger = GetComponentInChildren<CapsuleCollider>();
        katanaAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void TurnIntoRagdoll()
    {
        rb.isKinematic = false;
        Destroy(animator);
        transform.SetParent(null, true);
    }

    public void DestroyKatana()
    {
        Destroy(gameObject);
    }
}
