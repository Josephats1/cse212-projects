using System;

/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO). When GetNextPerson is called, the next person in the queue 
/// is returned and either re-added (if they have turns remaining or infinite turns) or removed.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a person to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">The person's name</param>
    /// <param name="turns">Number of turns; 0 or less means infinite turns</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person from the queue. Re-add them if they have remaining or infinite turns.
    /// </summary>
    /// <returns>The next Person in line</returns>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns — always re-enqueue
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Has turns left — decrement and re-enqueue
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // else: person.Turns == 1 → this is their last turn; don't re-enqueue

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
