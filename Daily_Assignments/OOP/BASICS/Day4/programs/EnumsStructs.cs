using System;

namespace Day4.programs;
class EnumsStructs
{
    public struct Coordinates
    {
        private float X, Y;

        public Coordinates(float x, float y)
        {
            X = x;
            Y = y;
        }
        internal float CalculateDiff(float pointa, float pointb)
        {
            return pointa - pointb;
        }
        internal void DisplayCoordinates()
        {
            Console.WriteLine("point A:" + X);
            Console.WriteLine("point B:" + Y);

        }
    }
    enum ORDERSTATUS
    {
        PLACED = 201,
        PROCESSING = 202,
        SHIPPED = 203,
        OUTFORDELIVERY = 204,
        DELIVERED = 205
    };
    static int GetCurrentStatusCode(ORDERSTATUS orderstatus)
    {
        int statusCode = 0;
        switch (orderstatus)
        {
            case ORDERSTATUS.PLACED:
                statusCode = (int)ORDERSTATUS.SHIPPED;
                break;
            case ORDERSTATUS.PROCESSING:
                statusCode = (int)ORDERSTATUS.PROCESSING;
                break;
            case ORDERSTATUS.SHIPPED:
                statusCode = (int)ORDERSTATUS.SHIPPED;
                break;
        }

        return statusCode;
    }

    static void Main(string[] args)
    {
        try
        {

            Coordinates c1 = new Coordinates(10, 20);
            Coordinates c2 = new Coordinates(90, 20);
            c1.DisplayCoordinates();
            c2.DisplayCoordinates();
            Console.WriteLine(GetCurrentStatusCode(ORDERSTATUS.PROCESSING));
            //Console.WriteLine();
            //Console.WriteLine(Enum.GetName(typeof(ORDERSTATUS), 204));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}