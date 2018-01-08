using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour {

    public GameObject player;

	void Start ()
    {
        Vector3 pos = new Vector3(0f, -4f, -05f);
        //Instantiate(player, pos, Quaternion.identity);
	}

    // Update is called once per frame
    //void Update () {

    //}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name + " ent" + " " + this.tag);
        if (other.tag == "Coin")
        {
            Color coinColor = other.gameObject.GetComponent<Renderer>().sharedMaterial.color;
            Color playerColor = gameObject.GetComponent<Renderer>().sharedMaterial.color;
            Color col = colorSumm(playerColor, coinColor);
            Material mat = new Material(Shader.Find("Diffuse"));
            mat.color = col;
            gameObject.GetComponent<Renderer>().material = mat;
        }
    }

    Color colorSumm(Color playerColor, Color coinColor)
    {
        Color col = new Color();

        //  col = playerColor + coinColor;
        float PCR = playerColor.r;
        float PCG = playerColor.g;
        float PCB = playerColor.b;

        float CCR = coinColor.r;
        float CCG = coinColor.g;
        float CCB = coinColor.b;

        PCR = colorIntensivity(PCR);
        PCG = colorIntensivity(PCG);
        PCB = colorIntensivity(PCB);
        CCR = colorIntensivity(CCR);
        CCG = colorIntensivity(CCG);
        CCB = colorIntensivity(CCB);

        if (PCR != CCR)
            col.r = 0f;
        else col.r = 1f;

        if (PCG != CCG)
            col.g = 0f;
        else col.g = 1f;

        if (PCB != CCB)
            col.b = 0f;
        else col.b = 1f;

        return col;
    }

    float colorIntensivity(float i)
    {
        if (i > 0.5f)
            return 1f;
        else return 0f;
    }
}
