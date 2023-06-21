using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static ItemObj;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private bool ascendingSort = true;

    
    public List<Item> items = new List<Item>();
    public Item[] itemArray; 

    public Image[] inventoryField;
    int currentFieldIndex;

    private void Awake()
    {
        //ref in ItemObj
        if (Instance == null)
            Instance = this;
    }

    //public void CollectItem(Item item)
    //{
    //    items.Add(item);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ItemObj>(out ItemObj itemObj))
        {
            if (currentFieldIndex < inventoryField.Length)
            {
                items.Add(itemObj.Item);
                inventoryField[currentFieldIndex].sprite = itemObj.Item.Icon;
                currentFieldIndex++;

                Destroy(other.gameObject);
            }
            else
                print("No space left in inventory");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BubbleSortButtonClicked()
    {
        Item[] array = items.ToArray();
        itemArray = array;
        SortAlgorithms.BubbleSort(array, ascendingSort);
        PrintItemArray(array);
        ascendingSort = !ascendingSort;
    }

    public void RadixSortButtonClicked()
    {
        Item[] array = items.ToArray();
        itemArray = array;
        SortAlgorithms.RadixSort(array, ascendingSort);
        PrintItemArray(array);
        ascendingSort = !ascendingSort;
    }

    public void QuickSortButtonClicked()
    {
        Item[] array = items.ToArray();
        itemArray = array;
        SortAlgorithms.QuickSort(array, ascendingSort);
        PrintItemArray(array);
        ascendingSort = !ascendingSort;
    }

    private void PrintItemArray(Item[] _items)
    {
        foreach (Item item in _items)
        {
            print("item name = " + item.DisplayName);
            print("item description = " + item.Description);
            print("item price = " + item.Price);
        }

    }
}
