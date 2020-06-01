using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorGenerator : MonoBehaviour
{
	[SerializeField] private Tile[] _tilePrefabs;
	[SerializeField] private Vector2Int _mapSize = new Vector2Int(10, 10);
	private Tile[,] _placedTiles;

	private void Start()
	{
		_placedTiles = new Tile[_mapSize.x, _mapSize.y];

		StartCoroutine(Generate());
	}

	public IEnumerator Generate()
	{
		PlaceTile(new Vector2Int(_mapSize.x / 2, _mapSize.y / 2));

		while (true)
		{
			Vector2Int position;
			while (true)
			{
				position = new Vector2Int(Random.Range(1, _mapSize.x - 1), Random.Range(1, _mapSize.y - 1));

				if (_placedTiles[position.x, position.y] == null &&
					(_placedTiles[position.x - 1, position.y] != null ||
					 _placedTiles[position.x + 1, position.y] != null ||
					 _placedTiles[position.x, position.y - 1] != null ||
					 _placedTiles[position.x, position.y + 1] != null)) break;
			}

			PlaceTile(position);
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void PlaceTile(Vector2Int position)
	{
		List<Tile> availableTiles = new List<Tile>();

		foreach (Tile tilePrefab in _tilePrefabs)
		{
			if (CanAppendTile(_placedTiles[position.x - 1, position.y], tilePrefab, Vector3.left) &&
				CanAppendTile(_placedTiles[position.x + 1, position.y], tilePrefab, Vector3.right) &&
				CanAppendTile(_placedTiles[position.x, position.y - 1], tilePrefab, Vector3.back) &&
				CanAppendTile(_placedTiles[position.x, position.y + 1], tilePrefab, Vector3.forward))
			{
				availableTiles.Add(tilePrefab);
			}
		}

		if (availableTiles.Count == 0) return;

		Tile selectedTile = availableTiles[Random.Range(0, availableTiles.Count)];
		_placedTiles[position.x, position.y] = Instantiate(selectedTile, new Vector3(position.x, position.y, 0), Quaternion.identity);
	}

	private bool CanAppendTile(Tile existingTile, Tile tileToAppend, Vector3 direction)
	{
		return true;
	}
}
