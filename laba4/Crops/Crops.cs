using System;
using System.IO;

namespace laba4
{
    public class Crops : ICloneable, IComparable<Crops>
    {
        private string _name;
        private string _country;
        private int _season;

        private string _path = "C:/Users/Nova/source/repos/OOP_Labs/laba4/Crops/crops.json";
        public string GetPath => _path;
        public Crops(string name, string country, int season)
        {
            _name = name;
            _country = country;
            _season = season;
        }

        public override string ToString() => _name + " " + _country + " " + _season;

        public CropsDTO MapToCropsDTO()
        {   
            return new CropsDTO {
                Name = _name,
                Country = _country,
                Season = _season
            };
        }
        
        public object Clone()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_country) || _season < 0)
                throw new InvalidDataException("Object of class Crop cannot have any null fields, or season num less than 0.");
            
            return new Crops(_name, _country, _season);
        }

        public int CompareTo(Crops obj)
        {
            if (obj == null) return 1;
            return String.Compare(_name, obj._name, StringComparison.CurrentCulture);
        }
    }
}