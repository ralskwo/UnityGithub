using TMPro;
using UnityEngine;

public class CookieView : MonoBehaviour
{
    public TextMeshProUGUI cookieCountText;
    public TextMeshProUGUI autoClickerCountText;

    public void UpdateCookieCount(int count)
    {
        cookieCountText.text = "Cookies: " + count.ToString();
    }

    public void UpdateAutoClickerCount(int count)
    {
        autoClickerCountText.text = "Auto Clickers: " + count.ToString();
    }
}