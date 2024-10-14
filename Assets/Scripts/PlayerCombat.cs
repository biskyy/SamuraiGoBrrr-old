using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Weapons")]
    public GameObject mainWeapon;
    public GameObject secondaryWeapon;

    private Animator mainWeaponAnimator;
    private AudioSource mainWeaponAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        mainWeaponAnimator = mainWeapon.GetComponent<Animator>();
        mainWeaponAudioSource = mainWeapon.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CombatInput();
    }
    
    void CombatInput()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            mainWeaponAnimator.SetTrigger("Attacked");
            //mainWeaponAnimator.SetTrigger("Attacked");
        }
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    mainWeaponAudioSource.Play();
        //}
    }
}
