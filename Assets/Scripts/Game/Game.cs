using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    private FloorCounter _floorCounter;
    private bool _isPlaying;

    public bool IsPlaying()
    {
        return _isPlaying;
    }

    private void Start()
    {
        _floorCounter = new FloorCounter();
        _floorCounter.Increase();
        _isPlaying = true;
    }

    private void Exit()
    {
        Application.Quit(1);
    }
}
