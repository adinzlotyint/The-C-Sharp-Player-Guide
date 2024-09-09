using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Quests.Quests
{
    public class Quest21
    {
        public static void Quest()
        {
            Door lockpick = new Door("XYZ");

            string response;
            while (true)
            {
                Console.WriteLine($"Door is: {lockpick.lockState} {lockpick.doorState}");
                Console.WriteLine("Available commands: lock, unlock, close, open");
                response = Console.ReadLine();
                Console.Clear();
                response = response switch
                {
                    "lock" => lockpick.Lock(),
                    "unlock" => lockpick.Unlock(),
                    "close" => lockpick.Close(),
                    "open" => lockpick.Open(),
                    _ => "Unrecognized command"
                };
                Console.WriteLine(response);

            }

        }
    }
}

public class Door
{
    internal LockState lockState = LockState.locked;
    internal DoorState doorState = DoorState.closed;
    private string _password;

    public string Open()
    {
        if (doorState == DoorState.open)
        {
            return "Door is already open.";
        }
        else if (lockState == LockState.locked)
        {
            return "First, you need to unlock the door.";
        }
        doorState = DoorState.open;
        return "Door opened!";
    }
    public string Close()
    {
        if (doorState == DoorState.closed)
        {
            return "Door is already closed.";
        }
        else if (lockState == LockState.locked)
        {
            return "First, you need to unlock the door.";
        }
        doorState = DoorState.closed;
        return "Door closed!";
    }

    public string Lock()
    {
        if (lockState == LockState.locked)
        {
            return "Door is already locked.";
        }
        else if (doorState == DoorState.open)
        {
            return "Door is open, close it first.";
        }

        _password = GetPassword();
        lockState = LockState.locked;
        return "Door locked!";
    }

    public string Unlock()
    {
        if (lockState == LockState.unlocked)
        {
            return "Door is already unlocked.";
        }
        else if (doorState == DoorState.open)
        {
            return "Door is open, close it first.";
        }

        string password = GetPassword();
        if (_password != password)
        {
            return "Wrong password.";
        }

        lockState = LockState.unlocked;
        return "Door unlocked!";
    }

    private string GetPassword()
    {
        string password;
        do
        {
            Console.WriteLine("Provide password:");
            password = Console.ReadLine();
            Console.Clear();
        } while (password == null);

        return password;
    }

    public Door(string initialPassword)
    {
        _password = initialPassword;
    }
}

enum DoorState { open, closed }
enum LockState { locked, unlocked }