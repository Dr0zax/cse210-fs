using System;

class Program
{
    static void Main(string[] args)
    {
       // Console.WriteLine("Hello Sandbox World!");
        Costume nurse = new(
            "face mask",
            "latex gloves",
            "orthopedic sneakers",
            "scrubs",
            "scrubs",
            "stethoscope"
        ); 

        nurse.ShowWardobe();
    }  
}