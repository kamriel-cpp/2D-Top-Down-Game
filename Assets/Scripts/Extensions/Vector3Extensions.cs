using UnityEngine;

namespace Assets.Scripts.Extensions
{
	public static class Vector3Extensions
	{
		public static Vector3 Round(this Vector3 vector)
		{
			return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
		}
	}
}
