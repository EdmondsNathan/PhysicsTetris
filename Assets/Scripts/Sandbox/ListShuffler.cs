using System.Collections.Generic;

public static class IListExtensions
{
	/// <summary>
	/// Shuffles the element order of the specified list.
	/// </summary>
	/// taken from https://discussions.unity.com/t/clever-way-to-shuffle-a-list-t-in-one-line-of-c-code/535113/2
	public static void Shuffle<T>(this IList<T> ts)
	{
		var count = ts.Count;
		var last = count - 1;
		for (var i = 0; i < last; ++i)
		{
			var r = UnityEngine.Random.Range(i, count);
			var tmp = ts[i];
			ts[i] = ts[r];
			ts[r] = tmp;
		}
	}
}