using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static string QuestID = "sfsdfgb";

    [SerializeField] private Image IconHandler;
    [SerializeField] private Sprite[] spritesIcon;

     private GameObject onBoarding;
    public void ToOnBoarding() => onBoarding.SetActive(true);
    private void Awake()
    {
        IconHandler.sprite = spritesIcon[PlayerPrefs.GetInt("ICON", 0)];
        Application.targetFrameRate = 120;
        Time.timeScale = 1;
    }
    [SerializeField] private List<GameObject> scenes;
    public void OnChangeSkin(int skin_num)
    {
        PlayerPrefs.SetInt("skin", skin_num);
        Scener("Menu");
    }
    public void Scener(string num)
    {
        foreach (GameObject el in scenes) el.SetActive(false);
        foreach(GameObject el in scenes)
        {
            if (el.name == num) el.SetActive(true);
        }
    }
}
