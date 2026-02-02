using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryRepositorySO", menuName = "Repository/InventoryRepositorySO")]
public class InventoryRepositorySO : ScriptableObject
{
    [SerializeField] private ConfigurationSO _config;

    public IInventoryRepository Repository { get; private set; }

    public void Init()
    {
        string dataPath = Path.Combine(_config.PlayerDataDirectory, _config.PlayerDataPath);
        Repository = new InventoryRepository(dataPath);
    }
}
