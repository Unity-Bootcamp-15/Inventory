using System.Collections.Generic;
using UnityEngine;


public class Initializer : MonoBehaviour
{
    [SerializeField] private UserInventoryServiceLocatorSO _userInventoryServiceLocator;
    [SerializeField] private ItemServiceLocatorSO _itemServiceLocator;
    [SerializeField] private ItemRepositorySO _itemRepositorySO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _itemRepositorySO.Init();
        _itemServiceLocator.Init(_itemRepositorySO.Repository);
        _userInventoryServiceLocator.Init(_itemServiceLocator.Service);
    }
}
