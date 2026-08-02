using UnityEngine;

public class LevelData : ValueData<int>
{
    [SerializeField] private int _minLevel = 1;

    public void Up()
    {
        SetValue(Value + 1);
    }

    public void Down()
    {
        SetValue(Value - 1);
    }

    public override void ResetValue()
    {
        SetValue(_minLevel);
    }
}
