
using UnityEngine;
using UnityEngine.UI;
public class dusman: MonoBehaviour
{
private Rigidbody2D myRigidbody;
private int dusmancan=1;
  public float moveSpeed = 5f;
 public float moveDistance = 2f;
public GameObject particleEffectPrefab;
 private bool movingUp = true;
private bool movingRight = true; // Hareket yönünü sağa doğru başlat
void Start(){
   
    myRigidbody= GetComponent<Rigidbody2D>();
}
    void Update()
    {
         if (gameObject.CompareTag("kiz"))
        {
            MoveRightLeft();
        }
        else if (gameObject.CompareTag("Mace"))
        {
            MoveUpDown();
        }
        //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        
    }

  void MoveRightLeft()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        // Belirli bir mesafeye ulaşıldığında yönü tersine çevir
        if (Mathf.Abs(transform.position.x) >= moveDistance / 2)
        {
            movingRight = !movingRight;
        }
    }

    void MoveUpDown()
    {
        if (gameObject.CompareTag("Mace")) // Mace etiketine sahip obje olduğundan emin ol
        {
            if (movingUp)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }

            if (Mathf.Abs(transform.position.y) >= moveDistance / 2)
            {
                movingUp = !movingUp;
            }
        }
    }
   void OnTriggerEnter2D(Collider2D other){
    if(other.gameObject.tag == "Kunai"){
        dusmancan--;
         if(dusmancan==0){
        Destroy(gameObject);}//enemy
        Destroy(other.gameObject);//saw
        // prefab => particle effect

       GameObject patlamaEfekti= Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
         // Patlama efektini 2 saniye sonra yok et
                Destroy(patlamaEfekti, 1f);

       
    }
    
   }
   }
