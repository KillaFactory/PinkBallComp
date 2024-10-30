using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObject : MonoBehaviour
{
    private EnemyBrain enemyBrain;
    private Player player;
    [SerializeField] private Animator animation;
    private bool isDefead;
    private void Awake()
    {
        enemyBrain = FindObjectOfType<EnemyBrain>();

        player = FindObjectOfType<Player>();
    }
    private void LateUpdate()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < 0.4f && !isDefead)
        {
            isDefead = true;

            StartCoroutine(timer());
            IEnumerator timer()
            {
                animation.enabled = true;
                yield return new WaitForSeconds(2f);
                Destroy(this.gameObject);

                MoneyObject[] moneys = FindObjectsOfType<MoneyObject>();
                Scope.ScoreValue = 0;
                for (int i = 0; i < moneys.Length; i += 1)
                {
                    Destroy(moneys[i].gameObject);
                }
            }
        }
        if (Vector2.Distance(this.transform.position, enemyBrain.transform.position) < 0.4f && !isDefead)
        {
            isDefead = true;

            StartCoroutine(timer3());
            IEnumerator timer3()
            {
                animation.enabled = true;
                yield return new WaitForSeconds(2f);
                Destroy(this.gameObject);
            }
        }
    }
}
