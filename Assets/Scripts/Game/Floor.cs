using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
	[SerializeField] private Room[] _roomPrefabs;
	[SerializeField] private int _roomsCount = 10;
	private Room _startingRoom;

	private Room[,] _spawnedRooms;

	private Vector2Int[] _directions;

	private void Start() 
	{
		_directions = new Vector2Int[4];
		_directions[0] = new Vector2Int( 1, 0);
		_directions[1] = new Vector2Int(-1, 0);
		_directions[2] = new Vector2Int( 0, 1);
		_directions[3] = new Vector2Int( 0,-1);

		_spawnedRooms = new Room[15, 15];
		_startingRoom = _spawnedRooms[7, 7];

		Generate();
	}

	private void Generate() 
	{
		for (int roomNumber = 0; roomNumber < _roomsCount; roomNumber++)
		{
			HashSet<Vector2Int> emptyPlaces = new HashSet<Vector2Int>();

			Vector2Int gridMinBorder = new Vector2Int(0, 0);
			Vector2Int gridMaxBorder = new Vector2Int(_spawnedRooms.GetLength(0) - 1,
													  _spawnedRooms.GetLength(1) - 1);

			for (int x = 0; x < _spawnedRooms.GetLength(0); x++) 
			{
				for (int y = 0; y < _spawnedRooms.GetLength(1); y++) 
				{
					if (_spawnedRooms[x, y] == null && x != 7 && y != 7) continue;

					for (int i = 0; i < 4; i++)
						if (x > gridMinBorder.x && y > gridMinBorder.y &&
							x < gridMaxBorder.x && y < gridMaxBorder.y &&
							_spawnedRooms[x + _directions[i].x, y + _directions[i].y] == null)
							emptyPlaces.Add(new Vector2Int(x + _directions[i].x, y + _directions[i].y));
				}
			}

			PlaceRoom(emptyPlaces.ElementAt(Random.Range(0, emptyPlaces.Count)));
		}
	}

	private void PlaceRoom(Vector2Int position) 
	{
		Room newRoom = Instantiate(_roomPrefabs[Random.Range(0, _roomPrefabs.Length)]);
		newRoom.transform.position = new Vector3(position.x, position.y, 0);

		_spawnedRooms[position.x, position.y] = newRoom;
	}
}
