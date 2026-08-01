using UnityEngine;
using System.Collections.Generic;

public class LevelUpController : MonoBehaviour
{
    //Список логик подниятия уровней
    [SerializeField] private List<MonoBehaviour> _levelUpActions;

    private CharacterData _characterData;

    private void Start()
    {
        _characterData = GetComponent<CharacterData>();
        _characterData.OnChangeLevel += LevelUp;
    }

    /// <summary>
    /// Обновление уровня и выполнение всех логик подниятия уровней(условние поднятия внутри логик)
    /// </summary>
    private void LevelUp(int currentLevel)
    {
        foreach (var actions in _levelUpActions)
        {
            if (actions is ILevelUp levelUp == false) return;
            levelUp.LevelUp(_characterData, currentLevel);
        }
    }
}
