using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playGames : MonoBehaviour
{

    public Text displayed;
    public string Instructions;
    public int players = 0;
    public GameObject intro;
    public GameObject field;
    public GameObject field3;
    public GameObject field4;
    public bool makeMove = false;
    public int[] Field;

    public Texture one;
    public Texture two;
    public Texture three;
    public Texture four;
    public Texture five;
    public Texture six;
    public Texture seven;
    public Texture eight;
    public Texture nine;
    public Texture ten;
    public Texture eleven;
    public Texture twelve;
    public Texture thirteen;
    public Texture fourteen;
    public Texture fifthteen;
    public Texture none;

    bool isSetup;
    int winner;
    int player;

    // Use this for initialization
    public void Start()
    {

        intro = GameObject.FindGameObjectWithTag("Intro");
        field = GameObject.FindGameObjectWithTag("Field");
        field3 = GameObject.FindGameObjectWithTag("3field");
        field4 = GameObject.FindGameObjectWithTag("4field");
        Instructions = "(pay 1) flip any card on the field face up\n(pay 2) peak at any face down card " +
                "and leave it face down\n(pay 3) discard any card in any player's hand\n(gain 1) let your opponent peak at any 3 face down cards\n" +
                "(gain 2) let your opponent peak at any 5 face down cards\n(gain 4) reveal your card to your opponent\n (free) chose any card on the " +
                "field to be your card in battle\n(free) surrender; no defense but opponent does not gain resources\n(free) ready for battle; gain 3 if" +
                " you win battle\n (payment varies) battle; pay the value of your card to attack\n";
        displayed.text = "Hello, welcome to Saltline! The game where players\nuse limited resources to deplete their opponent's even more \nlimited health. So how many players this time?";
        isSetup = false;
        winner = 0;
        player = 0;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (players != 0 && !isSetup)
        {
            
            displayed.text = "Great, " + players + " players today!";
            isSetup = true;
            intro.SetActive(false);
      
            if (players == 2) {
                field3.SetActive(false);
                field4.SetActive(false);
            }
            if (players == 3) { field4.SetActive(false); }
            field.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }

        if (players != 0 && winner == 0)
        {
            player++;
            if (player > players) { player = 1; }
            startRound(player, players);
            winner = -1;
        }
       
    }

    void startRound(int firstPlayer, int totalPlayers)
    {
        //bool ready = false;
        int totalCards = 3 * totalPlayers + 3;
        int numCards = totalCards - 2;
        List<int> candidates = new List<int>();
        Field = new int[numCards];
        System.Random rand = new System.Random();

        for (int i = 1; i <= totalCards; i++)
        {
            candidates.Add(i);
        }

        for (int j = 0; j < numCards; j++)
        {
            int numChosen = candidates[rand.Next(0, candidates.Count)];
            Field[j] = numChosen;
            //Debug.Log(Field[j]);
            candidates.Remove(numChosen);
        }

        makeMove = true;

        //while (!ready) { }
    }
}
