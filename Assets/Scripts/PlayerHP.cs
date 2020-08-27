using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject playerImage;

    private List<GameObject> _HP;
    private PlayerControl _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerControl>();
        CreateHPUI(_player.PlayerHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateHPUI(int countHP)
    {
        _HP = new List<GameObject>();
        // TODO: - add HP and Create How Minus HP if player Death

    }
}
