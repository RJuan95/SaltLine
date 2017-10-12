using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCard : MonoBehaviour {

    public int ID;
    public Material mat;
    GameObject var;
    GameObject Peak;
    GameObject Pick;
    GameObject Next;
    playGames roundStuff;
    FlipCard peakStuff;
    FlipCard pickStuff;
    FlipCard nextStuff;
    public int player = 0;
    int index;
    int number;
    public bool check = false;
    public bool take = false;
    public Text p;

    private void Start()
    {
        var = GameObject.FindGameObjectWithTag("Player");
        Peak = GameObject.FindGameObjectWithTag("RevealOne");
        Pick = GameObject.FindGameObjectWithTag("Pick");
        Next = GameObject.FindGameObjectWithTag("Regain");
        roundStuff = var.GetComponent<playGames>();
        peakStuff = Peak.GetComponent<FlipCard>();
        pickStuff = Pick.GetComponent<FlipCard>();
        nextStuff = Next.GetComponent<FlipCard>();
        if (ID >= 0) { mat.mainTexture = roundStuff.none; }
        p.text = "";
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "card" && peakStuff.check)
        {
            number = roundStuff.Field[ID];
            index = ID;
            if (1==1)
            {
                switch (number)
                {
                    case 1:
                        mat.mainTexture = roundStuff.one;
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
            peakStuff.check = false;
            nextPlayer();
            if (player == 1) { roundStuff.r1[index] = true; }
            if (player == 2) { roundStuff.r2[index] = true; }
            if (player == 3) { roundStuff.r3[index] = true; }
            if (player == 4) { roundStuff.r4[index] = true; }

        }

        if (gameObject.tag == "card" && pickStuff.take) {
            if (roundStuff.r[ID] == false)
            {
                number = roundStuff.Field[ID];
                index = ID;
                switch (nextStuff.player)
                {
                    case 1:
                        roundStuff.P1.z = number;
                        roundStuff.p1.text = "player 1:\nHP: " + roundStuff.P1.x + "\nRP: " + roundStuff.P1.y + "\nStr: " + roundStuff.P1.z;
                        break;
                    case 2:
                        roundStuff.P2.z = number;
                        roundStuff.p2.text = "player 2:\nHP: " + roundStuff.P2.x + "\nRP: " + roundStuff.P2.y + "\nStr: " + roundStuff.P2.z;
                        break;
                    case 3:
                        roundStuff.P3.z = number;
                        roundStuff.p3.text = "player 3:\nHP: " + roundStuff.P3.x + "\nRP: " + roundStuff.P3.y + "\nStr: " + roundStuff.P3.z;
                        break;
                    case 4:
                        roundStuff.P4.z = number;
                        roundStuff.p4.text = "player 4:\nHP: " + roundStuff.P4.x + "\nRP: " + roundStuff.P4.y + "\nStr: " + roundStuff.P4.z;
                        break;
                }
                pickStuff.take = false;
                nextPlayer();
                roundStuff.r[ID] = true;
            }
        }

        if (gameObject.tag == "Regain") {
            switch (nextStuff.player)
            {
                case 1:
                    roundStuff.P1.y++;
                    roundStuff.p1.text = "player 1:\nHP: " + roundStuff.P1.x + "\nRP: " + roundStuff.P1.y;
                    break;
                case 2:
                    roundStuff.P2.y++;
                    roundStuff.p2.text = "player 2:\nHP: " + roundStuff.P2.x + "\nRP: " + roundStuff.P2.y;
                    break;
                case 3:
                    roundStuff.P3.y++;
                    roundStuff.p3.text = "player 3:\nHP: " + roundStuff.P3.x + "\nRP: " + roundStuff.P3.y;
                    break;
                case 4:
                    roundStuff.P4.y++;
                    roundStuff.p4.text = "player 4:\nHP: " + roundStuff.P4.x + "\nRP: " + roundStuff.P4.y;
                    break;
            }
            nextPlayer();
        }
        else if (gameObject.tag == "RevealOne")
        {
            switch (nextStuff.player)
            {
                case 1:
                    roundStuff.P1.y = roundStuff.P1.y - 2;
                    check = true;
                    roundStuff.p1.text = "player 1:\nHP: " + roundStuff.P1.x + "\nRP: " + roundStuff.P1.y;
                    break;
                case 2:
                    roundStuff.P2.y = roundStuff.P2.y - 2;
                    check = true;
                    roundStuff.p2.text = "player 2:\nHP: " + roundStuff.P2.x + "\nRP: " + roundStuff.P2.y;
                    break;
                case 3:
                    roundStuff.P3.y = roundStuff.P3.y - 2;
                    check = true;
                    roundStuff.p3.text = "player 3:\nHP: " + roundStuff.P3.x + "\nRP: " + roundStuff.P3.y;
                    break;
                case 4:
                    roundStuff.P4.y = roundStuff.P4.y - 2;
                    check = true;
                    roundStuff.p4.text = "player 4:\nHP: " + roundStuff.P4.x + "\nRP: " + roundStuff.P4.y;
                    break;
            }
        }

        else if (gameObject.tag == "Pick") {
            take = true;
            
        }

    }
    private void nextPlayer()
    {
        nextStuff.player++;
        if (nextStuff.player > roundStuff.players) { nextStuff.player = 1; }
        if (nextStuff.player == 1 && (roundStuff.P1.x <= 0 || roundStuff.P1.z > 0)) { nextStuff.player = 2; }
        if (nextStuff.player == 2 && (roundStuff.P2.x <= 0 || roundStuff.P2.z > 0)) { nextStuff.player = 3; }
        if (nextStuff.player == 3 && (roundStuff.P3.x <= 0 || roundStuff.P3.z > 0)) { nextStuff.player = 4; }
        if (nextStuff.player == 4 && (roundStuff.P4.x <= 0 || roundStuff.P4.z > 0)) { nextStuff.player = 1; }

        if (nextStuff.player == 1) { p.text = "Player 1, your turn"; }
        else if (nextStuff.player == 2) { p.text = "Player 2, your turn"; }
        else if (nextStuff.player == 3) { p.text = "Player 3, your turn"; }
        else if (nextStuff.player == 4) { p.text = "Player 4, your turn"; }
    }
}
