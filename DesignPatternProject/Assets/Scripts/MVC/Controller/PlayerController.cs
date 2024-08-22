using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerModel model;
    private PlayerView view;

    void Start()
    {
        model = new PlayerModel(100, 0);
        view = GetComponent<PlayerView>();
        view.UpdateHealth(model.Health);
        view.UpdateScore(model.Score);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            model.Score += 10;
            view.UpdateScore(model.Score);
        }
    }
}
