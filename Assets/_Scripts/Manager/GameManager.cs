using UnityEngine;
using System.Collections.Generic; // Kita butuh ini untuk List

public class GameManager : MonoBehaviour
{
    // --- BAGIAN SINGLETON ---
    // Ini adalah variabel statis yang bisa diakses dari mana saja di kode lain
    // dengan cara mengetik: GameManager.Instance
    public static GameManager Instance;

    void Awake()
    {
        // Pola Singleton standar untuk memastikan hanya ada satu GameManager
        if (Instance == null)
        {
            Instance = this; // Jika belum ada manajer, sayalah manajernya.
            DontDestroyOnLoad(gameObject); // MANTRA AJAIB: Jangan hancurkan saya saat pindah scene!

            // Inisialisasi list saat game pertama kali mulai
            trashInventory = new List<WasteData>();
        }
        else
        {
            // Jika ternyata sudah ada GameManager lain (misal karena kembali ke menu utama),
            // hancurkan duplikat ini. Hanya boleh ada satu!
            Destroy(gameObject);
        }
    }
    // -------------------------


    [Header("Status Game Saat Ini")]
    public int totalSkor; // Menyimpan skor pemain sepanjang permainan

    // Ini adalah "Tas" untuk menyimpan sampah yang dikumpulkan di Fase 1 (Kantin/Lab/dll)
    // untuk dibawa ke Fase 2 (Ruang Sorting).
    public List<WasteData> trashInventory;

    // Variabel untuk menyimpan data level apa yang sedang dimainkan sekarang
    public LevelData currentLevelData;


    // --- FUNGSI BANTUAN (Akan kita pakai nanti) ---

    // Fungsi untuk menambah sampah ke inventaris (dipanggil di Fase 1)
    public void AddTrashToInventory(WasteData newTrash)
    {
        trashInventory.Add(newTrash);
        // Debug.Log untuk mengecek di Console apakah berhasil
        Debug.Log("GameManager: Berhasil menyimpan " + newTrash.namaSampah + " ke inventaris.");
    }

    // Fungsi untuk mengosongkan inventaris (misal saat mulai level baru)
    public void ClearInventory()
    {
        trashInventory.Clear();
        Debug.Log("GameManager: Inventaris dikosongkan.");
    }
}