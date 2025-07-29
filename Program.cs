using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static List<string[]> parkingSlots = new List<string[]>();
    static int totalSlots = 0;

    static void Main()
    {
    Console.Write("tigas ini dikerjakan degan bantuan ai \n");

        while (true)
        {
            Console.Write("$ ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            string[] parts = input.Split(' ');
            string command = parts[0];

            switch (command)
            {
                case "create_parking_lot":
                    if (parts.Length > 1 && int.TryParse(parts[1], out int count))
                    {
                        totalSlots = count;
                        parkingSlots = new List<string[]>(new string[totalSlots][]);
                        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                    }
                    break;

                case "park":
                    if (parts.Length > 3)
                    {
                        int firstEmptySlot = -1;
                        for (int i = 0; i < totalSlots; i++)
                        {
                            if (parkingSlots[i] == null)
                            {
                                firstEmptySlot = i;
                                break;
                            }
                        }

                        if (firstEmptySlot != -1)
                        {
                            parkingSlots[firstEmptySlot] = new string[] { (firstEmptySlot + 1).ToString(), parts[1], parts[2], parts[3] };
                            Console.WriteLine($"Allocated slot number: {firstEmptySlot + 1}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, parking lot is full");
                        }
                    }
                    break;

                case "leave":
                    if (parts.Length > 1 && int.TryParse(parts[1], out int slotNumber))
                    {
                        if (slotNumber > 0 && slotNumber <= totalSlots && parkingSlots[slotNumber - 1] != null)
                        {
                            parkingSlots[slotNumber - 1] = null;
                            Console.WriteLine($"Slot number {slotNumber} is free");
                        }
                    }
                    break;

                case "status":
                    Console.WriteLine("Slot No.    Registration No.    Colour      Type");
                    foreach (var slot in parkingSlots)
                    {
                        if (slot != null)
                        {
                            Console.WriteLine($"{slot[0],-12}{slot[1],-20}{slot[2],-12}{slot[3]}");
                        }
                    }
                    break;

                case "type_of_vehicles":
                    if (parts.Length > 1)
                    {
                        string vehicleType = parts[1];
                        int vehicleCount = parkingSlots.Count(s => s != null && s[3].Equals(vehicleType, StringComparison.OrdinalIgnoreCase));
                        Console.WriteLine(vehicleCount);
                    }
                    break;

                case "registration_numbers_for_vehicles_with_odd_plate":
                    var oddPlates = parkingSlots
                        .Where(s => s != null && ExtractNumberFromPlate(s[1]) % 2 != 0)
                        .Select(s => s[1]);
                    Console.WriteLine(string.Join(", ", oddPlates));
                    break;

                case "registration_numbers_for_vehicles_with_even_plate":
                    var evenPlates = parkingSlots
                        .Where(s => s != null && ExtractNumberFromPlate(s[1]) % 2 == 0)
                        .Select(s => s[1]);
                    Console.WriteLine(string.Join(", ", evenPlates));
                    break;

                case "registration_numbers_for_vehicles_with_colour":
                    if (parts.Length > 1)
                    {
                        string color = parts[1];
                        var platesByColor = parkingSlots
                            .Where(s => s != null && s[2].Equals(color, StringComparison.OrdinalIgnoreCase))
                            .Select(s => s[1]);
                        Console.WriteLine(string.Join(", ", platesByColor));
                    }
                    break;

                case "slot_numbers_for_vehicles_with_colour":
                    if (parts.Length > 1)
                    {
                        string color = parts[1];
                        var slotsByColor = parkingSlots
                            .Where(s => s != null && s[2].Equals(color, StringComparison.OrdinalIgnoreCase))
                            .Select(s => s[0]);
                        Console.WriteLine(string.Join(", ", slotsByColor));
                    }
                    break;

                case "slot_number_for_registration_number":
                    if (parts.Length > 1)
                    {
                        string regNumber = parts[1];
                        var slot = parkingSlots
                            .FirstOrDefault(s => s != null && s[1].Equals(regNumber, StringComparison.OrdinalIgnoreCase));
                        if (slot != null)
                        {
                            Console.WriteLine(slot[0]);
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                    }
                    break;

                case "exit":
                    return;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }

    static int ExtractNumberFromPlate(string plate)
    {
        var match = Regex.Match(plate, @"\d+");
        return match.Success ? int.Parse(match.Value) : 0;
    }
}
