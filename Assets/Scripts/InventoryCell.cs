using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private Text _nameField;
	[SerializeField] private Image _iconField;
	private GameObject _contextMenu;

	public void Render(IItem item)
	{
		_nameField.text = item.Name;
		_iconField.sprite = item.UIIcon;
	}

	public void SetContextMenu(GameObject contextMenu)
	{
		_contextMenu = contextMenu;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Right)
		{
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_contextMenu.transform.position = new Vector2(mousePosition.x, mousePosition.y);
			_contextMenu.SetActive(true);
		}
	}

	public void Equip()
	{
		Debug.Log("Equip");
	}
}
