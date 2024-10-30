using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusickManager : MonoBehaviour
{
    [SerializeField] private AudioSource musick;
    public Image[] buttons;
    [SerializeField] private Sprite on, off;
    public bool controller;
    private void LateUpdate()
    {
        musick.enabled = !controller;
        foreach(Image el in buttons)
        {
            if (!controller) el.sprite = on;
            else el.sprite = off;
        }
    }
    public void OnMusick()
    {
        controller = !controller;
    }
}
