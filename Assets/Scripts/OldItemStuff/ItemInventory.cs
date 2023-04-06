﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour {

    public List<ItemBase> ItemList;
    int CurrentItemIndex;

	// Use this for initialization
	void Start () {
        CurrentItemIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
		foreach(ItemBase item in ItemList)
        {
            item.UpdateCooldowns();
        }
	}

    public int GetCurrentItemIndex()
    {
        return CurrentItemIndex;
    }

    public void SelectNextItem()
    {
        CurrentItemIndex++;
        if(CurrentItemIndex >= ItemList.Count)
        {
            CurrentItemIndex -= ItemList.Count;
        }

        if(ItemList.Count == 0)
        {
            CurrentItemIndex = 0;
        }
    }

    public void SelectPreviousItem()
    {
        CurrentItemIndex--;
        if(CurrentItemIndex < 0)
        {
            CurrentItemIndex += ItemList.Count;
        }

        if (ItemList.Count == 0)
        {
            CurrentItemIndex = 0;
        }
    }

    public ItemBase GetCurrentItem()
    {
        if(CurrentItemIndex < ItemList.Count)
        {
            return ItemList[CurrentItemIndex];
        }
        return null;
    }

    public void AddItem(ItemBase item)
    {
        ItemList.Add(item);
    }

    public void RemoveItem(ItemBase item)
    {
        ItemList.Remove(item);
        SelectPreviousItem();
    }
}
