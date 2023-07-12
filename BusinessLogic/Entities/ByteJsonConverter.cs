using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ByteJsonConverter : JsonConverter<byte[]>
{
    private const string DateFormat = "dd-MM-yyyy";

    public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        var dateString = reader.GetString();
        var date = DateTime.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture);
        return BitConverter.GetBytes(date.Ticks);
    }

    public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        var ticks = BitConverter.ToInt64(value, 0);
        var date = new DateTime(ticks);
        var dateString = date.ToString(DateFormat, CultureInfo.InvariantCulture);
        writer.WriteStringValue(dateString);
    }
}