namespace KeyValueStore;

public class RedisStore
{
    private readonly Dictionary<string, string> _store = new();
    private readonly Dictionary<string, DateTime> _expiry = new();

    public string Set(string key, string value)
    {
        _store[key] = value;
        _expiry.Remove(key);
        return "OK";
    }

    public string? Get(string key)
    {
        CleanIfExpired(key);
        return _store.TryGetValue(key, out var value) ? value : null;
    }

    public int Del(string key)
    {
        CleanIfExpired(key);
        if (!_store.ContainsKey(key)) return 0;
        _store.Remove(key);
        _expiry.Remove(key);
        return 1;
    }

    public int Expire(string key, int seconds)
    {
        CleanIfExpired(key);
        if (!_store.ContainsKey(key)) return 0;
        _expiry[key] = DateTime.Now.AddSeconds(seconds);
        return 1;
    }

    public int Ttl(string key)
    {
        CleanIfExpired(key);
        if (!_store.ContainsKey(key)) return -2;
        if (!_expiry.ContainsKey(key)) return -1;
        return (int)(_expiry[key] - DateTime.Now).TotalSeconds;
    }

    public int Incr(string key)
    {
        CleanIfExpired(key);
        if (!_store.ContainsKey(key))
        {
            _store[key] = "1";
            return 1;
        }
        if (!int.TryParse(_store[key], out var value))
            throw new InvalidOperationException("Value is not a valid integer!");
        _store[key] = (++value).ToString();
        return value;
    }

    public int Decr(string key)
    {
        CleanIfExpired(key);
        if (!_store.ContainsKey(key))
            throw new InvalidOperationException("Key does not exist!");
        if (!int.TryParse(_store[key], out var value))
            throw new InvalidOperationException("Value is not a valid integer!");
        _store[key] = (--value).ToString();
        return value;
    }

    public List<string> Keys()
    {
        foreach (var key in _store.Keys.ToList())
            CleanIfExpired(key);
        return _store.Keys.ToList();
    }

    public string FlushAll()
    {
        _store.Clear();
        _expiry.Clear();
        return "OK";
    }

    private void CleanIfExpired(string key)
    {
        if (IsExpired(key))
        {
            _store.Remove(key);
            _expiry.Remove(key);
        }
    }

    private bool IsExpired(string key)
    {
        if(_expiry.TryGetValue(key, out var expiresAt))
            return DateTime.Now > expiresAt;
        return false;
    }
}
