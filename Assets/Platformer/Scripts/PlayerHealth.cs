using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public float HP;
    float maxHP;
    public Image HPBarFill;
    float lastAttacked = -9999;
    public float attackDelay = 100;
    public Animator AnimationTransition;
    WaitForSeconds delay = new WaitForSeconds(1);
    private void Awake()
    {
        maxHP = HP;
    }

    public void Health(int amount)
    {
        HP += amount;
        HPBarFill.fillAmount = HP / maxHP;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health(-1);
            Destroy(collision.gameObject);
            if (HP <= 0)
            {
                StartCoroutine(RestartScene());
            }
        }

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Attack();
            if (HP <= 0)
            {
                StartCoroutine(RestartScene());
            }
            
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            if (HP < maxHP)
            {
                HP = maxHP;
                HPBarFill.fillAmount = HP / maxHP;
            }
        }
    }

        private void Attack()
    {
        if (Time.time > lastAttacked + attackDelay)
        {
            if (HP > 0)
            {
                Health(-1);
                lastAttacked = Time.time;
            }
        }
    }

    IEnumerator RestartScene()
    {
        AnimationTransition.Play("FadeOut");
        yield return delay;
        SceneManager.LoadScene("Platformer");
    }
}


