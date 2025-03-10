namespace GARMIN_TEST;

/*
Times of an Activity:
elapsed duration (denoted ed): Total time from start to end on an activity. Doesn't stop on pauses.
timer duration (denoted td): Time that accounts for pauses, accumlates when a timer is on. td <= ed.
moving duration (denoted md): Total time a person was moving during an activity. md <= td
stop duration (sd): Total a person was not moving.
    if md is present then: sd = ed - md
    else: sd = ed - td
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
