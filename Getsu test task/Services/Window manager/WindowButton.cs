class WindowButton
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Action? OnClicked { get; set; }
}