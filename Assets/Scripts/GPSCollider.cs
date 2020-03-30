using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GPSCollider : MonoBehaviour
{
    public Text info;

    void Start()
    {
        switch(MilleniumItemManager.itemindex)
        {

            case 0: info.text = "OC Mlyny je obchodné centrum v Starom meste v Nitre. Stojí medzi ulicami Štúrova, Štefánikova, Česko-slovenskej armády a Chalupkova. Je tu 126 obchodných jednotiek a spolu 28 500 m².";
                    break;
            case 1: info.text = "Predchodcom univerzity bol Pedagogický inštitút zriadený v Nitre v roku 1959."; break;
            case 2: info.text = "Toto vrcholnobarokové súsošie, najväčšie v meste, je situované na južnom svahu hradného kopca."; break;
            case 3: info.text = "Exteriér univerzitnej knižnice, pedagogickej fakulte a fakulte stredoeurópskych štúdií."; break;
            case 4: info.text = "Je to jeden z najväčších amfiteátrov na Slovensku. Objekt má výbornú polohu, akustiku, viditeľnosť i celkové riešenie. Jeho kapacita je 15 000 návštevníkov."; break;
            case 5: info.text = "Vysielač Zobor (556 m n. m.) je rádiový a televízny vysielač na Slovensku. Nachádza sa priamo nad mestom Nitra, na Pyramíde, predvrchole Zobora v pohorí Tribeč."; break;
            case 6: info.text = "Výstavný areál má celkovú rozlohu 143 ha, celková kapacita výstavného areálu je 90 906 m², krytá výstavná plocha v pavilónoch 40 906 m², voľná výstavná plocha 50 000 m²."; break;
            case 7: info.text = "Nitrianska kalvária je kalvária z prelomu 18. – 19. storočia, nachádzajúca sa na rovnomennom dominantnom skalnatom vrchu v juhovýchodnej časti mesta Nitra."; break;
            case 8: info.text = "Mestská hala Nitra je viacúčelová športová hala v Nitre. Nachádza na Dolnočermánskej ul. v Nitre. Bola otvorená v roku 2008."; break;
            case 9: info.text = "TESCO Je britský reťazec hypermarketov a obchodných domov. Spoločnosť je v súčasnosti najväčším obchodným reťazcom v Spojenom kráľovstve. Od roku 1996 pôsobí aj na Slovensku."; break;
            case 10: info.text = "Hidepark Nitra je nezávislé kultúrne centrum, ktoré je neziskovou a dobrovoľníckou iniciatívou."; break;
            case 11: info.text = "Vychádzkové chodníky sú usporiadané do hviezdy, v strede ktorej sa nachádza Žabia fontána s vodníkom Žblnkom"; break;
            case 12: info.text = "Kostol svätého Michala archanjela sa nachádza na skalnatom kopci nad Dražovcami, mestskou časťou Nitry. Je zasvätený svätému Michalovi archanjelovi"; break;
            case 13: info.text = "Hotel MIKADO ponúka pohodlie v pôsobivom, modernom interiéri s dôrazom na vysoký štandard služieb vo všetkých smeroch."; break;
            case 14: info.text = "Ulica je známa svojim čulým nočným životom. Na jednom mieste sa tu nachádza vyše 30 diskoték, krčiem, kaviarní, klubov, herní, fastfoodov či pubov."; break;
            case 15: info.text = "Na dne fontány je desať svetidiel, ktoré menia farby. Striekajúca voda je tak chvíľu červená, modrá, fialová, ružová, tyrkysová, zelená či žltá."; break;
            case 16: info.text = "Nitriansky hrad je zachovalý hradný komplex v Nitre. Nachádza sa na hradnom vrchu v centre mesta vo výške 220 m n. m., a vytvára výraznú dominantu mesta pod južnými výbežkami pohoria Tribeč. "; break;
            case 17: info.text = "Corgoň bol vraj kováčom v nitrianskom Hornom meste. Mal obrovskú silu a každý obdivoval jeho zavalitú postavu, zvlášť mohutné svaly na rukách."; break;
            case 18: info.text = "Môžete si zahrať Človeče nehnevaj sa, šach na Šachovej lavičke, oddýchnuť na Pohodlnej lavičke, zabicyklovať si na Cyklolavičke."; break;
            case 19: info.text = "Epicure znamená labužník, pôžitkár, rozkošník. Pôvod tohto slova je odvodený od starogréckeho filozofa Epikura. Jeho učenie bolo založené na rozumovom úsilí človeka dosiahnuť šťastie."; break;
            case 20: info.text = "Slovenská poľnohospodárska univerzita v Nitre (skr. SPU) so sídlom v Nitre je verejná vysoká škola univerzitného typu a svoj aktuálny názov nesie od roku 1996."; break;
        }
    }


    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.tag == "MilleniumItem")
                {
                    MilleniumPuzzle item = hit.transform.GetComponent<MilleniumPuzzle>();
                    SceneManager.LoadScene(4);
                }
            }
        }
    }
}
