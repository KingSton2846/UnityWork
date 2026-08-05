using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _bonusScore = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreData scoreData = collision.GetComponent<ScoreData>();
        if (scoreData == null) return;

        scoreData.Add(_bonusScore);
        Destroy(this.gameObject);
    }
}
