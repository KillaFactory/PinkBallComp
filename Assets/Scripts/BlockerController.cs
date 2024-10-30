using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerController : MonoBehaviour
{
    public string ID;
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(ID)) this.gameObject.SetActive(false);
    }
    public void OnBuy(int val)
    {
        if(PlayerPrefs.GetInt("M", 0) >= val)
        {
            PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M", 0) - val);
            PlayerPrefs.SetString(ID, "true");
            this.gameObject.SetActive(false);
        }
    }
}
