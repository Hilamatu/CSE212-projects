// <summary>
//Custom class to hold the features from the GeoJSON data
//Nested classes to represent the structure of the JSON data
// Each earthquake feature has properties including magnitude and place
// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public decimal? Mag { get; set; }
    public string Place { get; set; }
}

