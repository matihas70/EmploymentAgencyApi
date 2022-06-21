using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmploymentAgencyAPI.DataBase
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime)
            )
        { 
        }

    }
}
