using System;
using System.Collections;
using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    public float PlayerRotation;
    public float PlayerRotSpd = 100f;
    public float Playerhp = 10f;
    public float switchInTimerBuff;
    public GameObject Bullet;
    public float reloadtimer = 5;
    public int currentamo = 5;
    public int ammo = 10;
    public bool reloading = false;
    public GameObject Blade;
    public float Bladespeed = 1;
    public GameObject Forcefield;
    public float Mana;

    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;

    public enum playerclass
    {
        sharpshooter=0,
        martial=1,
        arcana=2,
    }
    //this is your current class stored in a variable
    public playerclass myClass;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, PlayerRotation);
        if (Input.GetKey(KeyCode.LeftArrow)) { PlayerRotation += PlayerRotSpd * Time.deltaTime; }
        if (Input.GetKey(KeyCode.RightArrow)) { PlayerRotation -= PlayerRotSpd * Time.deltaTime; }
        if (Playerhp <= 0) { Destroy(Player); }
        switchInTimerBuff-=Time.deltaTime;

        //keybinds for class change
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            SetClass(playerclass.sharpshooter);
            GetComponent<SpriteRenderer>().sprite = Sprite1;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SetClass(playerclass.martial);
            GetComponent<SpriteRenderer>().sprite = Sprite2;
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SetClass(playerclass.arcana);
            GetComponent<SpriteRenderer>().sprite = Sprite3;
        }

        switch (myClass) {
            case playerclass.sharpshooter:
                {
                    if ((Input.GetKeyDown(KeyCode.Space) && reloading == false))
                    {
                        if (currentamo > 0)
                        {
                            // up= "local up". Will go "forward" in its own direction.
                            // transform.rotation will just have it equal to the player's rotation
                            Instantiate(Bullet, transform.localPosition + transform.up, transform.rotation);
                            currentamo -= 1;
                            if (switchInTimerBuff >= 0) {
                                Instantiate(Bullet, transform.localPosition - transform.up, transform.rotation);
                                currentamo += 2;
                            }
                        }
                        else if (currentamo == 0 && !reloading)
                        {
                            StartCoroutine(Reload(reloadtimer));
                        }
                        else { Debug.Log("failed to fire, mid-reload"); }
                    }
                    break;
                }
            case playerclass.martial:
                {
                    Bladespeed-=Time.deltaTime;
                    if (Bladespeed <= -1)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            Instantiate(Blade, transform.localPosition + transform.up, transform.rotation);
                        }
                    }
                    break;
                }
            case playerclass.arcana:
                {
                    Mana += Time.deltaTime;
                    if (Input.GetKeyDown(KeyCode.Space)&&Mana>=2) {
                        Instantiate(Forcefield, transform.position, Quaternion.identity);
                        //instantiate Fireball/firezone
                        //NOTE: Should spawn fireball instead on down, forcefield should spawn on holding
                    }
                    
                    break;
                }
        }
    }

    public void SetClass(playerclass c)
    {
        //This code runs once when it starts/you enter the state
        if (myClass == c) { return; } //IF class is already C, STOP HERE and return

        //if c is a NEW class, let's update our myClass variable
        //THEN run conditonal checks and code to update the player as needed
        myClass = c;
        //ADD switch-in buffs
        if(myClass == playerclass.sharpshooter)
        {
            //run conditional code that changes the player into sharpshooter mode here
            //mySprite.color = sharpshooterColor;
            //myAnim.Play("SharpshooterIdle");
            //myAnim.SetBool("Sharpshooter", true);
            switchInTimerBuff = 5;
            
            
        }
        else if (myClass == playerclass.martial)
        {
            
        }
        else if (myClass == playerclass.arcana)
        {
            Instantiate(Forcefield, transform.position, Quaternion.identity);
        }
    }


    public IEnumerator Reload(float time)
    {
        reloading = true;
        Debug.Log("reloading... " + Time.time);
        //code above the yield return line will run ASAP when coroutine is called
        yield return new WaitForSeconds(time); //the computer will pause this function for TIME seconds
        reloading = false;
        currentamo = ammo;
        Debug.Log("finished reloading: " + Time.time);
        //code below the yield return line will run AFTER the TIME seconds are up
    }

    //Example: public function Reload(float X)
    //{
    //        reloading = true // this runs ASAP when we call this function
    //        ORDER: tell computer to wait for X seconds
    //        reloading = false // this runs after X seconds have been waited
    //yield return new WaitForFixedUpdate(); this will wait for the next update. There are other similar coroutines too
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject collidedObject = other.gameObject;
        if (collidedObject.CompareTag("Enemy"))
        {
            Playerhp -= 1;
        }
    }
}
