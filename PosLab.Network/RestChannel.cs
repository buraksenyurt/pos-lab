using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PosLab.Network;

public class RestChannel
        : IRestChannel
{
    public async Task<string> PostData(string requestUri, string payload)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUri, content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

        return default;
    }

    public async Task<R> PostDataWithReuqestUri<R, P>(string requestUri, P payload, string? access_token = null)
    {
        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(access_token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                }

                var serializedPayload = JsonSerializer.Serialize<P>(payload);
                var content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUri, content);
                if (response.IsSuccessStatusCode)
                {
                    R deserializedResponse = JsonSerializer.Deserialize<R>(await response.Content.ReadAsStringAsync());
                    return deserializedResponse;
                }
            }
        }
        catch (Exception excp)
        {
            throw excp;
        }

        return default;
    }

    public async Task<R> GetDataWithRequestUri<R>(string requestUri, string? access_token = null)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(access_token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            }

            var response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                R deserializedResponse = JsonSerializer.Deserialize<R>(await response.Content.ReadAsStringAsync());
                return deserializedResponse;

            }
        }

        return default;
    }
}