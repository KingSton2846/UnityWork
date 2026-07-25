using UnityEngine;

public class LevelUpSpeed : MonoBehaviour, ILevelUp
{
    private PlayerController _playerController;
    [SerializeField] private int _minLevel = 5;
    public int MinLevel => _minLevel;

    public void LevelUp(CharacterData data, int level)
    {
        if (level %_minLevel == 0) return;
        _playerController = GetComponent<PlayerController>();
        if (_playerController == null) return;

        _playerController.SpeedMod = level;
    }
}
