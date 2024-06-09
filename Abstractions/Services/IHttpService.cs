namespace WinglyShopAdmin.App.Abstractions.Services;

public interface IHttpService
{
    Task<T> Get<T>(string uri);
    Task<T> Post<T>(string uri, object value);
    Task<T> Put<T>(string uri, object value);
    Task<T> Patch<T>(string uri);
    Task<T> Patch<T>(string uri, object value);
    Task<T> Delete<T>(string uri);
}
