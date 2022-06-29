using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
namespace Charging_place
{
    class ChargingPlace
    {
        private string referent;
        private string id;
        private int numberOrder;
        public string Referent
        {
            get => referent;
            set => referent = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }
        public int RedniBroj
        {
            get => numberOrder;
            set => numberOrder = value;
        }
        public ChargingPlace(string referent, string id, int redniBroj)
        {
            this.referent = referent;
            this.id = id;
            this.numberOrder = redniBroj;
        }
#nullable enable

        public static void Serialize(List<ChargingPlace> chargingPlaces)
        {
            File.WriteAllText("../../Data/ChargingPlaces.json", JsonSerializer.Serialize(chargingPlaces));
        }
        public static void CreateChargingPlace(string referent, string id, int number)
        {
            var places = Deserialize();
            places.Add(new ChargingPlace(referent, id, number));
            Serialize(places);
        }
        public static bool CheckAvailability(string id, int number) {
            var places = Deserialize();
            foreach (var place in places)
            {
                if (place.id == id || place.numberOrder == number)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<ChargingPlace> Deserialize()
        {
            string filepath = "../../Data/ChargingPlaces.json";
            string jsonText = File.ReadAllText(filepath);
            List<ChargingPlace> deserializedChargingPlaces = JsonSerializer.Deserialize<List<ChargingPlace>>(jsonText);
            return deserializedChargingPlaces;
        }
    }

}
