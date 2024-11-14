using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Weapon
{
    float speed;

    void Start()
    {
        Damage = 20;
        speed = 10.0f * GetShootDirection();
    }

    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;

        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }
}
