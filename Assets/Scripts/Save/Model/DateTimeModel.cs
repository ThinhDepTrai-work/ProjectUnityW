using System;

[Serializable]
public class DateTimeModel
{
    public int Min { get; set; }
    public int Hour { get; set; }
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public DateTimeModel()
    {

    }

    public DateTimeModel(int Min, int Hour, int Day, int Month, int Year)
    {
        this.Min = Min;
        this.Hour = Hour;
        this.Day = Day;
        this.Month = Month;
        this.Year = Year;
    }
}
