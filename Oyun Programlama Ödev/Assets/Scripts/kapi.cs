using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class kapi : MonoBehaviour
{
	 
	[SerializeField] private  GameObject kapiAcik;

	
	

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			//kapiAcik.SetActive(true);
			//other.gameObject.SetActive(false);

        SceneManager.LoadScene("Sahne2");
		}
    }
}