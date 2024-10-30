using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scope : MonoBehaviour
{
    [SerializeField] private SpriteRenderer origin;
    [SerializeField] private Sprite[] skins;

    [SerializeField] private GameObject WinObject, DefeadObject;

    [SerializeField] private GameObject ViewObject;
    [SerializeField] private Joystick controller;
    [SerializeField] private Transform player;

    [SerializeField] private GameObject[] lvls;

    public Text playerScore, enemyScore;
    public static int ScoreValue, ScoreValueEnemy;

    public bool rotateControlelr;

    public int Facor;

    [SerializeField] private CharacterController playerCharacterController;

    private bool isMove, waiter;
    public float SpeedRotation;

    public float SpeedForce;
    private void Awake()
    {
        ScoreValue = 0;
        ScoreValueEnemy = 0;

        SpeedForce = 8f;
        origin.sprite = skins[PlayerPrefs.GetInt("skin", 0)];
        foreach (GameObject el in lvls) el.SetActive(false);
        lvls[PlayerPrefs.GetInt("lvl", 0)].SetActive(true);
        Facor = 1;
    }
    private void Update()
    {
        if(FindObjectsOfType<MoneyObject>().Length <= 0)
        {
            if(ScoreValue >= ScoreValueEnemy)
            {
                WinObject.SetActive(true);
                PlayerPrefs.SetInt("M", ScoreValue + PlayerPrefs.GetInt("M", 0));

                if (PlayerPrefs.GetInt("lvl", 0) >= PlayerPrefs.GetInt("MX", 0)) PlayerPrefs.SetInt("MX", PlayerPrefs.GetInt("MX", 0) + 1);
            }
            else
            {
                DefeadObject.SetActive(true);
            }
            this.enabled = false;
        }
        if(!isMove)
        {
            if (!rotateControlelr)
            {
                this.transform.Rotate(new Vector3(0, 0, -SpeedRotation * Time.deltaTime));
            }
            else if (rotateControlelr)
            {
                this.transform.Rotate(new Vector3(0, 0, SpeedRotation * Time.deltaTime));
            }
        }
        if(isMove && SpeedForce > 0)
        {
            playerCharacterController.Move(this.transform.up * SpeedForce * Time.deltaTime);
            SpeedForce -= 15f * Time.deltaTime;
        }
        if(!isMove)
        {
            SpeedForce = 8f;
        }
        if(Input.GetMouseButtonUp(0) && !isMove && !waiter)
        {
            isMove = true;
            rotateControlelr = !rotateControlelr;
            ViewObject.SetActive(false);
            StartCoroutine(moveTimer());
           // player.transform.position
           
        }

        this.transform.position = player.transform.position;
    }
    private IEnumerator moveTimer()
    {
        waiter = true;
        yield return new WaitForSeconds(1f);
        isMove = false;
        yield return new WaitForSeconds(0.4f);
        ViewObject.SetActive(true);
        waiter = false;
    }

}
