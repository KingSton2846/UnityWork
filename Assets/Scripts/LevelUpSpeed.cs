using UnityEngine;

public class LevelUpSpeed : MonoBehaviour, ILevelUp
{
    [SerializeField] private int _minLevel = 5;
    public int MinLevel => _minLevel;

    /// <summary>
    /// Поднимает скорость каждые MinLevel уровней на значение уровня
    /// </summary>
    /// <param name="data"></param>
    /// <param name="level"></param>
    public void LevelUp(CharacterData data, int level)
    {
        if (level %_minLevel == 0) return;
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController == null) return;

        playerController.LoadSpeedMod(level);
    }
}
