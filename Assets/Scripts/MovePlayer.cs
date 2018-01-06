using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//скрипт отвечает за движение игрока
public class MovePlayer : MonoBehaviour {

    public Transform player; //положение игрока
    Vector3 mousePos; //поцизии мышки(касание пальца)
    public float speed = 20f;      // скорость игрока
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnMouseDrag()
    {   //получаем позиции мышки(качания пальца)
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //проверяем чтобы игрок не выходил за пределы зоны зона(2.7 до -2.7)
        if (mousePos.x > 2.7f)
            mousePos.x = 2.7f;
        if(mousePos.x < -2.7f)
            mousePos.x = -2.7f;
        //
        //устанавливаем позиции игроку плавным образом
        player.position = Vector3.MoveTowards(player.position, new Vector3(mousePos.x, player.position.y, player.position.z),speed*Time.deltaTime);
    }
}
