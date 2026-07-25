using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

public class SettingWindow : EditorWindow
{
    private List<PlayerConfigSO> _allConfigs = new List<PlayerConfigSO>();
    private PlayerConfigSO _selectedConfig;

    [MenuItem("Window/Game Settings Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<SettingWindow>(typeof(SettingWindow));
    }

    private void OnEnable()
    {
        LoadConfigs();
    }

    /// <summary>
    /// Загрузка всех конфигов при запуске
    /// </summary>
    private void LoadConfigs()
    {
        string[] settingList = AssetDatabase.FindAssets("t:PlayerConfigSO");

        _allConfigs = settingList
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid)) // guid -> путь
            .Select(path => AssetDatabase.LoadAssetAtPath<PlayerConfigSO>(path)) // путь -> объект
            .Where(file => file != null) // проверка на целотность
            .ToList(); // результат в список
    }

    private void OnGUI()
    {
        GUILayout.Label("Game Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);

        // Смотрим все наши конфиги
        foreach (PlayerConfigSO config in _allConfigs)
        {
            // Делаем кнопку под каждый конфиг
            if(GUILayout.Button(config.configName) == true)
            {
                // Обнавляем текущий и отправляем его в ConfigManager
                _selectedConfig = config;
                ConfigManager.Instance.SetConfig(_selectedConfig);
            }
        }
    }
}
