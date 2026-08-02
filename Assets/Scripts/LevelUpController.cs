using UnityEngine;
using System.Collections.Generic;

public class LevelUpController : MonoBehaviour
{
    //Список логик подниятия уровней
    [SerializeField] private List<MonoBehaviour> _levelUpActions;

    private LevelData _levelData;

    private void Start()
    {
        _levelData = GetComponent<LevelData>();
        _levelData.OnValueChanged += LevelUp;
    }

    /// <summary>
    /// Обновление уровня и выполнение всех логик подниятия уровней(условние поднятия внутри логик)
    /// </summary>
    private void LevelUp(int currentLevel)
    {
        foreach (var actions in _levelUpActions)
        {
            if (actions is ILevelUp levelUp == false) return;
            levelUp.LevelUp(currentLevel);
        }
    }
}
