

namespace craftersmine.Launcher.Core
{
    public sealed class Session
    {
        public string UserSession { get; private set; }

        public string GetSession(string sessionId)
        {
            UserSession = MD5Compute.ComputeSession(sessionId);
            return UserSession;
        }

        public string GetOffline()
        {
            Core.Logger.Log("Getting offline...", "INFO");
            UserSession = "null";
            return "null";
        }

        public string GetBadLogin()
        {
            Core.Logger.Log("Bad login!", "ERROR");
            UserSession = "Bad Login";
            return "Bad Login";
        }
    }
}



