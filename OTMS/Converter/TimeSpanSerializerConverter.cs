using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OTMS.Converter
{
    public class TimeSpanSerializerConverter : JsonConverter<TimeSpan>
    {

        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            DateTime dateTime = DateTime.Parse(value, CultureInfo.InvariantCulture);
            return dateTime.TimeOfDay;
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(null, CultureInfo.InvariantCulture));
        }

    }
}
