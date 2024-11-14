using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character, IShootable
{
    [SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    public float bulletWaitTime { get; set; }
    public float bulletTimer { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && bulletWaitTime >= bulletTimer)
        {
            GameObject obj = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);
            Shuriken shuriken = obj.GetComponent<Shuriken>();
            shuriken.Init(10, this);
        }
    }

    void Start()
    {
        Init(100);
        healthBar.SetMaxHealth(Health);
        bulletTimer = 0.0f;
        bulletWaitTime = 1.0f;
    }

    void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        bulletWaitTime += Time.fixedDeltaTime;
    }

    void onCollisionEnter2D(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

}
