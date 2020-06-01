using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
	[SerializeField] private List<AssetContextItem> _items;
	[SerializeField] private ContextCell _contextCellTemplate;
	[SerializeField] private Transform _container;
	private InventoryCell _inventoryCell;
	
	public void OnEnable()
	{
		Render(_items);
	}

	public void Render(List<AssetContextItem> items)
	{
		foreach (Transform child in _container)
			Destroy(child.gameObject);

		items.ForEach(item =>
		{
			var cell = Instantiate(_contextCellTemplate, _container).GetComponent<ContextCell>();
			cell.Render(item);
		});
	}
}
