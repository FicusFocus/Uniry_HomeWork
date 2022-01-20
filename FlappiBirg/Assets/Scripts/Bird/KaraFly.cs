using UnityEngine;

public class KaraFly : BirdFly
{
    [SerializeField] private GameObject _flame;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _flame.SetActive(true);
            Fly();
        }
    }
}
