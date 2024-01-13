using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

private Rigidbody2D myRigidbody;
public float characterSpeed = 10f;
public GameObject projectilePrefab;
private float jumpForce= 20;

private float launchVelocity=20f;//bıçak fırlatma hızı
private bool isGround;
private bool lookRight;
public Text Sure;
public Text Can;
float timeLeft = 30f; // Başlangıçta 30 saniye
private int can;
public GameObject particleEffectPrefab;

private AudioSource arkaplan;
public AudioClip throwSound;
  private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
         currentHealth = can;
        arkaplan = GetComponent<AudioSource>();
        PlayBackgroundMusic();
       can=5;

        isGround= true;
        lookRight=true;
        myRigidbody= GetComponent<Rigidbody2D>();
    }
void PlayBackgroundMusic()
    {
        // Arka plan müziğini ekleyin (Unity Editörü üzerinden atanabilir)
        AudioClip backgroundMusic = Resources.Load<AudioClip>("arkaplan");

        if (backgroundMusic != null)
        {
            arkaplan.clip = backgroundMusic;
            arkaplan.loop = true;
           arkaplan.Play();
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        basicMovements(horizontal);
        changeDirection(horizontal);
          if (timeLeft > 0)
    {
        timeLeft -= Time.deltaTime; // Zamanı her güncelleme adımında azalt
        Sure.text = "Süre: " + Mathf.RoundToInt(timeLeft).ToString(); // Süreyi ekrana yazdır
    }
    else
    {
        Debug.Log("Süre doldu. Start Menu'ye yönlendiriliyorsunuz.");
         SceneManager.LoadScene("StartMenu"); // Süre bittiğinde yapılacak işlem
    }
    }

   public void canayar()
	{
		can--;
		Can.text = "Kalan Canın:" + can.ToString();
	}



void OnCollisionEnter2D(Collision2D other){
    if(other.gameObject.tag == "ground"){
        isGround=true;
    }



     if(other.gameObject.tag == "dusman"){
        canayar();
        GameObject patlamaEfekti= Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
         // Patlama efektini 2 saniye sonra yok et
                Destroy(patlamaEfekti, 1f);


         //CreateImpactEffect(transform.position);
        if(can==0){
             Destroy(gameObject);//enemy
        }
    
    
     }
   

}

  
 void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer oyuncu tuzağa temas ederse
        if (other.CompareTag("tuzak"))
        {
            TakeDamage(5); // 5 can kaybet
        }
    }

  void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die(); // Can 0 ise ölme fonksiyonunu çağır
        }
        
    }
 void Die()
    { SceneManager.LoadScene("StartMenu");}

    public void basicMovements(float horizontal){
        myRigidbody.velocity= new Vector2(horizontal*characterSpeed, myRigidbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            myRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGround=false;
        }
        if(Input.GetKeyDown(KeyCode.T)){
ThrowKnife();
 PlayThrowSound();
        }
    }
      void PlayThrowSound()
    {
        if (throwSound != null)
        {
            arkaplan.PlayOneShot(throwSound);
        }
    }
    public void changeDirection(float horizontal){
        if((horizontal > 0 && !lookRight) || (horizontal < 0 && lookRight)){
            Vector3 direction = transform.localScale;
            direction.x *= -1;
            transform.localScale=direction;
            lookRight = !lookRight;
        }
    }

    public void ThrowKnife(){
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D> ();
        Vector2 launchDirection;
    rb.angularVelocity = Random.Range(-360f, 360f); // 360 derece dönme hızı

        if(lookRight)
        launchDirection = new Vector2(transform.right.x, transform.right.y ) * launchVelocity;
        else
         launchDirection = new Vector2(-transform.right.x, -transform.right.y ) * launchVelocity;

         rb. velocity = launchDirection;
    }
}
