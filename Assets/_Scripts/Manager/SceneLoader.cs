using UnityEngine;
using UnityEngine.SceneManagement; // PENTING: Wajib ada untuk urusan pindah scene

public class SceneLoader : MonoBehaviour
{
    // Fungsi sederhana yang bisa dipanggil oleh tombol UI nanti
    public void LoadSceneByName(string namaSceneTujuan)
    {
        Debug.Log("SceneLoader: Mencoba pindah ke scene: " + namaSceneTujuan);
        SceneManager.LoadScene(namaSceneTujuan);
    }

    // Fungsi khusus untuk keluar game (dipakai di tombol Exit di menu utama)
    public void QuitGame()
    {
        Debug.Log("SceneLoader: Keluar dari game.");
        Application.Quit();
    }
}