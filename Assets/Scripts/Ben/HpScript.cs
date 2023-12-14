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

    private void Update()
    {
        if (enemyHp >= 100)
        {
            enemyHp = 100;
            this.GetComponent<GameEndEvents>().GameEnd("You Win!");
        }
        if (houseHp >= 100)
        {
            houseHp = 100;
            this.GetComponent<GameEndEvents>().GameEnd("You Lose.");
        }
    }

    // ------- Enemy hp -------

    public void hitByte()
    {
        audioSrc.clip = goodByteHit;
        audioSrc.Play();
        enemyHp += 1;
        if (enemyHp >= 100) { enemyHp = 100; }
        enemyHpTxt.text = enemyHp + "%";
    }
    public void hitKilo()
    {
        audioSrc.clip = goodKiloHit;
        audioSrc.Play();
        enemyHp += 5;
        if (enemyHp >= 100) { enemyHp = 100; }
        enemyHpTxt.text = enemyHp + "%";
    }
    public void hitMega()
    {
        audioSrc.clip = goodMegaHit;
        audioSrc.Play();
        enemyHp += 10;
        if (enemyHp >= 100) { enemyHp = 100; }
        enemyHpTxt.text = enemyHp + "%";
    }
    public void hitGiga()
    {
        audioSrc.clip = goodGigaHit;
        audioSrc.Play();
        enemyHp += 20;
        if (enemyHp >= 100) { enemyHp = 100; }
        enemyHpTxt.text = enemyHp + "%";
    }

    // ------ House hp -------

    public void byteDamage()
    {
        audioSrc.clip = byteHit;
        audioSrc.Play();
        houseHp += 1;
        if (houseHp >= 100) { houseHp = 100; }
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
    public void kiloDamage()
    {
        audioSrc.clip = kiloHit;
        audioSrc.Play();
        houseHp += 5;
        if (houseHp >= 100) { houseHp = 100; }
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
    public void megaDamage()
    {
        audioSrc.clip = megaHit;
        audioSrc.Play();
        houseHp += 10;
        if (houseHp >= 100) { houseHp = 100; }
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
    public void gigaDamage()
    {
        audioSrc.clip = gigaHit;
        audioSrc.Play();
        houseHp += 20;
        if (houseHp >= 100) { houseHp = 100; }
        houseHpTxt.text = "Install: " + houseHp + "%";
    }
}
