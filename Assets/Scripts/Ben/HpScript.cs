using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    public Text enemyHp;
    private int enemyHpLevel;

    public AudioSource audioSrc;
    public AudioClip byteHit;
    public AudioClip kiloHit;
    public AudioClip megaHit;
    public AudioClip gigaHit;

    // Start is called before the first frame update
    void Start()
    {
        enemyHp.text = enemyHpLevel + "%";
    }

    public void hitByte()
    {
        audioSrc.clip = byteHit;
        audioSrc.Play();
        enemyHpLevel += 1;
        enemyHp.text = enemyHpLevel + "%";
    }
    public void hitKilo()
    {
        audioSrc.clip = kiloHit;
        audioSrc.Play();
        enemyHpLevel += 5;
        enemyHp.text = enemyHpLevel + "%";
    }
    public void hitMega()
    {
        audioSrc.clip = megaHit;
        audioSrc.Play();
        enemyHpLevel += 10;
        enemyHp.text = enemyHpLevel + "%";
    }
    public void hitGiga()
    {
        audioSrc.clip = gigaHit;
        audioSrc.Play();
        enemyHpLevel += 20;
        enemyHp.text = enemyHpLevel + "%";
    }
}
