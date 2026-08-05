using UnityEngine;

public class SpeedModeData : ValueData<int>
{
    [SerializeField] private int _minSpeedMod = 1;
    [SerializeField] private int _maxSpeedMod = 50;

    public void Add(int amount)
    {
        int speedMod = Value + Mathf.Abs(amount);
        if (speedMod >= _maxSpeedMod)
        {
            SetValue(_maxSpeedMod);
        }
        else
        {
            SetValue(speedMod);
        }
        
    }

    public void Remove(int amount)
    {
        int speedMod = Value - Mathf.Abs(amount);
        if (speedMod <= _minSpeedMod)
        {
            SetValue(_minSpeedMod);
        }
        else
        {
            SetValue(speedMod);
        }
    }

    public override void ResetValue()
    {
        SetValue(_minSpeedMod);
    }
}