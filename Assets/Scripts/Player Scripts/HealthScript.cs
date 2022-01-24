using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour {

    private EnemyAnimator enemy_Anim;
    private NavMeshAgent navAgent;
    private EnemyController enemy_Controller;

    public float health = 100f;

    public bool is_Player, is_Soldier;

    private bool is_Dead;

    private EnemyAudio enemyAudio;

	void Awake () {
        
        if(is_Soldier) {
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navAgent = GetComponent<NavMeshAgent>();

            // get enemy audio
            enemyAudio = GetComponentInChildren<EnemyAudio>();
        }
	}

    private void Start()
    {
        is_Dead = false;
        health = 100f;

    }

    public void ApplyDamage(float damage) {
        
        if (is_Dead)
            return;

        //health -= damage;

        if(is_Player) {
            gameObject.GetComponent<PlayerStatsUpdate>().Display_HealthStats(health);
        }

        if(is_Soldier) {
            if(enemy_Controller.Enemy_State == EnemyState.PATROL) {
                enemy_Controller.chase_Distance = 50f;
            }

            health -= damage;
            Debug.Log("Enemy health: " + health);
        }

        if(health <= 0f) {
            Debug.Log("DEAD");

            PlayerDied();

            is_Dead = true;
        }

    } // apply damage

    void PlayerDied() {
        if(is_Soldier) {

            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 15f);

            enemy_Controller.enabled = false;
            navAgent.enabled = false;
            enemy_Anim.enabled = false;

            enemy_Anim.Dead();

            StartCoroutine(DeadSound());
        }

        if(is_Player) {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag(_Tags.ENEMY_TAG);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            //GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
            Debug.Log("Player Died");
            //SceneManager.LoadScene(2);
        }

        if(tag == _Tags.PLAYER_TAG) {

            Debug.Log("Player Died");
            SceneManager.LoadScene(2);

        }
        else {

            Invoke("TurnOffGameObject", 3f);

        }

    } // player died

    void RestartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    void TurnOffGameObject() {
        gameObject.SetActive(false);
    }

    IEnumerator DeadSound() {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.Play_DeadSound();
    }

} // class









































