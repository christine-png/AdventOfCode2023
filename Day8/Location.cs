public class Location{

    public string currentLocation { get; set; }

    public string leftLocation { get; set; }

    public string rightLocation { get; set; }

    public Location(string currentLocation, string leftLocation, string rightLocation){
        this.currentLocation = currentLocation;
        this.leftLocation = leftLocation;
        this.rightLocation = rightLocation;
    }

    override public string ToString(){
        return "Current: "+this.currentLocation +" Left: " + this.leftLocation + " Right: " + this.rightLocation;
    }

}