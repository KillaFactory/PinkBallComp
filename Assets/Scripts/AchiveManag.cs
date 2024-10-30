using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManag : MonoBehaviour
{
    public int Xer;
    public bool isWelcome, GoldTycoon;

    private void Awake()
    {
        if(isWelcome && !PlayerPrefs.HasKey(Menu.QuestID))
        {
            PlayerPrefs.SetString(Menu.QuestID, "true");
            PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M", 0) + 250);
        }
        else if(!GoldTycoon)
        {
            if(PlayerPrefs.GetInt("MX", 0) >= Xer && !PlayerPrefs.HasKey(Menu.QuestID + Xer.ToString()))
            {
                PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M", 0) + 250);
                PlayerPrefs.SetString(Menu.QuestID + Xer.ToString(), "true");
            }
            else if(PlayerPrefs.GetInt("MX", 0) < Xer)
            {
                this.gameObject.SetActive(false);
            }
        }
        
        if(GoldTycoon)
        {
            if (PlayerPrefs.GetInt("M", 0) > 1000 && !PlayerPrefs.HasKey(Menu.QuestID + Xer.ToString()))
            {
                PlayerPrefs.SetInt("M", PlayerPrefs.GetInt("M", 0) + 250);
                PlayerPrefs.SetString(Menu.QuestID + Xer.ToString(), "true");
            }
            else if (PlayerPrefs.GetInt("M", 0) < 1000 && !PlayerPrefs.HasKey(Menu.QuestID + Xer.ToString()))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
