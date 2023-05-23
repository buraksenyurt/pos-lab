namespace PosLab.Network;

public interface IRestChannel
{
    Task<string> PostData(string requestUri, string payload);
    Task<R> PostDataWithReuqestUri<R, I>(string requestUri, I payload, string? access_token = null);
    Task<R> GetDataWithRequestUri<R>(string requestUri, string? access_token = null);
}
