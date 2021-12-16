using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemPickupUI : MonoBehaviour
{
    private string[] items;
    [SerializeField] private TextMeshProUGUI itemLog;

    void Awake()
    {
        items = new string[5];
        for (int i = 0; i < items.Length; i++)
        {
            items[i] = "";
        }
    }

    public void OnPickup(string item)
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            items[i] = items[i + 1];
        }

        items[items.Length- 1] = item;

        itemLog.text = string.Join("\n", items);
    }
}
