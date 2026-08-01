using UnityEngine;
using System;

public class CharacterData : MonoBehaviour
{
    public event Action<int> OnChangeLevel;

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
            _currentLevel++;
            _score -= _scoreToNextLevel;
            _scoreToNextLevel += 10;

            OnChangeLevel?.Invoke(_currentLevel);
        }
    }
}
