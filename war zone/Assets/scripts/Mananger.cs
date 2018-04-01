using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mananger : MonoBehaviour {
   
    public static Mananger Instance { get; private set; }

    public int Value;
    
    private bool turnoTeam ;
    private int turnoPlayer ;


    [SerializeField]
    private List<GameObject> red;
    [SerializeField]
    private List<GameObject> blue;
    


    public void Turneador()
    {
         bool puede = true;
        if (turnoTeam == false)
        {
            
            turnoTeam = false;
        }
         if (turnoPlayer == 4 )
        {
               turnoPlayer = 0;
        }
        Debug.Log("equipo" + turnoTeam);
        Debug.Log("player" + turnoPlayer);


        if (turnoTeam == false && puede == true)
        {

            
            Character player1 = blue[turnoPlayer].transform.GetComponent<Character>();
            if (player1 != null)
            {
                player1.MyTurn = true;
                player1.CanvasPlayer.SetActive(true);
                turnoTeam = true;
                puede = false;
            }

               else
               {
                Debug.Log("no hay player"+ turnoPlayer);
                turnoTeam = false;
                Turneador();
                turnoPlayer++;
            }
           
        }
        if (turnoTeam == true && puede == true)
        {
            
            Character player = red[turnoPlayer].transform.GetComponent<Character>();
            if (player != null)
            {
                player.MyTurn = true;
                player.CanvasPlayer.SetActive(true);
                turnoTeam = false;
                puede = false;
            }
              else
             {
                Debug.Log("no hay player" + turnoPlayer);
                turnoTeam = true;
                Turneador();
              }
            turnoPlayer++;

        }
    }


   
    private void FixedUpdate()
   {
       //eliminar de la lista
        for (var i = red.Count - 1; i > -1; i--)
        {
           if (red[i] == null)
                red.RemoveAt(i);
     }
    for (var i = blue.Count - 1; i > -1; i--)
       {
         if (blue[i] == null)
             blue.RemoveAt(i);
       }
    }
    void Awake () {

        //singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        turnoTeam = false;
        turnoPlayer = 0;
    
        Turneador();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("equipo" + turnoTeam);
            Debug.Log("player" + turnoPlayer);
        }


    }
}


