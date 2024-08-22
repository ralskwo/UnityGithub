// CookieModel.cs
public class CookieModel
{
    public int CookieCount { get; private set; }
    public int AutoClickerCount { get; private set; }

    public void AddCookie(int amount)
    {
        CookieCount += amount;
    }

    public void BuyAutoClicker()
    {
        if (CookieCount >= 10) // �ڵ� Ŭ���⸦ ��� ���� ��Ű ����
        {
            AutoClickerCount++;
            CookieCount -= 10;
        }
    }

    public void AutoGenerateCookies()
    {
        CookieCount += AutoClickerCount;
    }
}
