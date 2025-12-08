using UnityEngine;
using UnityEngine.UI;
using System; // Để dùng Enum

public class ChangeClothesController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ScrollRect listButton;
    public ScrollRect pageClothes;

    private void Awake()
    {
        this.LoadAssetListButtonClothes();
    }

    private void OnEnable()
    {
        // Đăng ký lắng nghe: Khi sự kiện OnRequestChangeCategory xảy ra -> Chạy hàm LoadAndSpawnClothesFromResource
        GameEvents.OnRequestChangeCategory.AddListener(LoadAndSpawnClothesFromResource);
    }

    private void OnDisable()
    {
        // Hủy đăng ký khi object bị tắt (Rất quan trọng để tránh lỗi Memory Leak)
        GameEvents.OnRequestChangeCategory.RemoveListener(LoadAndSpawnClothesFromResource);
    }

    private void LoadAssetListButtonClothes()
    {
        // 1. Xóa sạch nút cũ (nếu có)
        foreach (Transform child in listButton.content)
        {
            Destroy(child.gameObject);
        }

        GameObject categoryBtnPrefab = PrefabManager.Instance.buttonListClothes;

        // 2. Lặp qua tất cả các giá trị có trong Enum ClothesType
        // Đây là cách "đếm" số lượng loại đồ chuẩn nhất
        foreach (THUMB_DOLL type in Enum.GetValues(typeof(THUMB_DOLL)))
        {
            

            // Spawn nút
            GameObject btnObj = Instantiate(categoryBtnPrefab, listButton.content);

            var btnScript = btnObj.GetComponent<BtnChooseList>();
            if (btnScript != null)
            {
                btnScript.SetType(type);
            }
        }
    }

    // Hàm này phải khớp tham số với Event (nhận vào THUMB_DOLL)
    private void LoadAndSpawnClothesFromResource(THUMB_DOLL type)
    {
        Debug.Log($"Controller nhận được lệnh load: {type}");

        if (pageClothes != null && pageClothes.content != null)
        {
            foreach (Transform child in pageClothes.content)
            {
                // Dùng DestroyImmediate trong Editor mode, Destroy khi chạy thật
                // Nhưng an toàn nhất cứ dùng Destroy
                Destroy(child.gameObject);
            }
        }

        string path = $"Thumb/{type.ToString()}";

        // Load toàn bộ ảnh trong folder đó
        // LoadAll sẽ lấy tất cả file có dạng Sprite trong folder
        Sprite[] allSprites = Resources.LoadAll<Sprite>(path);

        // Kiểm tra xem có load được gì không
        if (allSprites == null || allSprites.Length == 0)
        {
            Debug.LogWarning($"⚠️ Không tìm thấy ảnh nào tại đường dẫn: Resources/{path}");
            return;
        }

        GameObject itemClothesPrefab = PrefabManager.Instance.itemClothes;

        // BƯỚC 4: Spawn từng món đồ ra giao diện
        foreach (Sprite sp in allSprites)
        {
            // 1. Tạo ra node item mới
            GameObject newItemObj = Instantiate(itemClothesPrefab, pageClothes.content);

            // 2. Tìm thằng con tên "Clothers" NẰM TRONG thằng mới sinh ra (newItemObj)
            // Lưu ý: Phải dùng newItemObj.transform.Find chứ không dùng transform.Find khơi khơi
            Transform clothersTrans = newItemObj.transform.Find("Clothers");

            if (clothersTrans != null)
            {
                // 3. Lấy Image và gán Sprite
                Image clothesImage = clothersTrans.GetComponent<Image>();
                if (clothesImage != null)
                {
                    clothesImage.sprite = sp; // Gắn ảnh vừa load được vào
                }
            }
            else
            {
                Debug.LogError("❌ Trong Prefab không có object con nào tên là 'Clothers' cả! Kiểm tra lại tên đi.");
            }
        }
    }
}
