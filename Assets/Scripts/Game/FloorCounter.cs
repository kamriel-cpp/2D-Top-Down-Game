public class FloorCounter
{
	private int _count;

	public int Count => _count;

	private void Start()
	{
		Reset();
	}

	public void Increase()
	{
		_count++;
	}

	public void Reset()
	{
		_count = 0;
	}
}
