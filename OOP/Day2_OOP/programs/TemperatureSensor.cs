using System;
using System.Collections.Generic;
using System.Text;

namespace Day2_OOP.programs
{
    internal class TemperatureSensorCelcius
    {
        private const double AbsoluteZero = -273.15;
        private const double MaxSensorLimit = 150;
        private List<double>? TemperatureHistory;
        private double _temperature;

        public double Temperature
        {
            get { return _temperature; }
            set
            {
                if (value < AbsoluteZero)
                {
                    throw new ArgumentOutOfRangeException(nameof(value) , "TEMPERATURE SENSOR");
                }
                else if (value > MaxSensorLimit)
                {
                    
                    throw new ArgumentOutOfRangeException(nameof(value), "SENSOR LIMIT EXCEEDED!");
                }
                else
                {
                    _temperature = value;
                    // adding temperature value
                    TemperatureHistory?.Add(value);

                }
            }

        }

        public TemperatureSensorCelcius()
        {
            TemperatureHistory = [];
        }

        // getter method , as sensorhistory is not changeable.
        public List<double>? GetSensorHistory()
        {
            return TemperatureHistory;
        }
        
    }

    internal class TemperatureMonitor {
        public static void Main(string[] args) { 
            TemperatureSensorCelcius temperatureSensor1 = new TemperatureSensorCelcius();
            try
            {
                temperatureSensor1.Temperature = 34;
                temperatureSensor1.Temperature = 34;
                temperatureSensor1.Temperature = -341; // exception will occur here
            }
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine("EXCEPTION OCCURED "+ex.Message);
            }
            finally
            {
                List<double>? tempSensor = temperatureSensor1.GetSensorHistory();
                if (tempSensor?.Count > 0)
                {
                    Console.WriteLine("----------SENSOR HISTORY--------");
                    foreach (var temp in tempSensor)
                    {
                        Console.WriteLine(temp);
                    }                 
                }
            }

        }
    }


}
