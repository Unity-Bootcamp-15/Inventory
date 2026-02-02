using UnityEngine;

[CreateAssetMenu(fileName = "ConfigurationSO", menuName = "Scriptable Objects/Config")]
public class ConfigurationSO : ScriptableObject
{
    [SerializeField] private string _playerDataPath;

    public string PlayerDataPath => _playerDataPath;

    public string PlayerDataDirectory => Application.persistentDataPath;
}
