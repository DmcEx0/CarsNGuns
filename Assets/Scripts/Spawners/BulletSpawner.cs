using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private ObjectPool<Bullet> _pool;

    protected override void Spawn()
    {
        
    }

    protected override void CreatePool()
    {
        base.CreatePool();

        //_pool = new ObjectPool<Bullet>()
    }
}
