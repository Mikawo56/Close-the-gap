using Close_the_gap.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Close_the_gap.Model
{
    public class Material
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }
        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }
        [JsonProperty(PropertyName = "grade")]
        public string Grade { get; set; }
        [JsonProperty(PropertyName = "assetTag")]
        public string AssetTag { get; set; }
        [JsonProperty(PropertyName = "type")]
        public MaterialType Type { get; set; }
        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }
        [JsonProperty(PropertyName = "components")]
        public Dictionary<string,string> Components { get; set; }
        [JsonProperty(PropertyName = "defects")]
        public List<string> Defects { get; set; }
        [JsonProperty(PropertyName = "reconditionerData")]
        public Dictionary<string, string> ReconditionerData { get; set; }
        [JsonProperty(PropertyName = "donor")]
        public string Donor { get; set; }
        [JsonProperty(PropertyName = "collectionDate")]
        public DateTime CollectionDate  { get; set; }


    }
}
