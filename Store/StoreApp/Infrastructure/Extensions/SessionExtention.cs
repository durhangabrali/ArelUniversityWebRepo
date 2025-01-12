using System.Text.Json;

namespace StoreApp.Infrastructure.Extention
{
    public static class SessionExtention
    {
        // Bu metot bir object'e bağlı olarak çalışır.
        // Bu metot aynı zamanda extention bir metottur. ISession'ı extent etmektedir.
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        // Yukarıdaki metodun Generic halini yazalım. Generic metotta bir tip istenilmekte ve 
        // metot tipe bağlı olarak çalışmaktadır.
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return data is null
                ? default(T)
                : JsonSerializer.Deserialize<T>(data);
        }
    }
}