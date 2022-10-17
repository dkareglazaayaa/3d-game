using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject coins;
    public int coinsNum;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        coinsNum = coins.transform.childCount;
        StartCoroutine(StartText());
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private IEnumerator StartText()
    {
        text.enabled = true;
        yield return new WaitForSeconds(0.5f);
        text.enabled = false;
    }
}
