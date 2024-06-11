namespace CropsClass
{
    public class Crops : ICloneable, IComparable<Crops>
    {
        private string _name;
        private string _country;
        private int _season;

        public Crops(string name, string country, int season)
        {
            _name = name;
            _country = country;
            _season = season;
        }

        public override string ToString() => 
            $"Crop name: {_name}; Country: {_country}; Season: {GetSeasonName()}";

        private string GetSeasonName()
        {
            switch (_season)
            {
                case 1:
                    return "Spring";
                case 2:
                    return "Summer";
                case 3:
                    return "Autumn";
                case 4:
                    return "Winter";
            }

            return default;
        }
        
        public CropsDTO MapToCropsDTO()
        {   
            return new CropsDTO {
                Name = _name,
                Country = _country,
                Season = _season
            };
        }

        public static Crops MapToCrops(CropsDTO dto)
        {
            return new Crops(dto.Name, dto.Country, dto.Season);
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