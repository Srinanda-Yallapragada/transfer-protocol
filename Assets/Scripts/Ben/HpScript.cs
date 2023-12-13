using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    public TextMeshPro enemyHpTxt;
    public TextMeshProUGUI houseHpTxt;
    private int enemyHp;
    private int houseHp;

    public AudioSource audioSrc;
    public AudioClip goodByteHit;
    public AudioClip goodKiloHit;
    public AudioClip goodMegaHit;
    public AudioClip goodGigaHit;

    public AudioClip byteHit;
    public AudioClip kiloHit;
    public AudioClip megaHit;
    public AudioClip gigaHit;

    // Start is called before the first frame update
    void Start()
    {
        enemyHpTxt.text = enemyHp + "%";
        houseHpTxt.text = "Install: " + houseHp + "%";
    }

    // ------- Enemy hp -------

    public void hitByte()
    {
        audioSrc.clip = goodByteHit;
        audioSrc.Play();
        enemyHp += 1;
        enemyHpTxt.text = enemyHp + "%";
    }
    public void hitKilo()
    {
        audioSrc.clip = goodKiloHit;
        audioSrc.Play();
        enemyHp += 5;
        enemyHpTxt.text = enemyHp + "%";
    }
    public void hitMega()
    {
        audioSrc.clip = goodMegaHit;
        audioSrc.Play();
        enemyHp += 10;
        enemyHpTxt.text = enemyHp + "%";
    }
    public void hitGiga()
    {
        audioSrc.clip = goodGigaHit;
        audioSrc.Play();
        enemyHp += 20;
        enemyHpTxt.text = enemyHp + "%";
    }

    // ------ House hp -------

    public void byteDamage()
    {
        audioSrc.clip = byteHit;
        audioSrc.Play();
        houseHp += 1;
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
    public void kiloDamage()
    {
        audioSrc.clip = kiloHit;
        audioSrc.Play();
        houseHp += 5;
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
    public void megaDamage()
    {
        audioSrc.clip = megaHit;
        audioSrc.Play();
        houseHp += 10;
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
    public void gigaDamage()
    {
        audioSrc.clip = gigaHit;
        audioSrc.Play();
        houseHp += 20;
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
}
