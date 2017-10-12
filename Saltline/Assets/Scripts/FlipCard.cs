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
    public int player;
    int index;
    int number;
    int turn = 0;
    public bool check;
    public bool take;
    public Text p;
 
    int limit1;
    int limit2;
    int limit3;
    int limit4;

    private void Start()
    {
        check = false;
        take = false;
        var = GameObject.FindGameObjectWithTag("Player");
        Peak = GameObject.FindGameObjectWithTag("RevealOne");
        Pick = GameObject.FindGameObjectWithTag("Pick");
        Next = GameObject.FindGameObjectWithTag("Regain");
        roundStuff = var.GetComponent<playGames>();
        peakStuff = Peak.GetComponent<FlipCard>();
        pickStuff = Pick.GetComponent<FlipCard>();
        nextStuff = Next.GetComponent<FlipCard>();
        //if (ID >= 0) { mat.mainTexture = roundStuff.none; }
        if (roundStuff.P1.x > 0) { p.text = "Player 1, your turn"; nextStuff.player = 1; }
        else if (roundStuff.P2.x > 0) { p.text = "Player 2, your turn"; nextStuff.player = 2; }
        else if (roundStuff.P3.x > 0) { p.text = "Player 3, your turn"; nextStuff.player = 3; }
        else if (roundStuff.P4.x > 0) { p.text = "Player 4, your turn"; nextStuff.player = 4; }

        limit1 = 4;
        limit2 = 4;
        limit3 = 4;
        limit4 = 4;

        roundStuff.P1.z = 0;
        roundStuff.P2.z = 0;
        roundStuff.P3.z = 0;
        roundStuff.P4.z = 0;

        peakStuff.mat.color = Color.white;
        pickStuff.mat.color = Color.white;
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "card" && peakStuff.check)
        {
            number = roundStuff.Field[ID];
            index = ID;
            if (true)
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
            peakStuff.mat.color = Color.white;
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
                        mat.color = Color.red;
                        roundStuff.p1.text = "player 1:\nHP: " + roundStuff.P1.x + "\nCoins: " + roundStuff.P1.y + "\nReady!";
                        break;
                    case 2:
                        roundStuff.P2.z = number;
                        mat.color = Color.blue;
                        roundStuff.p2.text = "player 2:\nHP: " + roundStuff.P2.x + "\nCoins: " + roundStuff.P2.y + "\nReady!";
                        break;
                    case 3:
                        roundStuff.P3.z = number;
                        mat.color = Color.yellow;
                        roundStuff.p3.text = "player 3:\nHP: " + roundStuff.P3.x + "\nCoins: " + roundStuff.P3.y + "\nReady!";
                        break;
                    case 4:
                        roundStuff.P4.z = number;
                        mat.color = Color.green;
                        roundStuff.p4.text = "player 4:\nHP: " + roundStuff.P4.x + "\nCoins: " + roundStuff.P4.y + "\nReady!";
                        break;
                }
                pickStuff.take = false;
                roundStuff.r[ID] = true;
                pickStuff.mat.color = Color.white;
                nextPlayer();
            }
        }

        if (gameObject.tag == "Regain") {
            switch (nextStuff.player)
            {
                case 1:
                    if (limit1 > 0) { roundStuff.P1.y++; }
                    limit1--;
                    roundStuff.p1.text = "player 1:\nHP: " + roundStuff.P1.x + "\nCoins: " + roundStuff.P1.y;
                    break;
                case 2:
                    if (limit2 > 0) { roundStuff.P2.y++; }
                    limit2--;
                    roundStuff.p2.text = "player 2:\nHP: " + roundStuff.P2.x + "\nCoins: " + roundStuff.P2.y;
                    break;
                case 3:
                    if (limit3 > 0) { roundStuff.P3.y++; }
                    limit3--;
                    roundStuff.p3.text = "player 3:\nHP: " + roundStuff.P3.x + "\nCoins: " + roundStuff.P3.y;
                    break;
                case 4:
                    if (limit4 > 0) { roundStuff.P4.y++; }
                    limit4--;
                    roundStuff.p4.text = "player 4:\nHP: " + roundStuff.P4.x + "\nCoins: " + roundStuff.P4.y;
                    break;
            }
            nextPlayer();
        }
        else if (gameObject.tag == "RevealOne" && pickStuff.take == false)
        {
            switch (nextStuff.player)
            {
                case 1:
                    if (roundStuff.P1.y >= 2)
                    {
                        roundStuff.P1.y = roundStuff.P1.y - 2;
                        mat.color = Color.magenta;
                        check = true;
                    }
                    roundStuff.p1.text = "player 1:\nHP: " + roundStuff.P1.x + "\nCoins: " + roundStuff.P1.y;
                    break;
                case 2:
                    if (roundStuff.P2.y >= 2)
                    {
                        roundStuff.P2.y = roundStuff.P2.y - 2;
                        mat.color = Color.magenta;
                        check = true;
                    }
                    roundStuff.p2.text = "player 2:\nHP: " + roundStuff.P2.x + "\nCoins: " + roundStuff.P2.y;
                    break;
                case 3:
                    if (roundStuff.P3.y >= 2)
                    {
                        roundStuff.P3.y = roundStuff.P3.y - 2;
                        mat.color = Color.magenta;
                        check = true;
                    }
                    roundStuff.p3.text = "player 3:\nHP: " + roundStuff.P3.x + "\nCoins: " + roundStuff.P3.y;
                    break;
                case 4:
                    if (roundStuff.P4.y >= 2)
                    {
                        roundStuff.P4.y = roundStuff.P4.y - 2;
                        mat.color = Color.magenta;
                        check = true;
                    }
                    roundStuff.p4.text = "player 4:\nHP: " + roundStuff.P4.x + "\nCoins: " + roundStuff.P4.y;
                    break;
            }
        }

        else if (gameObject.tag == "Pick" && peakStuff.check == false) {
            take = true;
            mat.color = Color.magenta;
        }

    }

    private void nextPlayer()
    {
        //turn++;
        bool pd1 = false;
        bool pd2 = false;
        bool pd3 = false;
        bool pd4 = false;

        nextStuff.player++;
        if (nextStuff.player > roundStuff.players) { nextStuff.player = nextStuff.player - roundStuff.players; }
        if (nextStuff.player == 1 && (roundStuff.P1.x <= 0 || roundStuff.P1.z > 0)) {
            //turn++;
            nextStuff.player++;
            pd1 = true;
        }
        if (nextStuff.player == 2 && (roundStuff.P2.x <= 0 || roundStuff.P2.z > 0)) {
            //turn++;
            nextStuff.player++;
            pd2 = true;
        }
        if (nextStuff.player == 3 && (roundStuff.P3.x <= 0 || roundStuff.P3.z > 0)) {
            //turn++;
            nextStuff.player++;
            pd3 = true;
        }
        if (nextStuff.player == 4 && (roundStuff.P4.x <= 0 || roundStuff.P4.z > 0)) {
            //turn++;
            nextStuff.player++;
            pd4 = true;
        }
        if (nextStuff.player > roundStuff.players) { nextStuff.player = nextStuff.player - roundStuff.players; }
        if (nextStuff.player == 1 && (roundStuff.P1.x <= 0 || roundStuff.P1.z > 0))
        {
            //turn++;
            nextStuff.player++;
            pd1 = true;
        }
        if (nextStuff.player == 2 && (roundStuff.P2.x <= 0 || roundStuff.P2.z > 0))
        {
            //turn++;
            nextStuff.player++;
            pd2 = true;
        }
        if (nextStuff.player == 3 && (roundStuff.P3.x <= 0 || roundStuff.P3.z > 0))
        {
            //turn++;
            nextStuff.player++;
            pd3 = true;
        }
        if (nextStuff.player == 4 && (roundStuff.P4.x <= 0 || roundStuff.P4.z > 0))
        {
            //turn++;
            nextStuff.player++;
            pd4 = true;
        }
        if (nextStuff.player > roundStuff.players) { nextStuff.player = nextStuff.player - roundStuff.players; }

        if (nextStuff.player == 1) { p.text = "Player 1, your turn"; }
        else if (nextStuff.player == 2) { p.text = "Player 2, your turn"; }
        else if (nextStuff.player == 3) { p.text = "Player 3, your turn"; }
        else if (nextStuff.player == 4) { p.text = "Player 4, your turn"; }

        if (pd1 == true && pd2 == true && pd3 == true && pd4 == true) {
            if (roundStuff.P1.x > 0) { nextStuff.player = 1; }
            else if (roundStuff.P2.x > 0) { nextStuff.player = 2; }
            else if (roundStuff.P3.x > 0) { nextStuff.player = 3; }
            else if (roundStuff.P4.x > 0) { nextStuff.player = 4; }
            if (nextStuff.player == 1) { p.text = "Player 1, your turn"; }
            else if (nextStuff.player == 2) { p.text = "Player 2, your turn"; }
            else if (nextStuff.player == 3) { p.text = "Player 3, your turn"; }
            else if (nextStuff.player == 4) { p.text = "Player 4, your turn"; }
            for (int i = 0; i < roundStuff.r.Count; i++) { roundStuff.r[i] = false; }
            fight(roundStuff.P1.z, roundStuff.P2.z, roundStuff.P3.z, roundStuff.P4.z);
        }
    }

    private void fight(int v1, int v2, int v3, int v4) {
        int max = 0;
        int pay = 0;
        int counter = 0;
        int winner = 0;
        int[] values = new int[4];
        int[] health = new int[4];
        if (roundStuff.P1.y < v1) { v1 = 0; }
        if (roundStuff.P2.y < v2) { v2 = 0; }
        if (roundStuff.P3.y < v3) { v3 = 0; }
        if (roundStuff.P4.y < v4) { v4 = 0; }
        values[0] = v1;
        values[1] = v2;
        values[2] = v3;
        values[3] = v4;

        for (int i = 0; i < values.Length; i++) {
            if (values[i] > max) {
                max = values[i];
                pay = i + 1;
            }
        }
        switch (pay)
        {
            case 1:
                roundStuff.P1.y = roundStuff.P1.y - max;
                break;
            case 2:
                roundStuff.P2.y = roundStuff.P2.y - max;
                break;
            case 3:
                roundStuff.P3.y = roundStuff.P3.y - max;
                break;
            case 4:
                roundStuff.P4.y = roundStuff.P4.y - max;
                break;
        }
        roundStuff.P1.x = roundStuff.P1.x + v1 - max;
        roundStuff.P2.x = roundStuff.P2.x + v2 - max;
        roundStuff.P3.x = roundStuff.P3.x + v3 - max;
        roundStuff.P4.x = roundStuff.P4.x + v4 - max;

        health[0] = roundStuff.P1.x;
        health[1] = roundStuff.P2.x;
        health[2] = roundStuff.P3.x;
        health[3] = roundStuff.P4.x;

        for (int i = 0; i < health.Length; i++) {
            if (health[i] <= 0) {
                health[i] = 0;
                counter++;
            }
            else { winner = i + 1; }
        }
        if (health[0] > 0) { roundStuff.p1.text = "player 1:\nHP: " + roundStuff.P1.x + "\nCoins: " + roundStuff.P1.y; }
        else { roundStuff.p1.text = ""; }
        if (health[1] > 0) { roundStuff.p2.text = "player 2:\nHP: " + roundStuff.P2.x + "\nCoins: " + roundStuff.P2.y; }
        else { roundStuff.p2.text = ""; }
        if (health[2] > 0) { roundStuff.p3.text = "player 3:\nHP: " + roundStuff.P3.x + "\nCoins: " + roundStuff.P3.y; }
        else { roundStuff.p3.text = ""; }
        if (health[3] > 0) { roundStuff.p4.text = "player 4:\nHP: " + roundStuff.P4.x + "\nCoins: " + roundStuff.P4.y; }
        else { roundStuff.p4.text = ""; }
        if (counter >= 3)
        {
            p.text = "Congratulations player " + winner + "! You have won!";
        }
        else if (counter < 3)
        {
            roundStuff.startRound(roundStuff.players);
            roundStuff.resetCards();
            Start();
        }
        else { p.text = "Something has gone wrong :/"; }
    }
}
