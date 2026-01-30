using UnityEngine;

[CreateAssetMenu(fileName = "ItemRepositorySO", menuName = "Repository/ItemRepositorySO")]
public class ItemRepositorySO : ScriptableObject
{
    public IItemRepository Repository { get; private set; }

    public void Init()
    {
        var itemRepository = new ItemRepository();
        itemRepository.Load();
        Repository = itemRepository;
    }
}
