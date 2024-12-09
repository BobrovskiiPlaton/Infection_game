using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }
    private List<Item> items = new List<Item>();
    [SerializeField] private List<Image> slotsImages;

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        ShowItem();
    }
    

    void ShowItem()
    {
        for(int i = 0; i < items.Count; i++)
        {

            if (items[i] != null)
            {
                //Instantiate(items[i].image, items[i].transform);
                slotsImages[i].sprite = items[i].sprite;
                break;
            }
        }
    }
}
