using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlContentController : MonoBehaviour
{
    public List<LVL_ButtonController> buttons;
    [SerializeField] private Sprite noStars;
    private void Awake()
    {
        for(int i = 0; i < buttons.Count; i += 1)
        {
            if (PlayerPrefs.GetInt("MX", 0) >= i) buttons[i].blocker.SetActive(false);
            if(i + 1 > PlayerPrefs.GetInt("MX", 0))
            {
                buttons[i].origin.sprite = noStars;
            }
        }
    }
    public void OnStartLvl(int num)
    {
        PlayerPrefs.SetInt("lvl", num);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
