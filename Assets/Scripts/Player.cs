using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Player
{
    public string username;
    public string userid;


    public Boolean blue_acquired;
    public Boolean dark_acquired;
    public Boolean skull_acquired;
    public Boolean gaia_acquired;
    public Boolean obelisk_acquired;
    public Boolean neos_acquired;
    public Boolean golem_acquired;

    public Boolean archfiend;
    public Boolean black_luster;
    public Boolean black_rose;
    public Boolean cyber_end;
    public Boolean dark_magician_girl;
    public Boolean drill;
    public Boolean flame_wingman;
    public Boolean plasma;
    public Boolean rainbow_dragon;
    public Boolean red_eyes;
    public Boolean stardust;
    public Boolean utopia;


    public Boolean ra_acquired;
    public Boolean yubel_acquired;


    public Boolean mlyny;
    public Boolean ukf;
    public Boolean marian;
    public Boolean kniznica;
    public Boolean amfiteater;
    public Boolean pyramida;
    public Boolean agro;
    public Boolean kalvaria;
    public Boolean hala;
    public Boolean tesco;
    public Boolean hidepark;
    public Boolean zaba;
    public Boolean kostol;
    public Boolean hotel;
    public Boolean mostna;
    public Boolean fontana;
    public Boolean hrad;
    public Boolean corgon;
    public Boolean lavicka;
    public Boolean epicure;
    public Boolean spu;

    public int story_progress;




    public Player()
    {
        username = googleSignIn.username;
        userid = googleSignIn.userid;
        blue_acquired = false;
        dark_acquired = false;
        skull_acquired = false;
        gaia_acquired = false;
        obelisk_acquired = false;
        neos_acquired = false;
        golem_acquired = false;
        archfiend = false;
        black_luster = false;
        black_rose = false;
        cyber_end = false;
        dark_magician_girl = false;
        drill = false;
        flame_wingman = false;
        plasma = false;
        rainbow_dragon = false;
        red_eyes = false;
        stardust = false;
        utopia = false;
        ra_acquired = false;
        yubel_acquired = false;
        mlyny = false;
        ukf = false;
        marian = false;
        kniznica = false;
        amfiteater = false;
        pyramida = false;
        agro = false;
        kalvaria = false;
        hala = false;
        tesco = false;
        hidepark = false;
        zaba = false;
        kostol = false;
        hotel = false;
        mostna = false;
        fontana = false;
        hrad = false;
        corgon = false;
        lavicka = false;
        epicure = false;
        spu = false;

        story_progress = 0;
    }

   


    public void newCollection()
    {
        blue_acquired = false;
        dark_acquired = false;
        skull_acquired = false;
        gaia_acquired = false;
        obelisk_acquired = false;
        neos_acquired = false;
        golem_acquired = false;
        archfiend = false;
        black_luster = false;
        black_rose = false;
        cyber_end = false;
        dark_magician_girl = false;
        drill = false;
        flame_wingman = false;
        plasma = false;
        rainbow_dragon = false;
        red_eyes = false;
        stardust = false;
        utopia = false;
        ra_acquired = false;
        yubel_acquired = false;
    }


    



}
