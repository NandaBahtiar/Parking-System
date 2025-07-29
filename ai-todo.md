# Simple TODO - Parking System .NET

## 🎯 Buat 1 File Program.cs Saja

### Yang Harus Dibuat:

- [ ] **1 file Program.cs** yang berisi semua logic
- [ ] **List<string[]>** untuk menyimpan data parkir (slot, nopol, warna, tipe)
- [ ] **Switch statement** untuk handle semua command
- [ ] **Console.ReadLine()** loop sampai user ketik "exit"

---

## 📝 Command yang Harus Work:

1. **create_parking_lot 6** → "Created a parking lot with 6 slots"
2. **park B-1234-XYZ Putih Mobil** → "Allocated slot number: 1"
3. **leave 4** → "Slot number 4 is free"
4. **status** → Tampilkan tabel yang terisi
5. **type_of_vehicles Motor** → Hitung jumlah motor
6. **registration_numbers_for_vehicles_with_ood_plate** → List nopol ganjil
7. **registration_numbers_for_vehicles_with_event_plate** → List nopol genap
8. **registration_numbers_for_vehicles_with_colour Putih** → List nopol warna putih
9. **slot_numbers_for_vehicles_with_colour Putih** → List slot warna putih
10. **slot_number_for_registration_number B-3141-ZZZ** → Cari slot dari nopol
11. **exit** → Keluar program

---

## 🔧 Struktur Code Sederhana:

```csharp
class Program
{
    static List<string[]> parkingSlots = new List<string[]>(); // [slot, nopol, warna, tipe]
    static int totalSlots = 0;

    static void Main()
    {
        while(true)
        {
            Console.Write("$ ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            switch(parts[0])
            {
                case "create_parking_lot": // buat parking lot
                case "park": // parkir kendaraan
                case "leave": // keluar parkir
                case "status": // tampilkan status
                case "type_of_vehicles": // hitung tipe
                case "registration_numbers_for_vehicles_with_ood_plate": // nopol ganjil
                case "registration_numbers_for_vehicles_with_event_plate": // nopol genap
                case "registration_numbers_for_vehicles_with_colour": // nopol by warna
                case "slot_numbers_for_vehicles_with_colour": // slot by warna
                case "slot_number_for_registration_number": // cari slot
                case "exit": return;
            }
        }
    }
}
```

---

## ✅ Yang Penting:

1. **Output harus persis sama** dengan contoh di soal
2. **Ganjil/genap** ambil dari angka di nopol (misal B-1234-XYZ → 1234 → genap)
3. **Sequential slot** assignment (1,2,3,4...)
4. **Slot kosong bisa diisi lagi** setelah leave
5. **List output** pakai koma (misal: B-1234-XYZ, B-9999-XYZ)

---

## 🚀 Test Command:

Copy paste command ini untuk test:

```
create_parking_lot 6
park B-1234-XYZ Putih Mobil
park B-9999-XYZ Putih Motor
park D-0001-HIJ Hitam Mobil
park B-7777-DEF Red Mobil
park B-2701-XXX Biru Mobil
park B-3141-ZZZ Hitam Motor
leave 4
status
park B-333-SSS Putih Mobil
park A-1212-GGG Putih Mobil
type_of_vehicles Motor
type_of_vehicles Mobil
registration_numbers_for_vehicles_with_ood_plate
registration_numbers_for_vehicles_with_event_plate
registration_numbers_for_vehicles_with_colour Putih
slot_numbers_for_vehicles_with_colour Putih
slot_number_for_registration_number B-3141-ZZZ
slot_number_for_registration_number Z-1111-AAA
exit
```

**Target: 1 file, maksimal 150 baris code, semua command work!**
