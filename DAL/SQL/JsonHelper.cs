using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class JsonHelper
{
    public static string AjustarJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            return "[]";

        try
        {
            json = json.Trim();

            // 🔹 Caso: JSON viene como string escapado
            if (
                (json.StartsWith("\"") && json.EndsWith("\"")) ||
                (json.StartsWith("'") && json.EndsWith("'"))
            )
            {
                json = JsonConvert.DeserializeObject<string>(json);
            }

            // 🔹 Parsear JSON real
            var token = JToken.Parse(json);

            // 🔹 Serializar limpio
            return token.ToString(Formatting.Indented);
        }
        catch
        {
            // No romper el sistema
            return json;
        }
    }
}

