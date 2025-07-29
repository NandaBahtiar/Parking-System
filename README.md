# Sistem Parkir Sederhana

Aplikasi konsol sederhana untuk mengelola tempat parkir. Aplikasi ini memungkinkan Anda untuk membuat lot parkir, memarkir kendaraan, mempersilakan kendaraan keluar, dan berbagai fitur lainnya.

## Cara Menjalankan

1.  **Build Project:**
    ```bash
    dotnet build
    ```

2.  **Jalankan Aplikasi:**
    ```bash
    dotnet run
    ```

## Perintah yang Tersedia

Berikut adalah daftar perintah yang dapat Anda gunakan:

-   `create_parking_lot [jumlah]` - Membuat lot parkir dengan jumlah slot yang ditentukan.
    -   Contoh: `create_parking_lot 6`

-   `park [nomor_registrasi] [warna] [tipe]` - Memarkir kendaraan baru di slot kosong pertama yang tersedia.
    -   Contoh: `park B-1234-XYZ Putih Mobil`

-   `leave [nomor_slot]` - Mengosongkan slot parkir.
    -   Contoh: `leave 3`

-   `status` - Menampilkan status semua slot parkir yang terisi.

-   `type_of_vehicles [tipe]` - Menghitung jumlah kendaraan dengan tipe tertentu.
    -   Contoh: `type_of_vehicles Mobil`

-   `registration_numbers_for_vehicles_with_odd_plate` - Menampilkan nomor registrasi kendaraan dengan plat nomor ganjil.

-   `registration_numbers_for_vehicles_with_even_plate` - Menampilkan nomor registrasi kendaraan dengan plat nomor genap.

-   `registration_numbers_for_vehicles_with_colour [warna]` - Menampilkan nomor registrasi kendaraan dengan warna tertentu.
    -   Contoh: `registration_numbers_for_vehicles_with_colour Putih`

-   `slot_numbers_for_vehicles_with_colour [warna]` - Menampilkan nomor slot kendaraan dengan warna tertentu.
    -   Contoh: `slot_numbers_for_vehicles_with_colour Putih`

-   `slot_number_for_registration_number [nomor_registrasi]` - Menampilkan nomor slot berdasarkan nomor registrasi.
    -   Contoh: `slot_number_for_registration_number B-1234-XYZ`

-   `exit` - Keluar dari aplikasi.
