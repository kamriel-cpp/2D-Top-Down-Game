using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
	public enum ItemType
	{
		Helmet,
		Armor,
		Gloves
	}

	/**
	 *	Sword,
	 *	HealthPotion,
	 *	ManaPotion,
	 *	Coin,
	 *	Medkit,
	 *	ArmorNone,
	 *	Armor_1,
	 *	Armor_2,
	 *	HelmetNone,
	 *	Helmet_1,
	 *	SwordNone,
	 *	Sword_1,
	 *	Sword_2
	**/

	//мб добавить enum ItemClass и Color _color
	private ItemType _itemType;
	public int Amount = 1;

	/*
	public Sprite GetSprite()
	{
		return GetSprite(_itemType);
	}

	public static Sprite GetSprite(ItemType itemType)
	{
		switch (itemType) 
		{
		default:
		case ItemType.Helmet:	return ItemAssets.Instance.s_Helmet;
		case ItemType.Armor:	return ItemAssets.Instance.s_Armor;
		case ItemType.Gloves:	return ItemAssets.Instance.s_Gloves;
		}
	}
	*/

	public bool IsStackable()
	{
		return IsStackable(_itemType);
	}

	public static bool IsStackable(ItemType itemType)
	{
		return false; //покаместь так, но вообще надо свичить
	}
	
	public int GetCost()
	{
		return GetCost(_itemType);
	}

	public static int GetCost(ItemType itemType)
	{
		switch (itemType) 
		{
		default:
		case ItemType.Helmet:	return 50;
		case ItemType.Armor:	return 50;
		case ItemType.Gloves:	return 50;
		}
	}
	
	public override string ToString()
	{
		return _itemType.ToString();
	}
}
