using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy , IShootable
{
    private float attackRange = 5f;

    [SerializeField] private Player player;

    [SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    public float bulletWaitTime { get; set; }
    public float bulletTimer { get; set; }

    private void Start()
    {
        Init(100);
        healthBar.SetMaxHealth(Health);
        bulletWaitTime = 1.0f;
        bulletTimer = 0.0f;
    }

    void FixedUpdate()
    {
        bulletTimer -= Time.deltaTime;
        Behavior();
    }

    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        if (direction.magnitude < attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (bulletTimer <= 0f)
        {
            animator.SetTrigger("Shoot");
            GameObject obj = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);

            Egg eggScipt = obj.GetComponent<Egg>();
            eggScipt.Init(20, this);

            bulletTimer = bulletWaitTime;
        }
    }
}
