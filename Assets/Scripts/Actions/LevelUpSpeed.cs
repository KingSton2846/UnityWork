using UnityEngine;

public class LevelUpSpeed : MonoBehaviour, ILevelUp
{
    [SerializeField] private int _minLevel = 5;
    [SerializeField] private int _speedMode = 3;
    public int MinLevel => _minLevel;

    /// <summary>
    /// Поднимает скорость каждые MinLevel уровней на значение уровня
    /// </summary>
    /// <param name="data"></param>
    /// <param name="level"></param>
    public void LevelUp(int level)
    {
        if (level % _minLevel != 0) return;
        SpeedModeData speedModeData = GetComponent<SpeedModeData>();
        if (speedModeData == null) return;

        speedModeData.Add(_speedMode);
    }
}
