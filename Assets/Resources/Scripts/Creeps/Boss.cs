using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Creep
{
    [SerializeField]
    private AudioClip Sound;

    private new void Die()
    {
        if (health <= 0 && Boss_spawner.boss_spawner.Level != 2)
        {
            GoldCounter.currentGold += gold;
            Destroy(gameObject);
            Hero.hero.gameObject.GetComponent<AudioSource>().PlayOneShot(Sound);
            Boss_spawner.boss_spawner.Level += 1;
            Timer.timer.Reset();
        }
        else if (health <= 0 && Boss_spawner.boss_spawner.Level == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void Update()
    {
        Die();
    }
}
