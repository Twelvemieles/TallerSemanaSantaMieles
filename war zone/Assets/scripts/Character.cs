using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour, ICharacter {

    [SerializeField]
    private GameObject canvasPlayer;
    [SerializeField]
    protected Mananger mananger;
    public GameObject CanvasPlayer
    {
        get
        {
            return canvasPlayer;
        }

        set
        {
            canvasPlayer = value;
        }
    }

    private bool myTurn;
    public bool MyTurn
    {
        get
        {
            return myTurn;
        }

        set
        {
            myTurn = value;
        }
    }
    [SerializeField]
    private Text LifeText;
    [SerializeField]
    private Text gunText;
    private int vida = 3;


    protected int Vida
    {
        get
        {
            return vida;
        }

        set
        {
            vida = value;
        }
    }
    //disparar
    [SerializeField]
    private int shootType;
    // 1 = misil
    // 2 = shootgun
    // 3 = granade
    public int ShootType
    {
        get
        {
            return shootType;
        }

        set
        {
            shootType = value;
        }
    }



    [SerializeField]
    private Transform respawn;
    [SerializeField]
    private GameObject proyectil;


    //puntos máximos del shootGun
    [SerializeField]
    private Transform shootgunPoint1;
    [SerializeField]
    private Transform shootgunPoint2;
    [SerializeField]
    private Transform shootgunPoint3;

    [SerializeField]
    private float force;




    private float secondsCounter = 0;
    private float secondsToCount = 1;

    private bool disparo;





    // Use this for initialization
    protected void Start () {
        
            CanvasPlayer.SetActive(MyTurn);
       
            
        
        if (force == 0) force = 5;
        LifeText.text = "" + vida;
        

    }
	
	// Update is called once per frame
	protected void Update () {

        //cambio de arma
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShootType = 1;
            gunText.text = "misil";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShootType = 2;
            gunText.text = "shotgun";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShootType = 3;
            gunText.text = "granade";
        }



        if (disparo)
        {
            secondsCounter += Time.deltaTime;
            if (secondsCounter >= secondsToCount)
            {
                secondsCounter = 0;
                EndTurn();
                disparo = false;
            }
        }
        //movimiento platformer
        if (MyTurn == true)
        {

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 4f;

            transform.Translate(x, 0, 0);
            if (Input.GetButtonUp("Jump"))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
            }

           
                //dispara
                if (Input.GetMouseButtonUp  (0))
                {
               
                   
                    
             
                    Disparar(shootType);
                    
                disparo = true;
                
                }

            

        }
        

        if (Vida == 0)
        {
            Morir();
        }
	}
  

    public virtual void Disparar(int shootType)
    {
        
        switch (ShootType)
        {
            

            //misil
            case 1:
                var bullet = Instantiate(proyectil, respawn.position,respawn.rotation);

                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.right * force * 5f, ForceMode.Impulse );

                
                break;


                //shootGun
            case 2:
                
                var bullet1 = Instantiate(proyectil, shootgunPoint1.position, shootgunPoint1.rotation);
                bullet1.GetComponent<Rigidbody>().AddForce(bullet1.transform.right * force *2f, ForceMode.Impulse);

                var bullet2 = Instantiate(proyectil, shootgunPoint2.position, shootgunPoint2.rotation);
                bullet2.GetComponent<Rigidbody>().AddForce(bullet2.transform.right * force * 2f , ForceMode.Impulse);

                var bullet3 = Instantiate(proyectil, shootgunPoint3.position, shootgunPoint3.rotation);
                bullet3.GetComponent<Rigidbody>().AddForce(bullet3.transform.right * force * 2f , ForceMode.Impulse);

                
                break;


                //granade
            default:
                var bullet4 = Instantiate(proyectil, respawn.position, respawn.rotation);

                bullet4.GetComponent<Rigidbody>().AddForce(bullet4.transform.right * force, ForceMode.Impulse);

                break;
        }

        
    }

    public virtual void Morir()
    {
        Destroy(gameObject);
    }

    public virtual void PerderVida(int damage)
    {
        Vida -= damage;
        LifeText.text = "" + vida;
    }
    public virtual void EndTurn()
    {
        MyTurn = false;
        CanvasPlayer.SetActive(false);
        mananger.Turneador();

    }
}
