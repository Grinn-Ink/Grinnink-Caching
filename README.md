# Grinnink Caching

A quick and simple caching server, built for Grinn.ink, possibly usable by others?

## How it Works

This is an in-memory cache that stores and retrieves data from a `ConcurrentDictionary` of type `IDictionary<string, object>`. This dictionary is used in a singleton service of type `Cache` which implements the `ICache` interface that has three methods:

* `object ICache.Get(string key)` - which retrieves an object of data from the dictionary. If it cannot find the key it returns null.
* `void ICache.Remove(string key)` - which removes the key an object of data from the dictionary if it exists, throwing no exception if it doesn't.
* `void ICache.Set(string key, object value)` - which adds an object to the dictionary using the given key if that key doesn't exist, otherwise, overrides the existing object at that key.

There are three primary endpoints:

* `DELETE /cache/{key}` - Where `{key}` is the key to fetch the data. The key must be URI encoded if using special characters, such as a slash. Returns a `200` with the JSON object if found, otherwise, null.
* `GET /cache/{key}` - Where `{key}` is the key to delete from the cache. The key must be URI encoded if using special characters, such as a slash. Returns 204 regardless of whether the key is deleted or not.
* `PUT /cache/{key}` - Where `{key}` is the key to store the data at. The key must be URI encoded if using special characters, such as a slash. The value or object of data must be in JSON format. Returns 204 regardless of whether the key and value are stored or not.
