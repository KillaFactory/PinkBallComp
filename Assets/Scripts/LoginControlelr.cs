using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginControlelr : MonoBehaviour
{
    [SerializeField] private Image[] Icons;

    public Color start_color, end_color;

    [SerializeField] private InputField inputer;
    [SerializeField] private GameObject iconControler, nameChager;

    [HideInInspector] public string ID = "uydfgdfgfvbhy";

    private int numerChange;
    private void Awake()
    {
        if (PlayerPrefs.HasKey(ID)) Destroy(this.gameObject);
    }
    public void ToButton(int num)
    {
        foreach (Image el in Icons) el.color = start_color;
        Icons[num].color = end_color;
        numerChange = num;
    }
    public void ToIcon()
    {
        if(inputer.text.Length > 0)
        {
            PlayerPrefs.SetString("NAME", inputer.text);
            iconControler.SetActive(true);
            nameChager.SetActive(false);
        }
    }
    public void ToBack()
    {
        PlayerPrefs.SetInt("ICON", numerChange);
        PlayerPrefs.SetString(ID, "true");
        if (PlayerPrefs.HasKey(ID)) Destroy(this.gameObject);
    }
}
