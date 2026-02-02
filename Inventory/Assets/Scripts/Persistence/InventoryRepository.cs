using ErrorOr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public sealed class InventoryRepository : IInventoryRepository
{
    private readonly string _dataPath;

    public InventoryRepository(string dataPath)
    {
        Assert.IsFalse(string.IsNullOrEmpty(dataPath));

        _dataPath = dataPath;
    }

    public ErrorOr<Inventory> Load()
    {
        if (File.Exists(_dataPath) == false)
        {
            return Inventory.CreateEmpty();
        }

        try
        {
            // 1. 파일에서 Json을 로드
            string json = File.ReadAllText(_dataPath);

            // 2. Json에서 모델 개체 생성
            InventoryModel inventoryModel = JsonUtility.FromJson<InventoryModel>(json);

            // 3. 모델 개체에서 도메인 개체 생성
            List<BagItem> bagItems = inventoryModel.data
                .Select(model => new BagItem(
                        serialNumber: model.serial_number,
                        itemId: new ItemId(model.item_id)
                    ))
                .ToList();
            Bag bag = new Bag(bagItems);
            Inventory inventory = new(bag);

            return inventory;
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }
    }

    public ErrorOr<Success> Save(Inventory inventory)
    {
        Assert.IsNotNull(inventory);

        // 1. 모델 개체 생성
        InventoryModel inventoryModel = new()
        {
            data = inventory.UnequippedItems
                .Select(bagItem => new BagItemModel()
                {
                    serial_number = bagItem.SerialNumber,
                    item_id = bagItem.ItemId.RawId
                })
                .ToArray()
        };

        // 2. Json 문자열 생성
        string json = JsonUtility.ToJson(inventoryModel, true);

        // 3. 파일로 저장
        try
        {
            File.WriteAllText(_dataPath, json);
        }
        catch (Exception e)
        {
            return Error.Failure(description: e.Message);
        }

        return Result.Success;
    }
}