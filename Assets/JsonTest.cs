using System;
using System.Collections.Generic;
using Core.Finances.Moneys;
using Core.Finances.Store.Products;
using Finances.Moneys;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Product = Core.Finances.Store.Products.Product;

public class JsonTest : MonoBehaviour
{
    [SerializeField] private Bundle _list;
    
    [ContextMenu("DeserializeTest")]
    public void Test()
    {
        var a = Resources.Load<TextAsset>("Configs/Products");
        List<Product> products = new List<Product>();
        var o = JArray.Parse(a.text);

        foreach (var product in o)
        {
            string t = product.ToString();
            products.Add(Product(product));
        }
    }
    
    public static Product Product(JToken jObject) => (string)jObject["type"] switch
    {
        "Coins" => jObject.ToObject<Coins>(),
        "Spins" => jObject.ToObject<Spins>(),
        _ => throw new ArgumentOutOfRangeException( $"Not expected direction value: {jObject}"),
    };

    [ContextMenu("SerializationTest")]
    public void SerializationTest()
    {
        string json = JsonConvert.SerializeObject(_list, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });
        Debug.Log(json);
    }
}
