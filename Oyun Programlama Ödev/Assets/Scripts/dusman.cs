
using UnityEngine;
using UnityEngine.UI;
public class dusman: MonoBehaviour
{
private Rigidbody2D myRigidbody;
private int dusmancan=1;
  public float moveSpeed = 5f;

public GameObject particleEffectPrefab;
 public GameObject duvar; 

void Start(){
   
    myRigidbody= GetComponent<Rigidbody2D>();
}
    void Update()
    {
        //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
       
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
