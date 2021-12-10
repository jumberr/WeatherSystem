namespace BLL.Services.Interfaces
{
    public interface IDonateService
    {
        float CurrentPercent { get; }
        float GiveADonate(int value);
    }
}