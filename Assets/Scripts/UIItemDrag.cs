using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItemDrag : MonoBehaviour
{
	public static UIItemDrag Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private Canvas _canvas;
	private RectTransform _rectTransform;
	private RectTransform _parentRectTransform;
	private CanvasGroup _canvasGroup;
	private Image _image;
	private Item _item;

	private void Start()
	{
		_rectTransform = GetComponent<RectTransform>();
		_canvasGroup = GetComponent<CanvasGroup>();
		_canvas = GetComponent<Canvas>();
		_image = transform.Find("image").GetComponent<Image>();
		_parentRectTransform = transform.parent.GetComponent<RectTransform>();

		Hide();
	}

	private void Update()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(_parentRectTransform, Input.mousePosition, null, out Vector2 localPoint);
		transform.localPosition = localPoint;
	}

	public Item GetItem()
	{
		return _item;
	}

	public void SetItem(Item item)
	{
		_item = item;
	}

	public void SetSprite(Sprite sprite)
	{
		_image.sprite = sprite;
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show(Item item)
	{
		gameObject.SetActive(true);

		SetItem(item);
		//SetSprite(item.GetSprite());
		UpdatePosition();
	}

}
