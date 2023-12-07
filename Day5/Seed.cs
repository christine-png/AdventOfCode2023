public class Seed {

    public decimal seed;
    public decimal soil;
    public decimal fertilizer;
    public decimal water;
    public decimal light;
    public decimal temperature;
    public decimal humidity;
    public decimal location;

    public Seed(decimal seed, decimal soil, decimal fertilizer, decimal water, decimal light, decimal temperature, decimal humidity, decimal location){
        this.seed = seed;
        this.soil = soil;
        this.fertilizer = fertilizer;
        this.water = water;
        this.light = light;
        this.temperature = temperature;
        this.humidity = humidity;
        this.location = location;
    }

    public void toString(){
        Console.WriteLine("Seed: " + this.seed);
        Console.WriteLine("Soil: " + this.soil);
        Console.WriteLine("FertilizerNr: " + this.fertilizer);
        Console.WriteLine("WaterNr: " + this.water);
        Console.WriteLine("LightNr: " + this.light);
        Console.WriteLine("TemperatureNr: " + this.temperature);
        Console.WriteLine("Humidity: " + this.humidity);
        Console.WriteLine("Location: " + this.location);
        Console.WriteLine();
    }

}