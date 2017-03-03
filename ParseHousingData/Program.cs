using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace ParseHousingData
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void ParseHousingData(string inputDir, string outputDir)
        {
            var files = Directory.GetFiles(inputDir);
            foreach(var file in files)
            {
                var housingJson = File.ReadAllText(file);
                var housing = JsonConvert.DeserializeObject<Housing>(housingJson);
                File.WriteAllText(Path.Combine(outputDir, Path.GetFileName(file)), JsonConvert.SerializeObject(new HousingComData(housing)));
            }
        }

        static void ParseMagicBricksData(string inputDir, string outputDir)
        {
            var files = Directory.GetFiles(inputDir);
            foreach (var file in files)
            {
                var housingData = new MagicBricksData();
                housingData.id = int.Parse(Path.GetFileNameWithoutExtension(file));
                var magicBricksHtml = File.ReadAllText(file);
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(magicBricksHtml);
                var detailNode = htmlDoc.GetElementbyId("detailOverview");
                var headerNode = htmlDoc.GetElementbyId("detailHeaderFixed");
                var detailNodes = GetNodesOfAClass(detailNode, "aboutDetail");

                housingData.property_type = GetNodesOfAClass(headerNode, "locName").First().InnerText;
                housingData.apartment_type = "";

                var detailAddress = GetNodesOfAClass(headerNode, "detailAddress").First().InnerText;
                string address = detailAddress;
                var data = GetLocationData(address);
                housingData.city_name = data.city_name;
                housingData.pincode = data.pincode;
                housingData.region_name = data.region_name;
                housingData.latitude = data.location.lat;
                housingData.longitude = data.location.lng;

                foreach (var node in detailNodes)
                {
                    var leftColText = GetNodesOfAClass(node, "leftCol").First().InnerText;
                    var rightColText = GetNodesOfAClass(node, "rightCol").First().InnerText;
                    switch (leftColText)
                    {
                        case "Configuration":
                            housingData.bedroom_count = int.Parse(rightColText);
                            housingData.bathroom_count = int.Parse(rightColText);
                            break;
                        case "Area":
                            housingData.built_up_area = int.Parse(rightColText);
                            break;
                        case "Status":
                            housingData.under_construction = bool.Parse(rightColText);
                            break;
                        case "Floor Number":
                            housingData.floor_number = int.Parse(rightColText);
                            housingData.floor_count = int.Parse(rightColText);
                            break;
                        case "Price":
                            housingData.price_per_sqft = int.Parse(rightColText);
                            break;
                        default: continue;
                    }
                }
                housingData.price_per_sqft = housingData.price_per_sqft / housingData.built_up_area;
                housingData.age_of_property = 0;

                if (!CheckMagicBricksValidity(housingData))
                {
                    Console.WriteLine("Data incomplete");
                    continue;
                }
                File.WriteAllText(Path.Combine(outputDir, string.Format("{0}.json", Path.GetFileNameWithoutExtension(file))), JsonConvert.SerializeObject(housingData));
            }
        }

        static Data GetLocationData(string address)
        {
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=true", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                String responseString = reader.ReadToEnd();
                var geoOutput = JsonConvert.DeserializeObject<GeoCode>(responseString);
                var geo = new Location
                {
                    lat = geoOutput.results[0].geometry.location.lat,
                    lng = geoOutput.results[0].geometry.location.lng
                };
                var data = new Data
                {
                    city_name = geoOutput.results[0].address_components.First(t => t.types.Contains("locality") && t.types.Contains("political")).short_name,
                    pincode = geoOutput.results[0].address_components.First(t => t.types.Contains("postal_code")).short_name,
                    region_name = geoOutput.results[0].address_components.First(t => t.types.Contains("sublocality_level_1") && t.types.Contains("sublocality")).short_name,
                    location = geo
                };
                return data;
            }
        }

        public static bool CheckMagicBricksValidity(MagicBricksData data)
        {
            if ((!data.under_construction && data.age_of_property == 0) || data.bedroom_count == 0 || data.bathroom_count == 0 || data.latitude == 0 || data.longitude == 0 || data.id == 0)
            {
                return false;
            }
            return true;
        }

        public static IEnumerable<HtmlNode> GetNodesOfAClass(HtmlNode node, string className)
        {
            return node.Descendants()
                .Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value.Equals(className));
        }
    }

    public class Data
    {
        public Location location { get; set; }
        public string city_name { get; set; }
        public string region_name { get; set; }
        public string pincode { get; set; }
    }
}
