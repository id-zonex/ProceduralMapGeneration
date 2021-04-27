using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public SpawnPoint[] SpawnPoints { get; private set; }

    private void Awake()
    {
        SpawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    public void Initialize()
    {
        SpawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
}
