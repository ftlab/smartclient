namespace SmartClient.Core.Interfaces
{
    public interface ITreeItemViewModel
    {
        long Id { get; set; }
        bool IsDeleted { get; set; }
        bool IsVisible { get; set; }
        bool IsEnabled { get; }
        bool IsFiltered(string filter);
        bool IsVirtualTreeRoot { get; }
    }
}
