using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class FaceUpCard : MonoBehaviour
    {
        private static Sprite[] cards;



        void Start()
        {

            cards = new Sprite[21];


            cards[0] = Resources.Load<Sprite>("blue_eyes");
            cards[1] = Resources.Load<Sprite>("dark_magician");
            cards[2] = Resources.Load<Sprite>("summoned_skull");
            cards[3] = Resources.Load<Sprite>("gaia");
            cards[4] = Resources.Load<Sprite>("obelisk");
            cards[5] = Resources.Load<Sprite>("neos");
            cards[6] = Resources.Load<Sprite>("ancient_gear_golem");
            cards[7] = Resources.Load<Sprite>("archfiend");
            cards[8] = Resources.Load<Sprite>("black_luster");
            cards[9] = Resources.Load<Sprite>("black_rose");
            cards[10] = Resources.Load<Sprite>("cyber_end");
            cards[11] = Resources.Load<Sprite>("d_magician_girl");
            cards[12] = Resources.Load<Sprite>("drill");
            cards[13] = Resources.Load<Sprite>("elemental_hero");
            cards[14] = Resources.Load<Sprite>("plasma");
            cards[15] = Resources.Load<Sprite>("rainbow_dragon");
            cards[16] = Resources.Load<Sprite>("red_eyes");
            cards[17] = Resources.Load<Sprite>("stardust");
            cards[18] = Resources.Load<Sprite>("utopia");
            cards[19] = Resources.Load<Sprite>("winged_dragon");
            cards[20] = Resources.Load<Sprite>("yubel");


            int random = UnityEngine.Random.Range(0, 21);
            while(googleSignIn.userdata[random] == true)
            {
                 random = UnityEngine.Random.Range(0, 21);
            }

            GetComponent<SpriteRenderer>().sprite = cards[random];
            googleSignIn.userdata[random] = true;

            Player player = new Player();
            RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
            {

                player = response;

                googleSignIn.locationdata[MilleniumItemManager.itemindex] = true;
                switch (MilleniumItemManager.itemindex)
                {
                    case 0: player.mlyny = true; break;
                    case 1: player.ukf = true; break;
                    case 2: player.marian = true; break;
                    case 3: player.kniznica = true; break;
                    case 4: player.amfiteater = true; break;
                    case 5: player.pyramida = true; break;
                    case 6: player.agro = true; break;
                    case 7: player.kalvaria = true; break;
                    case 8: player.hala = true; break;
                    case 9: player.tesco = true; break;
                    case 10: player.hidepark = true; break;
                    case 11: player.zaba = true; break;
                    case 12: player.kostol = true; break;
                    case 13: player.hotel = true; break;
                    case 14: player.mostna = true; break;
                    case 15: player.fontana = true; break;
                    case 16: player.hrad = true; break;
                    case 17: player.corgon = true; break;
                    case 18: player.lavicka = true; break;
                    case 19: player.epicure = true; break;
                    case 20: player.spu = true; break;
                }

                switch (random)
                {
                    case 0: FlipCard.obtained_card_string = "You've obtained Blue-Eyes White Dragon"; player.blue_acquired = true;  break;
                    case 1: FlipCard.obtained_card_string = "You've obtained Dark Magician"; player.dark_acquired = true;  break;
                    case 2: FlipCard.obtained_card_string = "You've obtained Summoned Skull"; player.skull_acquired = true;  break;
                    case 3: FlipCard.obtained_card_string = "You've obtained Gaia the Fierce Knight"; player.gaia_acquired = true;  break;
                    case 4: FlipCard.obtained_card_string = "You've obtained Obelisk the Tormentor"; player.obelisk_acquired = true;  break;
                    case 5: FlipCard.obtained_card_string = "You've obtained Elemental Hero Neos"; player.neos_acquired = true;  break;
                    case 6: FlipCard.obtained_card_string = "You've obtained Ancient Gear Golem"; player.golem_acquired = true;  break;
                    case 7: FlipCard.obtained_card_string = "You've obtained Red Dragon Archfiend"; player.archfiend = true;  break;
                    case 8: FlipCard.obtained_card_string = "You've obtained Black Luster Soldier"; player.black_luster = true;  break;
                    case 9: FlipCard.obtained_card_string = "You've obtained Black Rose Dragon"; player.black_rose = true;  break;
                    case 10: FlipCard.obtained_card_string = "You've obtained Cyber End Dragon"; player.cyber_end = true;  break;
                    case 11: FlipCard.obtained_card_string = "You've obtained Dark Magician Girl"; player.dark_magician_girl = true;  break;
                    case 12: FlipCard.obtained_card_string = "You've obtained Super Vehicroid Jumbo Drill"; player.drill = true;  break;
                    case 13: FlipCard.obtained_card_string = "You've obtained Elemental Hero Flame Wingman"; player.flame_wingman = true;  break;
                    case 14: FlipCard.obtained_card_string = "You've obtained Destiny Hero Plasma"; player.plasma = true;  break;
                    case 15: FlipCard.obtained_card_string = "You've obtained Rainbow Dragon"; player.rainbow_dragon = true;  break;
                    case 16: FlipCard.obtained_card_string = "You've obtained Red-Eyes Black Dragon"; player.red_eyes = true;  break;
                    case 17: FlipCard.obtained_card_string = "You've obtained Stardust Spark Dragon"; player.stardust = true;  break;
                    case 18: FlipCard.obtained_card_string = "You've obtained Number 39: Utopia"; player.utopia = true;  break;
                    case 19: FlipCard.obtained_card_string = "You've obtained Winged Dragon of Ra"; player.ra_acquired = true;  break;
                    case 20: FlipCard.obtained_card_string = "You've obtained Yubel"; player.yubel_acquired = true;  break;

                }
                RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);


            });

    

     

         



            var bounds = GetComponent<SpriteRenderer>().sprite.bounds;
            transform.localScale = new Vector3(1.1f, 1.1f, 1);
        }



        



    }
}
