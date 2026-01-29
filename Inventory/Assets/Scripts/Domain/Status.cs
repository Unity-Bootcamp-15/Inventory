using System.Diagnostics;

public readonly struct Status
{
    public int Atk { get; }
    public int Def { get; }

    public Status(int atk, int def)
    {
        Debug.Assert(atk >= 0);
        Debug.Assert(def >= 0);
        
        Atk = atk;
        Def = def;
    }
}