using System;
using UnityEngine;

[Serializable]
public class Bullet 
{
    public PowerUpType type;
    public int maxBulletAmount;
    public float reloadDelay;
    public float shootDelay;
    public GameObject prefab;
}
