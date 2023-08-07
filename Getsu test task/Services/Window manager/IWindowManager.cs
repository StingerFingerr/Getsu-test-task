interface IWindowManager : IService
{
    void Show(List<WindowButton> buttons);
    void Show<T>(List<WindowButton> buttons, List<T> payload);
    void Show<T>(List<WindowButton> buttons, T payload);
    void Clear();
}