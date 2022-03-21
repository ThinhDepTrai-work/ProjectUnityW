//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.Text;
//using System.Threading.Tasks;


//internal class GameDateTimeSerializationSurrogate : ISerializationSurrogate
//{
//    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
//    {
//        var dateTimeSystem = (DateTimeSystem)obj;
//        info.AddValue("min", dateTimeSystem.Min);
//        info.AddValue("hour", dateTimeSystem.hour);
//        info.AddValue("day", dateTimeSystem.day);
//        info.AddValue("month", dateTimeSystem.month);
//        info.AddValue("year", dateTimeSystem.year);
//    }

//    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
//    {
//        var dateTimeSystem = (DateTimeSystem)obj;
//        dateTimeSystem.Min = (int)info.GetValue("min", typeof(int)) ;
//        dateTimeSystem.hour = (int)info.GetValue("hour", typeof(int)) ;
//        dateTimeSystem.Min = (int)info.GetValue("min", typeof(int)) ;
//        dateTimeSystem.Min = (int)info.GetValue("min", typeof(int)) ;
//        dateTimeSystem.Min = (int)info.GetValue("min", typeof(int)) ;
//    }
//}
