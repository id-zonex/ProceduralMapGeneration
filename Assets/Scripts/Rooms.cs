using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    [SerializeField] private Room[] _rooms;

    [SerializeField] private int _maxRoomCount;

    public List<Room> SpawnedRooms { get; private set; } = new List<Room>();
    public bool AllRoomsIsSpawned => SpawnedRooms.Count >= _maxRoomCount? true : false;


    public Room GetRoom(SpawnPoinType roomType)
    {
        return GetRoomOfType(roomType);
    }

    private Room GetRoomOfType(SpawnPoinType roomType)
    {
        MixArray();

        foreach(var room in _rooms)
        {
            if (room.SpawnPoints.Length == 0)
                room.Initialize();

            foreach(var spawnPoint in room.SpawnPoints)
            {
                if(spawnPoint.SpawnPoinType == roomType)
                {
                    return room;
                }
            }
        }

        return null;
    }

    private void MixArray()
    {
        System.Random random = new System.Random();

        for(int i = 0; i < _rooms.Length; i++)
        {
            int j = random.Next(i + 1);
            var temp = _rooms[j];

            _rooms[j] = _rooms[i];
            _rooms[i] = temp;
        }
    }

    private Room GetRandomRoom(Room[] rooms)
    {
        return rooms[UnityEngine.Random.Range(0, rooms.Length)];
    }
}