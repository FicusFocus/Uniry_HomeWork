using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    [SerializeField] private List<Bird> _birds;

    private int _currentBirdNumber;



    private void Spawn(Bird tamplate)
    {
        Instantiate(tamplate, transform);
    }
}
