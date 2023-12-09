public class Destination{

    public string startLocation { get; set; }
    public decimal steps { get; set; }

    public string nextPosition { get; set; }

    public int position { get; set; }

    public Destination(string startLocation, int steps, string nextPosition, int position){
        this.startLocation = startLocation;
        this.steps = steps;
        this.nextPosition = nextPosition;
        this.position = position;
    }

    public override string ToString(){
       return "Start: "+startLocation+ " Steps: "+steps+" next Position: "+nextPosition +" Position: "+position;
    }
}