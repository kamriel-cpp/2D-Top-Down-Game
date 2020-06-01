using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Context Item")]
public class AssetContextItem : ScriptableObject, IContextItem
{
	public string Title => _title;
	public Button Button => _button;

	[SerializeField] private string _title;
	[SerializeField] private Button _button;
}
