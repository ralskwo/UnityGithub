using UnityEngine;

public class CookieController : MonoBehaviour
{
    private CookieModel model;
    private CookieView view;

    void Start()
    {
        model = new CookieModel();
        view = GetComponent<CookieView>();

        // �ʱ� ���� ������Ʈ
        view.UpdateCookieCount(model.CookieCount);
        view.UpdateAutoClickerCount(model.AutoClickerCount);

        // 1�ʸ��� �ڵ� ��Ű ����
        InvokeRepeating("AutoGenerateCookies", 1f, 1f);
    }

    public void OnCookieClick()
    {
        model.AddCookie(1);
        view.UpdateCookieCount(model.CookieCount);
    }

    public void OnBuyAutoClickerClick()
    {
        model.BuyAutoClicker();
        view.UpdateCookieCount(model.CookieCount);
        view.UpdateAutoClickerCount(model.AutoClickerCount);
    }

    private void AutoGenerateCookies()
    {
        model.AutoGenerateCookies();
        view.UpdateCookieCount(model.CookieCount);
    }
}
