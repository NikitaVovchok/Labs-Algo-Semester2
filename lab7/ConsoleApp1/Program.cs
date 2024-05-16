using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Список географічних об'єктів з координатами
        List<GeoObject> geoObjects = new List<GeoObject>
        {
            new GeoObject("Київ", 50.45, 30.52),
            new GeoObject("Львів", 49.84, 24.03),
            new GeoObject("Одеса", 46.48, 30.73),
            new GeoObject("Дніпро", 48.45, 35.04),
            new GeoObject("Харків", 49.98, 36.25),
            new GeoObject("Донецьк", 48.01, 37.80),
            new GeoObject("Запоріжжя", 47.85, 35.17)
        };

        Console.Write("Введіть широту: ");
        double latitude;
        while (!double.TryParse(Console.ReadLine(), out latitude))
        {
            Console.WriteLine("Невірний формат широти. Спробуйте ще раз:");
        }

        Console.Write("Введіть довготу: ");
        double longitude;
        while (!double.TryParse(Console.ReadLine(), out longitude))
        {
            Console.WriteLine("Невірний формат довготи. Спробуйте ще раз:");
        }

        int index = InterpolationSearch(geoObjects, latitude, longitude);
        if (index != -1)
        {
            Console.WriteLine($"Найближчий географічний об'єкт: {geoObjects[index].Name}");
        }
        else
        {
            Console.WriteLine("Географічний об'єкт не знайдено.");
        }

        Console.ReadLine();
    }

    static int InterpolationSearch(List<GeoObject> geoObjects, double latitude, double longitude)
    {
        int left = 0;
        int right = geoObjects.Count - 1;

        while (left <= right && latitude >= geoObjects[left].Latitude && latitude <= geoObjects[right].Latitude)
        {
            if (left == right)
            {
                if (geoObjects[left].Latitude == latitude && geoObjects[left].Longitude == longitude)
                    return left;
                return -1;
            }

            int pos = left + (int)(((double)(right - left) / (geoObjects[right].Latitude - geoObjects[left].Latitude)) * (latitude - geoObjects[left].Latitude));

            if (geoObjects[pos].Latitude == latitude && geoObjects[pos].Longitude == longitude)
                return pos;

            if (geoObjects[pos].Latitude < latitude)
                left = pos + 1;
            else
                right = pos - 1;
        }

        return -1;
    }
}

class GeoObject
{
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public GeoObject(string name, double latitude, double longitude)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }
}