using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void LoadScene(){
        SceneManager.LoadScene("Sahne1");
    }
    //çıkış fonksiyonu
    public void QuitGame(){
        //uygulama editörde çalışıyorsa
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //uygulama derlenmiş bir versiyon olarak çalışıyorsa
        #else
        Application.Quit();
        #endif
    }
}
