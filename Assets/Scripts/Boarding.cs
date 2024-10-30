using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boarding : MonoBehaviour
{
    [SerializeField] private GameObject[] chapters;
    private void OnEnable()
    {
        foreach (GameObject el in chapters) el.SetActive(true);
    }
    private void Awake()
    {
        Time.timeScale = 1;
        if(PlayerPrefs.HasKey("sfdgs3dfg"))
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetString("sfdgs3dfg", "true");
        }
    }
}
