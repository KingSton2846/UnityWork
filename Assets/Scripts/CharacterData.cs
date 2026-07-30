using UnityEngine;
using System.Collections.Generic;

public class CharacterData : MonoBehaviour
{
    //Список логик подниятия уровней
    [SerializeField] private List<MonoBehaviour> _levelUpActions;

    [SerializeField] private int _score = 0;
    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private int _scoreToNextLevel = 20;

    public int Score => _score;
    public int CurrentLevel => _currentLevel;
    public int ScoreToNextLevel => _scoreToNextLevel;

    public void ScoreUp(int score)
    {
        _score += score;
        if(_score >= _scoreToNextLevel)
        {
            LevelUp();
        }
    }

    /// <summary>
    /// Обновление уровня и выполнение всех логик подниятия уровней(условние поднятия внутри логик)
    /// </summary>
    private void LevelUp()
    {
        _currentLevel++;
        _score -= _scoreToNextLevel;
        _scoreToNextLevel += 10;

        foreach(var actions in _levelUpActions)
        {
            if (actions is ILevelUp levelUp == false) return;
            levelUp.LevelUp(this, _currentLevel);
        }
    }
}
