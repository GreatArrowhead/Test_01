using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    [SerializeField]
    GameObject coinPrefab;

    [SerializeField]
    Slider coinCountSlider;

    float coinCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < coinCount; i++)
        {
            SpawnCoin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCoin()
    {
        coinCount = coinCountSlider.value;
        for (int i = 0; i < coinCount; i++)
        {
            Instantiate(coinPrefab, new Vector3(
            Random.Range(-20, 20), 1, Random.Range(-20, 20)), Quaternion.identity);
        }
    }

}
