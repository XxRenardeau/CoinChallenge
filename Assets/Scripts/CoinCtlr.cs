using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCtlr : MonoBehaviour
{

    public enum CoinType { cuivre, argent, or };
    public CoinType coinType;
    public List<GameObject> prefabListe;
    int multiplicateur = 1;
    public AudioSource audioSource;
    public Collider colette;
    public ParticleSystem particules;
    public int coinValue
    {
        get
        {
            switch (coinType)
            {
                case CoinType.cuivre: return 1;
                case CoinType.argent: return 5;
                case CoinType.or: return 10;
                default: return 0;
            }
        }
    }
    void Awake()
    {
        //transform.GetChild(1).gameObject.SetActive(false);

    }

    void Start()
    {
        CreatePrefab(coinType);
    }

    void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Player")) return;
        //Debug.Log("collision avec" + col.gameObject.name);
        audioSource.Play();
        particules.Play();
        //Debug.Log("son piece");
        OnCollected();

    }
    void OnCollected()
    {
        colette.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        //transform.GetChild(1).gameObject.SetActive(false);
        CoinCollector.Instance.AddScore(coinValue * multiplicateur);
        //gameObject.SetActive(false);
    }
    GameObject GetPrefab(CoinType coinType)
    {
        int Index = (int)coinType;
        return prefabListe[Index];
    }
    void CreatePrefab(CoinType coinType)
    {

        GameObject prefab = GetPrefab(coinType);
        GameObject Instance = Instantiate(prefab);
        Instance.transform.SetParent(transform);
        Instance.transform.localPosition = Vector3.zero;
    }
}
