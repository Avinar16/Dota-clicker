using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Creep
{
    [SerializeField]
    private AudioClip Sound;

    private new void Die()
    {
        if (health <= 0)
        {
            GoldCounter.currentGold += gold;
            Destroy(gameObject);
            Hero.hero.gameObject.GetComponent<AudioSource>().PlayOneShot(Sound);
            Boss_spawner.boss_spawner.Level += 1;
            Timer.timer.Reset();
        }
    }
    private void Update()
    {
        Die();
    }
}
