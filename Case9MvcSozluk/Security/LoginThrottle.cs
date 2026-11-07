using System;
using System.Web;
namespace Case9MvcSozluk.Security
{
    // Local IIS process cache. Production multi-instance deployments need a shared store.
    public static class LoginThrottle
    {
        private static readonly object Sync = new object();
        public static string Key(string area, string user, string ip)
        { return "szx:login:" + area + ":" + (user ?? "").Trim().ToLowerInvariant() + ":" + (ip ?? "unknown"); }
        public static bool IsBlocked(string key)
        {
            lock (Sync) { return (HttpRuntime.Cache[key] as Attempt)?.Failures >= 8; }
        }
        public static void Failure(string key)
        {
            lock (Sync)
            {
                var data = HttpRuntime.Cache[key] as Attempt ?? new Attempt();
                data.Failures++;
                HttpRuntime.Cache.Insert(key, data, null, DateTime.UtcNow.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }
        public static void Clear(string key) { lock (Sync) { HttpRuntime.Cache.Remove(key); } }
        private class Attempt { public int Failures { get; set; } }
    }
}