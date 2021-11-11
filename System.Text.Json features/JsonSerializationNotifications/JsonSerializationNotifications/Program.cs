// https://twitter.com/okyrylchuk/status/1446194962228555786

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

Product invalidProduct = new() { Name = "Name", Test = "Test" };
JsonSerializer.Serialize(invalidProduct);
// The InvalidOperationException is thrown

string invalidJson = "{}";
JsonSerializer.Deserialize<Product>(invalidJson);
// The InvalidOperationException is thrown

class Product : IJsonOnDeserialized, IJsonOnSerializing, IJsonOnSerialized
{
    public string Name { get; set; }

    public string Test { get; set; }

    public void OnSerialized()
    {
        throw new NotImplementedException();
    }

    void IJsonOnDeserialized.OnDeserialized() => Validate(); // Call after deserialization
    void IJsonOnSerializing.OnSerializing() => Validate();   // Call before serialization

    private void Validate()
    {
        if (Name is null)
        {
            throw new InvalidOperationException("The 'Name' property cannot be 'null'.");
        }
    }
}


