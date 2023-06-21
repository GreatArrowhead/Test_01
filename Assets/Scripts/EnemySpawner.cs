using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Material materialCustom;

    GameObject enemy;

    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Instantiate(enemyPrefab, new Vector3(3, 1, 4), Quaternion.identity, transform);
        enemy.transform.position = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            enemy.GetComponent<MeshRenderer>().material = materialCustom;

        //time += Time.deltaTime;

        //if (time > 1f)
        //{
        //    Instantiate(enemyPrefab, new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)),
        //        Quaternion.identity, transform);
        //    time = 0;
        //}
    }
}
