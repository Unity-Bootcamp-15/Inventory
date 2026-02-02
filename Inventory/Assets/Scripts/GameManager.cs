using ErrorOr;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UserInventoryServiceLocatorSO _userInventoryServiceLocator;
    [SerializeField] private InventoryUI _inventoryUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var result = _userInventoryServiceLocator.Service.LoadData();
        if (result.IsError)
        {
            Debug.LogError(result.FirstError.Description);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        // 스페이스 키를 누르면 랜덤한 아이템을 획득한다.
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("랜덤한 아이템 획득 시도");
            var result = _userInventoryServiceLocator.Service.AcquireRandomItem()
                .ThenDo(_ => _inventoryUI.Refresh());

            if (result.IsError)
            {
                Debug.LogError($"랜덤한 아이템 획득 실패: {result.FirstError.Description}");
            }
        }

        // I키를 누르면 현재 갖고 있는 아이템을 보여준다.
        // ㄴ 로그
        if (keyboard.iKey.wasPressedThisFrame)
        {
            Debug.Log("현재 아이템 목록");
            foreach (var item in _userInventoryServiceLocator.Service.UnequippedItems)
            {
                Debug.Log($"SerialNumber: {item.SerialNumber}, itemId: {item.ItemId}");
            }
        }
    }


    private void OnApplicationQuit()
    {
        _userInventoryServiceLocator.Service.SaveData();
    }
}
