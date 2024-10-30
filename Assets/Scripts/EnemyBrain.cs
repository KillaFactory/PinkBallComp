using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;

    [SerializeField] private Transform rotatorEnemyBrain;

    private MoneyObject[] moneys;
    public MoneyObject targetMoney;

    public bool isStartWork;

    private bool isMove, waiter;
    private void Awake()
    {
        StartCoroutine(timerer());
        IEnumerator timerer()
        {
            yield return new WaitForSeconds(2.5f);
            isStartWork = true;
        }
    }
    private void Update()
    {
        if (!isStartWork) return;

        rotatorEnemyBrain.position = playerController.transform.position;
        if(!targetMoney)
        {
            targetMoney = FindNearest(FindObjectsOfType<MoneyObject>());
        }
        else if(!isMove && targetMoney && !waiter)
        {
            waiter = true;
            isMove = true;
            StartCoroutine(moveTimer());
            Vector3 direction = targetMoney.transform.position - rotatorEnemyBrain.position;
            direction.z = 0; 

            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                rotatorEnemyBrain.rotation = rotation;
            }
        }
        if (isMove)
        {
            playerController.Move(rotatorEnemyBrain.transform.up * 6f * Time.deltaTime);
        }
    }
    private IEnumerator moveTimer()
    {
        yield return new WaitForSeconds(0.3f);
        isMove = false;
        yield return new WaitForSeconds(Random.Range(2f, 6f));
        waiter = false;
    }
    public MoneyObject FindNearest(MoneyObject[] moneys)
    {
        MoneyObject handler = null;
        float distance = Mathf.Infinity;
        foreach(MoneyObject el in moneys)
        {
            if(Vector2.Distance(el.transform.position, this.transform.position) < distance)
            {
                handler = el;
                distance = Vector2.Distance(el.transform.position, this.transform.position);
            }
        }
        if (handler) return handler;
        else return null;
    }
}
