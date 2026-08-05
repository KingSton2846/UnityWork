using UnityEngine;

public class StarItem : MonoBehaviour, IUsable
{
    [SerializeField] private int _bonusSpeed = 3;
    public void Use(GameObject player)
    {
        SpeedModeData speedModeData = player.GetComponent<SpeedModeData>();
        if (speedModeData == null) return;

        speedModeData.Add(_bonusSpeed);
        Destroy(this.gameObject);
    }
}
