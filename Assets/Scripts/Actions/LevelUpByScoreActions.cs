using UnityEngine;

public class LevelUpByScoreActions : MonoBehaviour
{
    [SerializeField] private int _scorePerLevel = 100;
    private ScoreData _scoreData;
    private LevelData _levelData;

    private void Start()
    {
        _scoreData = GetComponent<ScoreData>();
        _levelData = GetComponent<LevelData>();
        _scoreData.OnValueChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int currentScore)
    {
        if(IsLevelUpThresholdReach(currentScore) == true)
        {
            _scoreData.Remove(_scorePerLevel);
            _levelData.Up();
        }
    }

    private bool IsLevelUpThresholdReach(int score)
    {
        return score >= _scorePerLevel;
    }

    private void OnDestroy()
    {
        _scoreData.OnValueChanged -= OnScoreChanged;
    }
}
