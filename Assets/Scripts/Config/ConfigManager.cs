using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { get; private set; }

    private PlayerConfigSO _currentConfig;
    private PlayerController _player;

    public PlayerConfigSO CurrentConfig => _currentConfig;

    private void Awake()
    {
        Instance = this;
        _player = GetComponent<PlayerController>();
    }

    private void Start()
    {
        _player.LoadConfig(_currentConfig);
    }

    /// <summary>
    /// Обнавляем новый конфиг и сразу загружаем его в PlayerController
    /// </summary>
    /// <param name="newConfig"></param>
    public void SetConfig(PlayerConfigSO newConfig)
    {
        _currentConfig = newConfig;
        _player.LoadConfig(_currentConfig);
    }
}
