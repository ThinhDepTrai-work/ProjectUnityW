using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
[Serializable]
public class CharacterStat
{
    public float BaseValue;

    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    // check if we need recalculate the stat
    protected bool isDirty = true;
    // hold the most recent stat val
    protected float _value;
    // hold the last base value
    protected float lastBaseValue = float.MinValue;


    // Change the Value property to this
    public float Value
    {
        get
        {
            if (isDirty || BaseValue != lastBaseValue)
            {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }
    public CharacterStat()
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }
    public CharacterStat(float baseValue): this()
    {
        BaseValue = baseValue;
    }

    // Change the AddModifier method
    public virtual void AddModifier(StatModifier mod)
    {
        // is modified
        isDirty = true;
        statModifiers.Add(mod);
        // sort modifiers
        statModifiers.Sort(CompareModifierOrder); 
    }

    // implement a comparator
    public virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.Order < b.Order)
        {
            return -1;
        }else if (a.Order > b.Order) return 1;
        else return 0;
    }

    // the RemoveModifier method
    public virtual bool RemoveModifier(StatModifier mod)
    {
        if (statModifiers.Remove(mod))
        {
            // is modified
            isDirty = true;
            return true;
        }
        return false;
    }

    // remove all modifier comes from particular source
    public virtual bool RemoveModifiersFromSource(object source)
    {
        bool isRemoved = false;
        for (int i = statModifiers.Count - 1; i >= 0; i--)
        {
            if (statModifiers[i].Source == source)
            {
                isDirty = true;
                isRemoved = true;
                statModifiers.RemoveAt(i);
            }
        }
        return isRemoved;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if (mod.Type == StatModType.Flat)
            {
                finalValue += mod.Value;
            } else if (mod.Type == StatModType.PercentAdd)
            {
                sumPercentAdd += mod.Value;

                if (i+1 >= statModifiers.Count || statModifiers[i+1].Type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.Type == StatModType.PercentMul)
            {
                finalValue *= 1 + mod.Value;    
            }
        }
        // Rounding gets around dumb float calculation errors (like getting 12.0001f, instead of 12f)
        // 4 significant digits is usually precise enough, but feel free to change this to fit your needs
        return (float)Math.Round(finalValue, 4);
    }
}
