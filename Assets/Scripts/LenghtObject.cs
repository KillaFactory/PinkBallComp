using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LenghtObject : MonoBehaviour
{
    private EnemyBrain enemyBrain;
    private Player player;
    [SerializeField] private Animator animation;
    private bool isDefead;

    public bool isPlus;
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
            Scope scope = FindObjectOfType<Scope>();
            GameManager gamer = FindObjectOfType<GameManager>();
            if (isPlus)
            {
                gamer.ScopeEffevtRend.gameObject.SetActive(true);
                scope.SpeedRotation += scope.SpeedRotation / 2f;

                gamer.ScopeEffevtRend.color = gamer.green_color;
            }
            else
            {
                gamer.ScopeEffevtRend.gameObject.SetActive(true);
                scope.SpeedRotation -= scope.SpeedRotation / 2f;
                gamer.ScopeEffevtRend.color = gamer.red_color;
            }


            StartCoroutine(timer());
            IEnumerator timer()
            {
                animation.enabled = true;
                yield return new WaitForSeconds(2f);
                Destroy(this.gameObject);
            }
        }
        if (Vector2.Distance(this.transform.position, enemyBrain.transform.position) < 0.4f && !isDefead)
        {
            isDefead = true;

            StartCoroutine(timer5());
            IEnumerator timer5()
            {
                animation.enabled = true;
                yield return new WaitForSeconds(2f);
                Destroy(this.gameObject);
            }
        }
    }
}
