using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCar : Car
{
    private int _minReward = 10;
    private int _maxReward = 40;

    public int Reward { get { return Random.Range(_minReward, _maxReward); } }
}