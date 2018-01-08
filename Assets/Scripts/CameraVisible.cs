using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//скрипт отвечает за перерисовку дороги и все что связано с дорогой
public class CameraVisible : MonoBehaviour {

    //два объекта итеративно меняющие друг друга для движения
    public GameObject[] trrains;
    //позиция верхнего объекта, для того чтобы после удаления нижнего создать на месте верхнего новый объект
    private Vector3 trrain1Pos;
	void Start ()
    {
        //при старте иницализируем две первых дороги жестко задавая их позиции
        Vector3 trr0Pos = new Vector3(0f, 11.26f, 0f);
        Vector3 trr1Pos = new Vector3(0f, 0f, 0f);
        //
        //создаем дороги в жестко заданных позициях
        Instantiate(trrains[0], trr0Pos, Quaternion.identity);
        Instantiate(trrains[1], trr1Pos, Quaternion.identity);
        trrain1Pos = trr0Pos;
    }
	
	// Update is called once pr frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name+" ent");
    }
    private void OnTriggerExit(Collider other)
    {
        //когда нижняя дорога выходит за пределы камеры, в данном случаи объекта map, то создаем на позиции верхнего объекта новую дорогу, а тот который вышел удаляем
        Instantiate(other.gameObject, trrain1Pos,Quaternion.identity);
        Destroy(other.gameObject);
        //
    
    }
}
