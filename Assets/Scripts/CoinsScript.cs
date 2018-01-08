//Скрипт для отработки механики монет. Вешается на игрока

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour {

    public static int score = 0;
    public GameObject[] coinPrefabs;
    //Список всех существующих в игре шариков для того чтобы собирать
    List<GameObject> coins;
    
  //  private float coinSpawnY = 7.8f;

    // Use this for initialization
    void Start () {
        coins = new List<GameObject>();
        spawnCoin();
        spawnCoin();

    }
	
	// Update is called once per frame
	void Update () {

        //Двигаем итемы вместе с дорогой
        for(int i = 0; i < coins.Count; i++)
        {
            var coin = coins[i];
            coin.transform.position = new Vector3(coin.transform.position.x, coin.transform.position.y - (terrainMove.speed * Time.deltaTime), coin.gameObject.transform.position.z);
            if (coin.transform.position.y < -5f)
            {
                coins.Remove(coin);
                Destroy(coin);
                spawnCoin();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      //  Debug.Log(other.name + " ent" + " " + this.tag);
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Coin")
        {
            //coins.Remove(other.gameObject);
            //  Destroy(other.gameObject);
        }
    }
    //Спавнит один из префабов из coinPrefabs в случайной точке на экране по заданным координатам
    void spawnCoin()
    {
        System.Random rnd = new System.Random();
        //Получаем случайные индексы
      //  float x = ((float)rnd.Next(54) / 10f) - 2.7f;
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(6f, 15f);
        int indx = rnd.Next(coinPrefabs.Length);
        //Спавним случайный объект в случайном месте
        GameObject clone = Instantiate(coinPrefabs[indx], new Vector3(x, y, -0.5f), Quaternion.identity);
        Color col = randomColor();
        Material mat = new Material(Shader.Find("Diffuse"));
        mat.color = col;
        clone.GetComponent<Renderer>().material = mat;

        coins.Add(clone);
        //
    }

    Color randomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color col = new Color(r, g, b,1);
        return col;
    }
}
