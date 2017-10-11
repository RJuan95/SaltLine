using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour {

    public int ID;
    public Material mat;
    GameObject var;
    playGames roundStuff;

    private void Start()
    {
        var = GameObject.FindGameObjectWithTag("Player");
        roundStuff = var.GetComponent<playGames>();
        mat.mainTexture = roundStuff.none;
    }
    void OnMouseDown()
    {
        if (gameObject.tag == "card" && roundStuff.makeMove) {
            int number = roundStuff.Field[ID];
            
            switch (number)
            {
                case 1: mat.mainTexture = roundStuff.one;
                    break;
                case 2:
                    mat.mainTexture = roundStuff.two;
                    break;
                case 3:
                    mat.mainTexture = roundStuff.three;
                    break;
                case 4:
                    mat.mainTexture = roundStuff.four;
                    break;
                case 5:
                    mat.mainTexture = roundStuff.five;
                    break;
                case 6:
                    mat.mainTexture = roundStuff.six;
                    break;
                case 7:
                    mat.mainTexture = roundStuff.seven;
                    break;
                case 8:
                    mat.mainTexture = roundStuff.eight;
                    break;
                case 9:
                    mat.mainTexture = roundStuff.nine;
                    break;
                case 10:
                    mat.mainTexture = roundStuff.ten;
                    break;
                case 11:
                    mat.mainTexture = roundStuff.eleven;
                    break;
                case 12:
                    mat.mainTexture = roundStuff.twelve;
                    break;
                case 13:
                    mat.mainTexture = roundStuff.thirteen;
                    break;
                case 14:
                    mat.mainTexture = roundStuff.fourteen;
                    break;
                case 15:
                    mat.mainTexture = roundStuff.fifthteen;
                    break;

            }

        }

    }
}
