using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    [SerializeField]
    private GameObject enemyPrefab;

    public Transform[] enemySpawnPoints;

    public int enemyCount;

    // Use this for initialization
    void Awake () {
        MakeInstance();
	}

    void Start() {
        enemyCount = enemyCount;

        SpawnEnemies();
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    void SpawnEnemies() {

        int index = 0;

        for (int i = 0; i < enemyCount; i++) {
            if (index >= enemySpawnPoints.Length) {
                index = 0;
            }

            Instantiate(enemyPrefab, enemySpawnPoints[index].position, Quaternion.identity);

            index++;
        }

        enemyCount = 0;
    }
} //     class


































