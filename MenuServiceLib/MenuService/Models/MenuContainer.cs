using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MenuService.Models
{
    [JsonObject]
    public class MenuContainer
    {
        [JsonProperty("menu")]
        public Menu MenuObject;
    }

    [JsonObject]
    public class Menu
    {
        [JsonProperty("header")]
        public string? Header;

        [JsonProperty("items")]
        public List<Item>? Items;    
    }

    [JsonObject]
    public class Item
    {
        [JsonProperty("label")]
        public string? Label;
        [JsonProperty("id")]
        public int Id;
    }
}
