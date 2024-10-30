using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text[] views;
    private void LateUpdate()
    {
        int money = PlayerPrefs.GetInt("M", 0);
        foreach (Text el in views) el.text = money.ToString();
    }
}
