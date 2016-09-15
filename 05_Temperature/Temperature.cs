using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Temperature
{
    enum Unit {
            Celcius,
            Fahrenheit
    }

    class Temperature
    {
        public double Fahrenheit = 0;
        public double Celcius    = 0;

        public Temperature(){}
        
        public Temperature(Unit unitType, double temperatur)
        {
            switch(unitType){
                case Unit.Celcius:
                    Celcius    = temperatur;
                    Fahrenheit = CelciusToFahrenheit(temperatur);
                    break;
                case Unit.Fahrenheit:
                    Fahrenheit = temperatur;
                    Celcius    = FahrenheitToCelcius(temperatur);
                    break;
            }
        }

        public static double FahrenheitToCelcius(double target)
        {
            double result = (target - 32) * (5.0 / 9.0);

            return Math.Round(result, 1);
        }

        public static double CelciusToFahrenheit(double target)
        {
            double result = target * (9.0 / 5.0) + 32;

            return Math.Round(result, 1);
        }

    }

    public class Celcius : ITemperature
    {
        public double Convert(double target)
        {
            double result = (target - 32) * (5.0 / 9.0);

            return Math.Round(result, 1);
        }
    }

    public class Fahrenheit : ITemperature
    {
        public double Convert(double target)
        {
            double result = target * (9.0 / 5.0) + 32;

            return Math.Round(result, 1);
        }
    }

    public interface ITemperature
    {
        double Convert(double target);
    }


    abstract class TemperatureFactory
    {
        public static ITemperature Get(Unit unitType)
        {
            switch(unitType){
                case Unit.Celcius:
                    return new Celcius();
                case Unit.Fahrenheit:
                default:
                    return new Fahrenheit();
            }
        }
    }
}
