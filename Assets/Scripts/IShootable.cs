using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    Transform SpawnPoint { get; set; }
    GameObject Bullet { get; set; }

    float bulletWaitTime { get; set; }
    float bulletTimer { get; set; }

    void Shoot();
}
