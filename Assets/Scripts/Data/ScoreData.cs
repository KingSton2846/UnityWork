using UnityEngine;

public class ScoreData : ValueData<int>
{
    [SerializeField] private int _minScore = 0;

    public void Add(int amount)
    {
        SetValue(Value + Mathf.Abs(amount));
    }

    public void Remove(int amount)
    {
        SetValue(Value - Mathf.Abs(amount));
    }

    public override void ResetValue()
    {
        SetValue(_minScore);
    }
}
