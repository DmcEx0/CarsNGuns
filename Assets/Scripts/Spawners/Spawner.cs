using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    protected abstract void Spawn(Transform spawnPoint);
}
