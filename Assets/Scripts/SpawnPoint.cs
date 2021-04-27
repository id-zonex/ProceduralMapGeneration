using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private SpawnPoinType _spawnPoinType;
    [SerializeField] private float _radius;

    public SpawnPoinType SpawnPoinType => _spawnPoinType;

    private Rooms _rooms;

    private void Start()
    {
        _rooms = GameObject.FindObjectOfType<Rooms>();

        Invoke("SpawnRoom", 0.5f);
    }

    private void SpawnRoom()
    {
        if(CheckCollision() && !_rooms.AllRoomsIsSpawned)
        {
            Room room = GetRoom();

            Instantiate(room, transform.position, Quaternion.identity);
            _rooms.SpawnedRooms.Add(room);
        }


        Destroy(gameObject);

    }

    private Room GetRoom()
    {
        SpawnPoinType type = GetOppositeType();

        return _rooms.GetRoom(type);
    }

    private bool CheckCollision()
    {
        if(Physics2D.OverlapCircle(transform.position, _radius) != null)
            return false;

        return true;
    }

    private SpawnPoinType GetOppositeType()
    {
        SpawnPoinType type = SpawnPoinType.Left;

        switch (_spawnPoinType)
        {
            case SpawnPoinType.Top:
                type = SpawnPoinType.Bottom;
                break;
            case SpawnPoinType.Left:
                type = SpawnPoinType.Rigth;
                break;
            case SpawnPoinType.Rigth:
                type = SpawnPoinType.Left;
                break;
            case SpawnPoinType.Bottom:
                type = SpawnPoinType.Top;
                break;
            default:
                break;
        }

        return type;
    }
}
