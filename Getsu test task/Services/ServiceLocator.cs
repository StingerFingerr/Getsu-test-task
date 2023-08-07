static class ServiceLocator
{
    private static Dictionary<Type, IService> _services = new();

    public static void InitService<TService>(TService service) where TService : class, IService => 
        _services.Add(typeof(TService), service);

    public static TService GetService<TService>() where TService : class, IService =>
        (TService)_services[typeof(TService)];

    public static void Dispose() => 
        _services.GetEnumerator().Dispose();
}