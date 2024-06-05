namespace l3t1_HorseRace.Classes;

public class BetSelectionHandler
{
    public static double[] betPrice = { 20, 50, 100, 150, 200, 250 };
    private int currentSelectedBet;

    public int CurrentIdx
    {
        get => currentSelectedBet;
    }

    private int _maxIdx;
    public int MaxIdx
    {
        get
        {
            if (_maxIdx == 0) _maxIdx = betPrice.Length - 1;
            return _maxIdx;
        }
    }

    public int NextBet()
    {
        if (currentSelectedBet + 1 > MaxIdx) return currentSelectedBet;
        return ++currentSelectedBet;
    }

    public int PrevBet()
    {
        if (currentSelectedBet - 1 < 0) return currentSelectedBet;
        return --currentSelectedBet;
    }

    public double GetBet() => betPrice[currentSelectedBet];
    public double GetBet(int idx) => betPrice[idx];
}