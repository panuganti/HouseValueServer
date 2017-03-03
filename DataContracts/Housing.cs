using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    public class Housing
    {
        public string status { get; set; }
        public string message { get; set; }
        public Result result { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float center_point_latitude { get; set; } //2. 
        public float center_point_longitude { get; set; } // 3. 
        public string street_info { get; set; }
        public string locality { get; set; }
        public int price { get; set; }
        public string formatted_price { get; set; }
        public int per_square_feet_rate { get; set; } // 1. 
        public int floor_count { get; set; } // 4.
        public int floor_number { get; set; } // 5. 
        public string apartment_type { get; set; } // 6
        public string property_type { get; set; } // 7
        public DateTime date_added { get; set; } //8
        public string available_from { get; set; }
        public int age_of_property { get; set; }
        public string age_of_property_date { get; set; }
        public bool under_construction { get; set; }
        public string thumb_id { get; set; }
        public string thumb_name { get; set; }
        public string thumb_url { get; set; }
        public string thumb_url_new { get; set; }
        public object[] floor_plan_images { get; set; }
        public object[] floor_plan_images_new { get; set; }
        public int built_up_area { get; set; }
        public int bedroom_count { get; set; }
        public int bathroom_count { get; set; }
        public bool is_price_negotiable { get; set; }
        public bool has_swimming_pool { get; set; }
        public bool has_gym { get; set; }
        public int number_of_lifts { get; set; }
        public int parking_count { get; set; }
        public string[] seo_address_tags { get; set; }
        public string seo_title { get; set; }
        public string title { get; set; }
        public object display_regions { get; set; }
        public string description { get; set; }
        public string main_entrance_facing { get; set; }
        public string status { get; set; }
        public int image_count { get; set; }
        public string[][] images { get; set; }
        public string[][] images_new { get; set; }
        public Images_With_Master_Tags[] images_with_master_tags { get; set; }
        public string region_name { get; set; }
        public string share_url { get; set; }
        public string canonical_url { get; set; }
        public string locality_url_name { get; set; }
        public string locality_filter_param { get; set; }
        public int fi { get; set; }
        public int city_id { get; set; }
        public bool has_gas_pipeline { get; set; }
        public string water_supply_type { get; set; }
        public bool has_servant_room { get; set; }
        public string power_backup_type { get; set; }
        public bool is_gated_community { get; set; }
        public string security_type { get; set; }
        public object is_society_formed { get; set; }
        public Lifestyle_Fields lifestyle_fields { get; set; }
        public string lifestyle_rating { get; set; }
        public string city_name { get; set; }
        public Broker[] brokers { get; set; }
        public string owner_type { get; set; }
        public Contact_Persons[] contact_persons { get; set; }
        public string contact_person_type { get; set; }
        public Hestimate hestimate { get; set; }
    }

    public class Lifestyle_Fields
    {
        public int lifestyle_rating { get; set; }
        public float society_rating { get; set; }
        public float location_rating { get; set; }
        public string lifestyle_rating_type { get; set; }
        public float connectivity_score { get; set; }
        public float location_score { get; set; }
        public float peripheral_score { get; set; }
        public string locality_type { get; set; }
        public string society_type { get; set; }
        public object poshness_index { get; set; }
        public Connectivity connectivity { get; set; }
        public Neighbourhood neighbourhood { get; set; }
        public float neighbourhood_score { get; set; }
    }

    public class Connectivity
    {
        public string[] Good { get; set; }
        public string[] None { get; set; }
        public string[] Great { get; set; }
    }

    public class Neighbourhood
    {
        public string[] Good { get; set; }
    }

    public class Hestimate
    {
        public string label { get; set; }
        public int value { get; set; }
        public object formatted_value { get; set; }
    }

    public class Images_With_Master_Tags
    {
        public string master_tag { get; set; }
        public Image[] images { get; set; }
    }

    public class Image
    {
        public string absolute_url { get; set; }
        public string caption { get; set; }
        public bool is_landscape { get; set; }
    }

    public class Broker
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firm { get; set; }
        public object[] number { get; set; }
        public string experience { get; set; }
        public Locality[] localities { get; set; }
        public Service[] services { get; set; }
        public string firm_legal_status { get; set; }
        public string image_url { get; set; }
        public string image_url_new { get; set; }
    }

    public class Locality
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Service
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Contact_Persons
    {
        public int id { get; set; }
        public int profile_id { get; set; }
        public string name { get; set; }
        public string firm_name { get; set; }
        public object number { get; set; }
        public object original_number { get; set; }
        public string profile_url { get; set; }
        public string image_url { get; set; }
        public string image_url_new { get; set; }
        public string profile_type { get; set; }
    }
}
