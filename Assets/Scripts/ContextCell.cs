using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ContextCell : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private Text _titleField;
	private InventoryCell _inventoryCell;

	public void SetInventoryCell(InventoryCell inventoryCell)
	{
		_inventoryCell = inventoryCell;
	}

	public void Render(IContextItem item)
	{
		_titleField.text = item.Title;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left)
			_inventoryCell.Equip();
	}
}
