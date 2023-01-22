using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaPlant : MonoBehaviour
{
    public GameObject Bullet;
    public Transform Spawnpoint;
    public float BulletForce;

    public float AttackTimer;
    float maxTimer;

    Animator anim;

    private void Awake()
    {
        maxTimer = AttackTimer;
    }

    private void Update()
    {
        if (AttackTimer > 0)
        {
            AttackTimer -= Time.deltaTime;
            anim = GetComponent<Animator>();
        }
        else
        {
            AttackTimer = maxTimer;
            anim.Play("PiranhaAttack");
        }
    }
            void Shoot()
            {
                GameObject bullet = Instantiate(Bullet, Spawnpoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right*BulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 3);
            }
        
}
