using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer origin;
    [SerializeField] private Sprite[] Bg_sprites;

    [SerializeField] private GameObject paused;
    private bool pausedController;

    public SpriteRenderer ScopeEffevtRend, BallEffect;
    public Color green_color, red_color;

    private Scope scope;
    private void OnEnable()
    {
        int curLvl = PlayerPrefs.GetInt("lvl", 0);
        if (curLvl > 5) origin.sprite = Bg_sprites[1];
        else origin.sprite = Bg_sprites[0];

        if (curLvl > 10) origin.sprite = Bg_sprites[2];
        if (curLvl > 15) origin.sprite = Bg_sprites[3];
        if (curLvl > 20) origin.sprite = Bg_sprites[4];
    }
    private void Awake()
    {
        scope = FindObjectOfType<Scope>();
        Time.timeScale = 1;
    }
    public void ToNextLvl()
    {
        PlayerPrefs.SetInt("lvl", PlayerPrefs.GetInt("lvl", 0) + 1);
        ToScene("Game");
    }
    public void ToScene(string scene_name) => UnityEngine.SceneManagement.SceneManager.LoadScene(scene_name);
    public void OnPaused()
    {
        pausedController = !pausedController;
        if(pausedController)
        {
            paused.SetActive(true);
            Time.timeScale = 0;
            scope.enabled = false;
        }
        else
        {
            paused.SetActive(false);
            Time.timeScale = 1;
            scope.enabled = true;
        }
    }
}
