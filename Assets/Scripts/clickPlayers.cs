using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickPlayers : MonoBehaviour {

    public GameObject playerID;
    GameObject var;

	void OnMouseDown()
    {
        var = GameObject.FindGameObjectWithTag("Player");
        playGames numPlayers = var.GetComponent<playGames>();

        if (playerID.tag == "2players") { numPlayers.players = 2; }
        else if (playerID.tag == "3players") { numPlayers.players = 3; }
        else if (playerID.tag == "4players") { numPlayers.players = 4; }
        else { numPlayers.players = 0; }

    }
}
