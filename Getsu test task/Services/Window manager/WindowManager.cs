class WindowManager : IWindowManager
{
    public void Show(List<WindowButton> buttons) => 
        DrawInfo(buttons, null);

    private void DrawInfo(List<WindowButton> buttons, Action redrawInfo)
    {
        while (true)
        {
            redrawInfo?.Invoke();
            DrawButtons(buttons);
            var answerId = GetAnswerId();
            var button = buttons.FirstOrDefault(x => x.Id == answerId);
            Clear();
            if (button is not null)
            {
                button.OnClicked?.Invoke();
                break;
            }
        }
    }

    public void Show<T>(List<WindowButton> buttons, List<T> payload)
    {
        Action drawPayload = () => { DrawPayload(payload); };
        DrawInfo(buttons, drawPayload);
    }

    public void Show<T>(List<WindowButton> buttons, T payload)
    {
        Action drawPayload = () => { DrawPayload(payload); };
        DrawInfo(buttons, drawPayload);
    }

    public void Clear() => 
        Console.Clear();

    private int GetAnswerId()
    {
        Console.WriteLine("your choice: ");
        if (int.TryParse(Console.ReadLine(), out int answer))
            return answer;
        else return int.MinValue;
    }

    private void DrawButtons(List<WindowButton> buttons)
    {
        DrawLine();
        foreach (var button in buttons)
            Console.WriteLine($"{button.Id}. {button.Name}");
        DrawLine();
    }

    private void DrawPayload<T>(List<T> payloadsList)
    {
        DrawLine();
        if(payloadsList.Count > 0)
        {
            foreach (var payload in payloadsList)
                DrawPayload(payload);
        }
        else
        {
            Console.WriteLine("inventory is empty");
        }
        
    }

    private void DrawPayload<T>(T payload) => 
        Console.WriteLine(payload);

    private void DrawLine() => 
        Console.WriteLine("=====================");

    
}
