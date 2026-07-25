using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConfigManager))]
public class SettingInspetor : Editor
{
    private ConfigManager _target;
    private List<PlayerConfigSO> _playerConfigs = new List<PlayerConfigSO>();
    private string[] _configNames;
    private int _selectIndex;

    private void OnEnable()
    {
        _target = (ConfigManager)target;
        LoadConfigs();
        FindCurrentIndex();
    }

    private void LoadConfigs()
    {
        string[] settingList = AssetDatabase.FindAssets("t:PlayerConfigSO");

        _playerConfigs = settingList
            .Select(guid => AssetDatabase.GUIDToAssetPath(guid)) // guid -> путь
            .Select(path => AssetDatabase.LoadAssetAtPath<PlayerConfigSO>(path)) // путь -> объект
            .Where(file => file != null) // проверка на целотность
            .ToList(); // результат в список

        _configNames = _playerConfigs.Select(name => name.configName).ToArray();
    }

    private void FindCurrentIndex()
    {
        _selectIndex = 0;
    }

    public override void OnInspectorGUI()
    {
        // Рисуем стандартные поля
        DrawDefaultInspector();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Select Config:", EditorStyles.boldLabel);


        // DropDown
        int newIndex = EditorGUILayout.Popup(_selectIndex, _configNames);

        if (newIndex != _selectIndex)
        {
            _selectIndex = newIndex;
            _target.SetConfig(_playerConfigs[_selectIndex]);
            EditorUtility.SetDirty(_target);
        }
    }
}
