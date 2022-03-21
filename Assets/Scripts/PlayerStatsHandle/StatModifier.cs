public enum StatModType
{
    Flat, // 0 add by value
    PercentAdd, // 1 add by percent (stack)
    PercentMul, // 1 add by percent (not stack)
}

public class StatModifier
{
    public readonly float Value;
    public readonly StatModType Type;
    public readonly int Order;
    public readonly object Source;

    public StatModifier(float value, StatModType type, int order, object source)
    {
        Value = value;
        Type = type;
        Order = order;
        Source = source;
    }

    // if constructor only get two values, set order is base on the type :)
    public StatModifier(float value, StatModType type): this(value, type, (int)type, null){}

    public StatModifier(float value, StatModType type, int order) : this(value, type, order, null) { }

    public StatModifier(float value, StatModType type, object source) : this(value, type, (int)type, null) { }
}