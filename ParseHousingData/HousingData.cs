using System.Runtime.Serialization;

namespace ParseHousingData
{
    [DataContract]
    public class HousingData
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public float latitude { get; set; }
        [DataMember]
        public float longitude { get; set; }
        [DataMember]
        public float price_per_sqft { get; set; }
        [DataMember]
        public int floor_count { get; set; } // 4.
        [DataMember]
        public int floor_number { get; set; } // 5. 
        [DataMember]
        public string apartment_type { get; set; } // 6
        [DataMember]
        public string property_type { get; set; } // 7
        [DataMember]
        public string available_from { get; set; }
        [DataMember]
        public int age_of_property { get; set; }
        [DataMember]
        public bool under_construction { get; set; }
        [DataMember]
        public int built_up_area { get; set; }
        [DataMember]
        public int bedroom_count { get; set; }
        [DataMember]
        public int bathroom_count { get; set; }
        [DataMember]
        public int parking_count { get; set; }
        [DataMember]
        public string main_entrance_facing { get; set; }
        [DataMember]
        public string region_name { get; set; }
        [DataMember]
        public int city_id { get; set; }
        [DataMember]
        public string city_name { get; set; }
        [DataMember]
        public int hestimate { get; set; }
    }
}
