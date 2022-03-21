using System.Runtime.Serialization;

public class CharacterStatSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        CharacterStat characterStat = (CharacterStat)obj;
        info.AddValue("BaseValue", characterStat.Value);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        CharacterStat characterStat = (CharacterStat)obj;
        characterStat.BaseValue = (float)info.GetValue("BaseValue", typeof(float));

        return characterStat;
    }
}
