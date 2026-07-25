using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
public class PlayerConfigSO : ScriptableObject
{
    public string configName = "Default";
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
}
