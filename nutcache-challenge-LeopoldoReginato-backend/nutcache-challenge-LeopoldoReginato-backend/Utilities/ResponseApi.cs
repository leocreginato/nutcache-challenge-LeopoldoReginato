using nutcache_challenge_LeopoldoReginato_backend.DTOs;

namespace nutcache_challenge_LeopoldoReginato_backend.Utilities
{
    public class ResponseApi<T>
    {
        public bool Status { get; set; }
        public string? Msg { get; set; }
        public T? Value { get; set; }
    }
}
