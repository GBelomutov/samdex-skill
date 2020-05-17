namespace AP.Constantine.BusinessLogic.Configuration
{
    /// <summary>
    /// Provides light controller configuration
    /// </summary>
    public interface INetworkConfiguratuionProvider
    {
        NetworkSettings GetSettings();
    }
}
