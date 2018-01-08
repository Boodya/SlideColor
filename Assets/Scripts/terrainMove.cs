using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт отвечает за движение дорог
public class terrainMove : MonoBehaviour
{
    public static float  speed = 3.5f;
    float y = 0;
    
    void Start ()
    {
        y = gameObject.transform.position.y; //начальное положение дороги по y
    }
	
	// Update is called once per frame
	void Update ()
    {   //двигаем дорогу плавным образом вниз
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y-=(speed*Time.deltaTime), gameObject.transform.position.z);
	}
}
