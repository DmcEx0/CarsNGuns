using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : GameObjectFactory<Bullet>
{
    private PlayerCar _playerCar;

    public void SetPlayerCar(PlayerCar playerCar)
    {
        _playerCar = playerCar;

    }

    protected override void Spawn(Transform spawnPoint)
    {

    }

    protected override Bullet GetTemplate(Bullet bullet)
    {
        return bullet;
    }
}
