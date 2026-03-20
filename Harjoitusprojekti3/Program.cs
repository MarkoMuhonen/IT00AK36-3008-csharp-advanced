using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Harjoitusprojekti3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Event> events = new List<Event>();

            // TODO: -
            // Lisätty testidataa tapahtumille, Ok/Ei ok tapauksia, duplikaatti ID:itä, vääränlaisia ID:itä
            // Lisättty uusi metodi ValidateAndAddEvent, joka tarkistaa tapahtuman ID:n ennen lisäystä
            //
            // TESTIDATA ALKAA TÄSTÄ

            ValidateAndAddEvent(events, new Event("EVT-2026-009", "English Exam",
                new DateTime(2026, 5, 20, 16, 0, 0),
                120,
                EventType.Exam,
                EventStatus.Planned));

            ValidateAndAddEvent(events, new Event("EVT-26-1", "Math Exam",
                new DateTime(2026, 5, 20, 14, 0, 0),
                120,
                EventType.Exam,
                EventStatus.Planned));

            ValidateAndAddEvent(events, new Event("", "Italian Exam",
                new DateTime(2026, 5, 20, 12, 0, 0),
                120,
                EventType.Exam,
                EventStatus.Planned));

            ValidateAndAddEvent(events, new Event("EVT-2026-001", "C# Lecture",
                new DateTime(2026, 4, 10, 10, 0, 0),
                90,
                EventType.Lecture,
                EventStatus.Confirmed));

            ValidateAndAddEvent(events, new Event("EVT-2026-002", "Workshop: Git",
                new DateTime(2026, 4, 10, 9, 0, 0),
                180,
                EventType.Workshop,
                EventStatus.Planned));

            ValidateAndAddEvent(events, new Event("EVT-2026-002", "Workshop: Hit",
                new DateTime(2026, 4, 10, 9, 0, 0),
                180,
                EventType.Workshop,
                EventStatus.Planned));

            ValidateAndAddEvent(events, new Event("EVT-2026-002", "Workshop: Iit",
                new DateTime(2026, 4, 10, 9, 0, 0),
                180,
                EventType.Workshop,
                EventStatus.Planned));


            Console.WriteLine("Events before sorting:");
            PrintAll(events);

            // TODO: --
            // LISÄTTY: Järjestä tapahtumat (Sort)
            events.Sort();

            Console.WriteLine("\nEvents after sorting:");
            PrintAll(events);

            Console.WriteLine("\nOnly lectures:");
            PrintByType(events, EventType.Lecture);

            Console.WriteLine("\nCancelling EVT-2026-002:");
            CancelEventById(events, "EVT-2026-002");

            Console.WriteLine("\nCancelling EVT-2026-002:");
            CancelEventById(events, "EVT-2026-999");

            Console.WriteLine("\nPrint events by status:");
            PrintByStatus(events, EventStatus.Cancelled);

            Console.WriteLine("\nEvents after cancellation:");
            PrintAll(events);


        }      // TESTIDATA PÄÄTTYY TÄHÄN



        // ---------- METODIT ----------

        

        static void ValidateAndAddEvent(List<Event> events, Event ev)
        {
            if (!IsValidEventId(ev.Id))
            {
                Console.WriteLine("Invalid event ID: " + ev.Id);
                return;
            }

            foreach (Event existingEvent in events)
            {
                if (existingEvent.Id == ev.Id)
                {
                    Console.WriteLine("Duplicate event ID: " + ev.Id);
                    return;
                }
            }

            events.Add(ev);
        }

        static bool IsValidEventId(string id)
        {
            // EVT-YYYY-NNN
            string pattern = @"^EVT-[0-9]{4}-[0-9]{3}$";
            return Regex.IsMatch(id, pattern);
        }

        static void PrintAll(List<Event> events)
        {
            foreach (Event ev in events)
            {
                Console.WriteLine(ev);
            }
        }

        static void PrintByType(List<Event> events, EventType type)
        {
            foreach (Event ev in events)
            {
                if (ev.Type == type)
                {
                    Console.WriteLine(ev);
                }
            }
        }

        static void PrintByStatus(List<Event> events, EventStatus status)
        {
            foreach (Event ev in events)
            {
                if (ev.Status == status)
                {
                    Console.WriteLine(ev);
                }
            }
        }

        static void CancelEventById(List<Event> events, string id)
        {
            if (!IsValidEventId(id))
            {
                Console.WriteLine("Invalid ID format");
                return;
            }

            bool found = false;

            foreach (Event ev in events)
            {
                if (ev.Id == id)
                {
                    ev.Status = EventStatus.Cancelled;
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Not found");
            }
        }
    }
}
