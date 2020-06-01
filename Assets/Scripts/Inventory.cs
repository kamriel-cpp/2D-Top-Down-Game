using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] private List<AssetItem> _items;
	[SerializeField] private InventoryCell _inventoryCellTemplate;
	[SerializeField] private Transform _container;
	[SerializeField] private GameObject _contextMenu;

	public void OnEnable()
	{
		Render(_items);
	}

	public void Render(List<AssetItem> items)
	{
		foreach (Transform child in _container)
			Destroy(child.gameObject);

		items.ForEach(item =>
		{
			var cell = Instantiate(_inventoryCellTemplate, _container).GetComponent<InventoryCell>();
			cell.SetContextMenu(_contextMenu);
			cell.Render(item);
		});
	}
}
