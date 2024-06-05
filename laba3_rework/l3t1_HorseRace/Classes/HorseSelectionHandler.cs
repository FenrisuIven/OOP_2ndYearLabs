namespace l3t1_HorseRace.Classes;

public class HorseSelectionHandler
{
    private int currentSelectedHorse;

    public int CurrentIdx
    {
        get => currentSelectedHorse;
        private set => currentSelectedHorse = value;
    }

    private int _maxIdx;
    public int MaxIdx
    {
        get => _maxIdx;
        set
        {
            _maxIdx = value;
            if (CurrentIdx > _maxIdx) CurrentIdx = _maxIdx;
        } 
    }

    public int NextHorse()
    {
        if (currentSelectedHorse + 1 > MaxIdx) return currentSelectedHorse;
        return ++currentSelectedHorse;
    }

    public int PrevHorse()
    {
        if (currentSelectedHorse - 1 < 0) return currentSelectedHorse;
        return --currentSelectedHorse;
    }
}