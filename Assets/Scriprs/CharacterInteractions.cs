using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterInteractions : MonoBehaviour
{
    private Animator animator;

    public AnimationClip win;
    public AnimationClip bite;
    public AnimationClip die;

    private int coins_count = 0;
    public int heart_count = 3;
    private int star_count = 0;
    private int gem_count = 0;
    private int diamond_count = 0;

    public AudioSource heart_sound;
    public AudioSource star_sound;
    public AudioSource gem_sound;
    public AudioSource diamond_sound;
    public AudioSource snake_sound;

    [SerializeField] private GameObject coins;
    private int coinsNum;

    public Text coins_text;
    public Text heart_text;
    public Text gem_text;
    public Text diamond_text;

    public Image[] stars;

    public GameObject restartObj;

    public GameObject Win;
    //private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        var obj = GameObject.Find("Level1").GetComponent<LevelController>();
        coinsNum = obj.coinsNum;
        coins_text.text = $"Coins : { coins_count}"; 
        
        heart_text.text = $"Heart : { heart_count}";
        gem_text.text = $"Gem : {gem_count}";
        diamond_text.text = $"Diamond : {diamond_count}";

        stars[0].enabled = false;
        stars[1].enabled = false;
        stars[2].enabled = false;

        animator = transform.root.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (coins_count == coinsNum)
        {
            Debug.Log("win");
            animator.StopPlayback();
            animator.Play(win.name);
        }*/
        if (star_count == 3)
        {
            Debug.Log("win");
            animator.StopPlayback();
            Win.SetActive(true);
            animator.Play(win.name);
        }
    }
    public void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Coins"))
        {
            coins.GetComponent<AudioSource>().Play();
            Destroy(collider.gameObject);
            coins_count++;
            coins_text.text = $"Coins: {coins_count}"; 

        }

        if (collider.gameObject.CompareTag("Snake"))
        {
            snake_sound.Play();
            heart_count--;
            heart_text.text = $"Heart : { heart_count}";
            if (heart_count <= 0)
            {   
                animator.StopPlayback();
                animator.Play(die.name);
             
                
                restartObj.SetActive(true);
  
                Destroy(this.gameObject.GetComponentInParent<CharacterMove>());
                Destroy(this);

                Camera.main.fieldOfView += 13; 
               // camera.fieldOfView = 70;
              

            }
            else
            {                    
              
                animator.Play(bite.name);
            }
            
        }
        if (collider.gameObject.CompareTag("Heart"))
        {
            heart_count++;
            heart_text.text = $"Heart : { heart_count}";
            heart_sound.Play();

            Destroy(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Star"))
        {
            stars[star_count].enabled = true;
            star_count++;
            star_sound.Play();

            Destroy(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Gem"))
        {
            gem_count++;
            gem_text.text = $"Gem : {gem_count}";
           
            gem_sound.Play();

            Destroy(collider.gameObject);
        }
        if (collider.gameObject.CompareTag("Diamond"))
        {
            diamond_count++;
            diamond_text.text = $"Diamond : {diamond_count}";
            diamond_sound.Play();

            Destroy(collider.gameObject);
        }



    }
}
