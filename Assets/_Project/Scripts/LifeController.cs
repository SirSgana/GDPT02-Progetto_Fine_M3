using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _setHp = 10;

    //Parametri Get
    public int GetSetHp() => _setHp;

    //Parametri Set
    private void SetSetHp(int hp) { _setHp = hp; }

    public void TakeDamage(int damage)
    {
        if(_setHp - damage > 0)
        {
            _setHp -= damage;
        }
        else
        {
            _setHp = 0;
        }
    }

    public bool IsAlive()
    {
        if (_setHp > 0)
        { 
            return true;
        }
        else
        {
            return false;
        }
    
    }
}
