using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // singleton на минималках
    public static Hero hero { get; private set; }
    [SerializeField]
    public Animator animator;
    public static int Damage = 45;
    protected int exp;
    [SerializeField]
    protected int level = 1;

    bool isAttack = false;

    public AudioClip[] attackSounds;
    private AudioSource audioSourse;

    private void Start()
    {
        hero = this;
        audioSourse = GetComponent<AudioSource>();
    }

    public void attackSoundPlay()
    {
        audioSourse.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);
    }

    void Update()
    {
        Attack();
        animator.SetBool("isAttack", isAttack);
    }

    void Attack()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isAttack = true;

                //find creep's script
                Creep enemy = GameObject.FindGameObjectWithTag("Creep").GetComponent<Creep>();
                
                enemy.TakeDamage(Damage);

                // Log
                //Debug.Log($"attack {enemy.name} Health= {enemy.health}");

            }
            else
            {
                isAttack = false;
            }
    }
}

