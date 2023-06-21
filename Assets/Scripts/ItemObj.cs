using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemObj : MonoBehaviour
{
    public Item[] itemArray = new Item[3];
    private bool ascendingSort = true;
   

    //public void BubbleSortButtonClicked()
    //{
    //    SortAlgorithms.BubbleSort(itemArray, ascendingSort);
    //    PrintItemArray();
    //    ascendingSort = !ascendingSort;
    //}

    //public void RadixSortButtonClicked()
    //{
    //    SortAlgorithms.RadixSort(itemArray, ascendingSort);
    //    PrintItemArray();
    //    ascendingSort = !ascendingSort;
    //}

    //public void QuickSortButtonClicked()
    //{
    //    SortAlgorithms.QuickSort(itemArray, ascendingSort);
    //    PrintItemArray();
    //    ascendingSort = !ascendingSort;
    //}

    //private void PrintItemArray()
    //{
    //    foreach (Item item in itemArray)
    //    {
    //        print("item name = " + item.DisplayName);
    //        print("item description = " + item.Description);
    //        print("item price = " + item.Price);
    //    }

    //}

    [SerializeField] Item item;
    public Item Item => item;
    // Start is called before the first frame update
    void Start()
    { 
        //print("item name = " + item.DisplayName);
        //print("item description = " + item.Description);
        //print("item price = " + item.Price);
    }

    public static class SortAlgorithms
    {

        public static void BubbleSort(Item[] items, bool ascending)
        {
            print("BubbleSort");
            int length = items.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (ascending ? items[j].Price > items[j + 1].Price : items[j].Price < items[j + 1].Price)
                    {
                        Item temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;

                        for (int k = 0; k < length; k++)
                        {
                            Inventory.Instance.inventoryField[k].sprite = Inventory.Instance.itemArray[k].Icon;
                        }
                    }
                }
            }
        }

        public static void RadixSort(Item[] items, bool ascending)
        {
            print("RadixSort");
            if (items == null || items.Length == 0)
            {
                return; // Überprüfen, ob das Array null oder leer ist
            }

            // Bestimme die maximale Anzahl von Stellen im Preiswert
            int maxPrice = GetMaxPriceValue(items);
            int numDigits = GetNumDigits(maxPrice);

            // Erstelle eine temporäre Hilfsliste
            List<Item>[] buckets = new List<Item>[10];

            for (int i = 0; i < 10; i++)
            {
                buckets[i] = new List<Item>();
            }

            // Führe den Radixsort durch
            for (int digit = 0; digit < numDigits; digit++)
            {
                foreach (Item item in items)
                {
                    if (item != null)
                    {
                        int bucketIndex = GetDigitAtIndex((int)item.Price, digit);
                        buckets[bucketIndex].Add(item);
                    }
                }

                int currentIndex = 0;
                for (int i = 0; i < 10; i++)
                {
                    List<Item> bucket = buckets[i];
                    foreach (Item item in bucket)
                    {
                        Inventory.Instance.inventoryField[currentIndex].sprite = Inventory.Instance.itemArray[currentIndex].Icon;
                        items[currentIndex] = item;
                        currentIndex++;
                    }
                    bucket.Clear();
                }
            }

            // Umkehren der Reihenfolge, wenn absteigend sortiert werden soll
            if (!ascending)
            {
                Array.Reverse(items);
            }
        }

        public static void QuickSort(Item[] items, bool ascending)
        {
            print("QuickSort");
            QuickSort(items, 0, items.Length - 1, ascending);
        }

        private static void QuickSort(Item[] items, int low, int high, bool ascending)
        {
            print("access");
            if (low < high)
            {
                print("high" + high);
                print("low" + low);
                int partitionIndex = Partition(items, low, high, ascending);
                Inventory.Instance.inventoryField[partitionIndex].sprite = Inventory.Instance.itemArray[partitionIndex].Icon;
                QuickSort(items, low, partitionIndex - 1, ascending);
                QuickSort(items, partitionIndex + 1, high, ascending);
            }
        }

        /// <summary>
        /// blabla
        /// </summary>
        /// <param name="items"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public static int Partition(Item[] items, int low, int high, bool ascending)
        {
            print("access");
            if (items == null || items.Length == 0 || low < 0 || high >= items.Length)
            {
                return -1; // Überprüfen, ob das Array null ist oder ungültige Indizes hat
            }

            Item pivot = items[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (ascending)
                {
                    if (items[j].Price <= pivot.Price)
                    {
                        i++;
                        Swap(items, i, j);
                    }
                }
                else
                {
                    if (items[j].Price >= pivot.Price)
                    {
                        i++;
                        Swap(items, i, j);
                    }
                }
            }

            Swap(items, i + 1, high);
            return i + 1;
        }

        #region Methods
        private static void Swap(Item[] items, int i, int j)
        {
            Item temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        private static int GetMaxPriceValue(Item[] items)
        {
            int maxPrice = 0;
            foreach (Item item in items)
            {
                if (item != null && item.Price > maxPrice)
                {
                    maxPrice = (int)item.Price;
                }
            }
            return maxPrice;
        }

        private static int GetNumDigits(int value)
        {
            if (value == 0)
            {
                return 1;
            }

            int numDigits = 0;
            while (value != 0)
            {
                value /= 10;
                numDigits++;
            }
            return numDigits;
        }

        private static int GetDigitAtIndex(int value, int index)
        {
            int pow10 = (int)Mathf.Pow(10, index);
            return (value / pow10) % 10;
        }
        #endregion
    }
}
