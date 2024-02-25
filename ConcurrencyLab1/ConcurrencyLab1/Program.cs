using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

namespace ConcurrencyLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConcurrencyLab1 started.");

            SeedDb.SeedVaccines();

            // Start a new thread to simulate concurrent update
            Thread thread = new Thread(ConcurrentUpdate);
            thread.Start();

            using (var db = new AppDbContext())
            {
                var record = db.VaccineShots.First();

                var count = record.FirstShot;
                Console.WriteLine("Count read: " + count);

                // Simulate local update
                count++;
                record.FirstShot = count;

                // Write to database
                db.SaveChanges();
            }

            Console.WriteLine("Main thread finished.");
        }

        static void ConcurrentUpdate()
        {
            using (var db = new AppDbContext())
            {
                // Simulate update on another thread
                var record = db.VaccineShots.First();
                var count = record.FirstShot;
                Console.WriteLine("Concurrent thread read: " + count);
                Thread.Sleep(10000);
                // Increment the count and save changes
                count++;
                db.Database.ExecuteSqlRaw(
                    "UPDATE dbo.VaccineShots SET FirstShot = @p0 WHERE VaccineShotsId = 1",
                    count);

                Console.WriteLine("Concurrent thread finished.");
            }
        }
    }
}
