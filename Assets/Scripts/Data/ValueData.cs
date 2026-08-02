using UnityEngine;
using System;

public abstract class ValueData<T> : MonoBehaviour
{
    public event Action<T> OnValueChanged;

    [SerializeField] protected T _value;

    public T Value => _value;

    protected virtual void SetValue(T newValue)
    {
        if(Equals(_value, newValue) == false)
        {
            _value = newValue;
            OnValueChanged?.Invoke(newValue);
        }
    }

    public abstract void ResetValue();
}
