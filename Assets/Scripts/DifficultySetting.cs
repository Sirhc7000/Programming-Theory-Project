using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]

public class DifficultySetting
{
    public SpeedSettings speedSetting;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;

    public float GetSpawnDelay()
    {
        float delay = Random.Range(minRange, maxRange);
        return delay;
    }
}
