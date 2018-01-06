//Скрипт для отработки механики монет. Вешается на игрока

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {

    public static int score = 0;
    public GameObject[] coinPrefabs;
    //Список всех существующих в игре шариков для того чтобы собирать
    List<GameObject> coins;

    private float coinSpawnY = 7.8f;

    // Use this for initialization
    void Start () {
        coins = new List<GameObject>();
        spawnCoin();
    }
	
	// Update is called once per frame
	void Update () {

        //Двигаем итемы вместе с дорогой
        for(int i = 0; i < coins.Count; i++)
        {
            var coin = coins[i];
            coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y - (terrainMove.speed * Time.deltaTime), coin.gameObject.transform.position.z);
            //Если монетку не собрали и она ушла вниз за камеру, то удаляем её
            if(coin.transform.position.y < -5.5f)
            {
                coins.Remove(coin);
                Destroy(coin);
                i--;
                spawnCoin();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " ent" + " " + this.tag);
    }

    //Спавнит один из префабов из coinPrefabs в случайной точке на экране по заданным координатам
    void spawnCoin()
    {
        System.Random rnd = new System.Random();
        //Получаем случайные индексы
        float x = ((float)rnd.Next(54) / 10f) - 2.7f;
        int indx = rnd.Next(coinPrefabs.Length);
        //Спавним случайный объект в случайном месте
        coins.Add(Instantiate(coinPrefabs[indx], new Vector3(x, coinSpawnY, -0.5f), Quaternion.identity));
    }
}
